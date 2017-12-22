using System.Collections.Generic;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class DeselectAllCommand : Command
    {
        private List<Element> selectedElements;
        internal DeselectAllCommand() { }

        public override bool Execute()
        {
            selectedElements = TargetDrawing?.DeselectAll();
            return selectedElements != null && selectedElements.Count > 0;
        }

        internal override void Undo()
        {
            if (selectedElements == null || selectedElements.Count == 0) return;

            foreach (var element in selectedElements)
            {
                if (!element.IsSelected)
                {
                    element.IsSelected = true;
                    TargetDrawing.IsDirty = true;
                }
            }

        }
        internal override void Redo()
        {
            if (selectedElements == null || selectedElements.Count == 0) return;

            foreach (var element in selectedElements)
            {
                if (element.IsSelected)
                {
                    element.IsSelected = false;
                    TargetDrawing.IsDirty = true;
                }
            }
        }
    }
}
