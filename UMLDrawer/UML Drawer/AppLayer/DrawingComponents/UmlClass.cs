using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class UmlClass : Element
    {
        public static Pen LinePen { get; set; } = new Pen(Color.Black);
        public static Font TextFont { get; set; } = new Font("Arial", 18);
        public static Brush TextBrush { get; set; } = Brushes.Black;
        public static Brush FillBrush { get; set; } = Brushes.White;
        public static int Padding { get; set; } = 2;

        [DataMember]
        public Point Corner { get; set; }
        [DataMember]
        public Size Size { get; set; }
        [DataMember]
        public string Label { get; set; }

        public override Element Clone()
        {
            return new UmlClass() { Corner = Corner, Size = Size };
        }

        public override void Draw(Graphics graphics)
        {
            if (graphics == null) return;

            var box = new Rectangle() { Location = Corner, Size = Size };
            graphics.FillRectangle(FillBrush, box);

            if (IsSelected)
            {
                var g = new GraphicsWithSelection() { MyGraphics = graphics };
                g.DrawSelectionBox(Corner, Size);
            }
            else
                graphics.DrawRectangle(LinePen, box);

            var minimumSize = graphics.MeasureString("...", TextFont);
            if (Size.Width < minimumSize.Width - Padding * 2 ||
                Size.Height < minimumSize.Height - Padding * 2) return;

            var formatter = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            };

            var textRectangle = new RectangleF(Corner.X + Padding, Corner.Y + Padding, Size.Width - Padding * 2, Size.Height - Padding * 2);

            graphics.DrawString(Label, TextFont, TextBrush, textRectangle, formatter);
        }

        public override bool ContainsPoint(Point point)
        {
            return point.X >= Corner.X &&
                   point.Y >= Corner.Y &&
                   point.X < Corner.X + Size.Width &&
                   point.Y < Corner.Y + Size.Height;
        }

    }
}