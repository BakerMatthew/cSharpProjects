using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppLayer.Decorators.impl
{
    class TextSizeDecorator : AthleteDecorator
    {

        private Timer changeTimer;
        private float maxSize;
        private float minSize;
        private int direction = 1;

        public int deltaSize { get; set; }
        public int delayBetweenChanges { get; set; }

        public override void startTimer()
        {
            if (decoratedAthlete == null) return;

            base.startTimer();

            deltaSize = Math.Abs(deltaSize);
            minSize = Math.Max(1, decoratedAthlete.textSize - deltaSize);
            maxSize = decoratedAthlete.textSize + deltaSize;
            if (delayBetweenChanges == 0)
                delayBetweenChanges = 100;

            changeTimer = new Timer(ChangeSize, null, delayBetweenChanges, delayBetweenChanges);
        }

        private void ChangeSize(object sender)
        {
            decoratedAthlete.textSize += direction;

            if (decoratedAthlete.textSize > maxSize)
            {
                decoratedAthlete.textSize = maxSize;
                direction = -1;
            }
            if (decoratedAthlete.textSize < minSize)
            {
                decoratedAthlete.textSize = minSize;
                direction = 1;
            }
            notifyObservers();
        }
    }
}
