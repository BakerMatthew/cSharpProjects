using System;
using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class AddAssociationCommand : Command
    {
        private const int WIDTH = 90;
        private const int HEIGHT = 20;

        private readonly string assocationType;
        private Point location;
        private Element assocationAdded;

        /// <param name="commandParameters">
        ///     [0]: string     assocation type
        ///     [1]: Point      center location for the assocation
        /// </param>
        internal AddAssociationCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                assocationType = commandParameters[0] as string;

            if (commandParameters.Length > 1)
                location = (Point)commandParameters[1];
            else
                location = new Point(0, 0);
        }

        public override bool Execute()
        {
            if (string.IsNullOrWhiteSpace(assocationType) || TargetDrawing == null) return false;

            var assocationSize = new Size()
            {
                Width = WIDTH,
                Height = HEIGHT
            };
            var assocationLocation = new Point(location.X - assocationSize.Width / 2, location.Y - assocationSize.Height / 2);

            var extrinsicState = new AssociationExtrinsicState()
            {
                AssocationType = assocationType,
                Location = assocationLocation,
                Size = assocationSize
            };
            assocationAdded = AssociationFactory.Instance.GetAssocation(extrinsicState);
            TargetDrawing.Add(assocationAdded);

            return true;
        }

        internal override void Undo()
        {
            TargetDrawing.DeleteElement(assocationAdded);
        }

        internal override void Redo()
        {
            TargetDrawing.Add(assocationAdded);
        }
    }
}
