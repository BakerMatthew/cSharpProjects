using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class AddUmlClassCommand : Command
    {
        private readonly Point? corner;
        private readonly Size? size;
        private readonly string label;
        private Element umlClass;
        internal AddUmlClassCommand() { }

        /// <param name="commandParameters">
        ///     [0]: Point      start of the line
        ///     [1]: Point      end of the line
        /// </param>
        internal AddUmlClassCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                label = (string)commandParameters[0];

            if (commandParameters.Length > 1)
                corner = (Point)commandParameters[1];

            if (commandParameters.Length > 1)
                size = (Size)commandParameters[2];
        }

        public override bool Execute()
        {
            if (label == null || corner == null || size == null) return false;

            umlClass = new UmlClass() { Corner = (Point)corner, Size = (Size)size, Label = label };
            TargetDrawing.Add(umlClass);

            return true;
        }

        internal override void Undo()
        {
            TargetDrawing.DeleteElement(umlClass);
        }

        internal override void Redo()
        {
            TargetDrawing.Add(umlClass);
        }
    }
}
