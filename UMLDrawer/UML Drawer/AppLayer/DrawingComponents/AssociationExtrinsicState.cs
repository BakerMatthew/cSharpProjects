using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class AssociationExtrinsicState
    {
        [DataMember]
        public string AssocationType { get; set; }

        [DataMember]
        public Point Location { get; set; }

        [DataMember]
        public Size Size { get; set; }

        [DataMember]
        public bool IsSelected { get; set; }

        public AssociationExtrinsicState Clone()
        {
            return new AssociationExtrinsicState()
            {
                AssocationType = AssocationType,
                Location = Location,
                Size = Size,
                IsSelected = IsSelected
            };
        }
    }
}
