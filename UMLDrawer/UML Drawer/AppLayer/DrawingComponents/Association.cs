using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public abstract class Association : Element
    {
        public static Pen SelectedPen { get; set; } = new Pen(Color.DarkGray);
        public static Size ToolSize { get; set; } = new Size() { Width = 90, Height = 20 };
        public virtual Point Location { get; set; } = new Point(0, 0);
        public virtual Size Size { get; set; } = new Size(0, 0);
    }
}
