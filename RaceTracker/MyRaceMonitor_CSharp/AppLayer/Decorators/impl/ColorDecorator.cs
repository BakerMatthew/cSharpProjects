using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppLayer.Decorators.impl
{
    class ColorDecorator : AthleteDecorator
    {
        private Color normalColor;
        private Timer changeTimer;
        public int delayBetweenChanges { get; set; }
        public Color altColor { get; set; }

        public override void startTimer()
        {
            if (decoratedAthlete == null)
                return;
            base.startTimer();
            normalColor = decoratedAthlete.color;

            if (delayBetweenChanges == 0)
                delayBetweenChanges = 10;

            changeTimer = new Timer(ChangeColor, null, delayBetweenChanges, delayBetweenChanges);
        }

        private void ChangeColor(object sender)
        {
            decoratedAthlete.color = NextColor(decoratedAthlete.color, normalColor);
            notifyObservers();
        }
        private bool ColorAreEquivilent(Color c1, Color c2)
        {
            return (c1.R == c2.R && c1.G == c2.G && c1.B == c2.B && c1.A == c2.A);
        }

        private Color NextColor(Color currentColor, Color goalColor)
        {
            byte r = NextColorByte(currentColor.R, goalColor.R);
            byte g = NextColorByte(currentColor.G, goalColor.G);
            byte b = NextColorByte(currentColor.B, goalColor.B);
            byte a = NextColorByte(currentColor.A, goalColor.A);
            return Color.FromArgb(a, r, g, b);
        }

        private byte NextColorByte(byte currentByte, byte goalByte)
        {
            int different = goalByte - currentByte;

            if (different > 0)
                currentByte = Convert.ToByte(Math.Min(currentByte + 1, goalByte));
            else if (different < 0)
                currentByte = Convert.ToByte(Math.Max(currentByte - 1, goalByte));

            return currentByte;
        }
    }
}
