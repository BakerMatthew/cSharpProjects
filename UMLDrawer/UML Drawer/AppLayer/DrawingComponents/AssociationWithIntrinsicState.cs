using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace AppLayer.DrawingComponents
{
    internal class AssociationWithIntrinsicState : Association
    {
        private const string ASSOCIATION_ERROR = "Cannot select association with only intrinsic state - the intrinsic state is immutable";
        private const string DRAW_ASSOCIATION_ERROR = "Cannot draw an association with only intrinsic state";

        public static Color SelectionBackgroundColor { get; set; } = Color.DarkKhaki;
        public string AssocationType { get; set; }
        public Bitmap Image { get; private set; }
        public Bitmap ToolImage { get; private set; }
        public Bitmap ToolImageSelected { get; private set; }

        public override Element Clone()
        {
            return this;
        }

        public void LoadFromResource(string AssocationType, Type referenceTypeForAssembly)
        {
            if (string.IsNullOrWhiteSpace(AssocationType)) return;

            Assembly assembly = Assembly.GetAssembly(referenceTypeForAssembly);

            if (assembly == null) return;

            using (Stream stream = assembly.GetManifestResourceStream(AssocationType))
            {
                if (stream != null)
                {
                    Image = new Bitmap(stream);
                    ToolImage = new Bitmap(Image, ToolSize);
                    ToolImageSelected = new Bitmap(ToolSize.Width, ToolSize.Height);

                    Graphics g = Graphics.FromImage(ToolImageSelected);
                    g.Clear(SelectionBackgroundColor);
                    g.DrawImage(ToolImage, new Point() { X = 0, Y = 0 });
                }
            }
        }

        public override bool IsSelected
        {
            get { return false; }
            set
            {
                throw new ApplicationException(ASSOCIATION_ERROR);
            }
        }


        public override Point Location
        {
            get { return new Point(); }
            set
            {
                throw new ApplicationException(ASSOCIATION_ERROR);
            }
        }

        public override Size Size
        {
            get { return new Size(); }
            set
            {
                throw new ApplicationException(ASSOCIATION_ERROR);
            }
        }

        public override void Draw(Graphics graphics)
        {
            throw new ApplicationException(DRAW_ASSOCIATION_ERROR);
        }
    }
}
