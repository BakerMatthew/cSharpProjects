using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class AssociationWithAllState : Association
    {
        public Pen OutlinePen { get; set; } = new Pen(Color.DarkGray);
        internal AssociationWithIntrinsicState IntrinsicState { get; }

        [DataMember]
        public AssociationExtrinsicState ExtrinsicState { get; set; }

        internal AssociationWithAllState(AssociationWithIntrinsicState sharedPart, AssociationExtrinsicState nonsharedPart)
        {
            IntrinsicState = sharedPart;
            ExtrinsicState = nonsharedPart;
        }

        public override bool IsSelected
        {
            get { return ExtrinsicState.IsSelected; }
            set { ExtrinsicState.IsSelected = value; }
        }

        public override Point Location
        {
            get { return ExtrinsicState.Location; }
            set { ExtrinsicState.Location = value; }
        }


        public override Size Size
        {
            get { return ExtrinsicState.Size; }
            set { ExtrinsicState.Size = value; }
        }

        public override Element Clone()
        {
            return new AssociationWithAllState(IntrinsicState, ExtrinsicState = ExtrinsicState.Clone());
        }


        public override void Draw(Graphics graphics)
        {
            if (graphics == null || IntrinsicState?.Image == null) return;

            graphics.DrawImage(IntrinsicState.Image,
                new Rectangle(ExtrinsicState.Location.X, ExtrinsicState.Location.Y, ExtrinsicState.Size.Width,
                    ExtrinsicState.Size.Height),
                0, 0, IntrinsicState.Image.Width, IntrinsicState.Image.Height,
                GraphicsUnit.Pixel);

            if (ExtrinsicState.IsSelected)
            {
                var g = new GraphicsWithSelection() { MyGraphics = graphics };
                g.DrawSelectionBox(ExtrinsicState.Location, ExtrinsicState.Size);
            }
        }

        public override bool ContainsPoint(Point point)
        {
            return point.X >= Location.X && point.Y >= Location.Y &&
                   point.X <= Location.X + Size.Width &&
                   point.Y <= Location.Y + Size.Height;
        }

    }

}
