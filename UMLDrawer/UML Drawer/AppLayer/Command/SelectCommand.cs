using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class SelectCommand : Command
    {
        private readonly Point location;
        private Element element;
        private bool originalState;

        internal SelectCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                location = (Point)commandParameters[0];
        }

        public override bool Execute()
        {
            element = TargetDrawing.FindElementAtPosition(location);
            if (element == null) return false;

            originalState = element.IsSelected;
            element.IsSelected = !originalState;

            TargetDrawing.IsDirty = true;

            return true;
        }

        internal override void Undo()
        {
            if (element.IsSelected == originalState) return;

            element.IsSelected = originalState;
            TargetDrawing.IsDirty = true;
        }

        internal override void Redo()
        {
            if (element.IsSelected != originalState) return;

            element.IsSelected = !originalState;
            TargetDrawing.IsDirty = true;
        }
    }
}
