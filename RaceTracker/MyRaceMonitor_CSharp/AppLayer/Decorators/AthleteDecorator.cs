using AppLayer.subject.impl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Decorators
{
    class AthleteDecorator : Athlete
    {
        public Athlete decoratedAthlete { get; set; }
        public override int bibNumber => decoratedAthlete.bibNumber;

        public override Color color
        {
            get { return decoratedAthlete.color; }
            set { decoratedAthlete.color = value; }
        }


        public override void startTimer()
        {
            decoratedAthlete.startTimer();
        }

        public override void stopTimer()
        {
            decoratedAthlete.stopTimer();
        }
    }
}
