using System.Drawing;

namespace AppLayer.DrawingComponents
{
    public abstract class Element
    {
        public virtual bool IsSelected { get; set; } = false;
        public abstract Element Clone();
        public virtual void Draw(Graphics graphics) { }
        public virtual bool ContainsPoint(Point point) { return false; }
    }
}
