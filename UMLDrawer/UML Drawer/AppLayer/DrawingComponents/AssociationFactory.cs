using System;
using System.Collections.Generic;

namespace AppLayer.DrawingComponents
{
    public class AssociationFactory
    {
        private static AssociationFactory instance;
        private static readonly object MyLock = new object();

        private AssociationFactory() { }

        public static AssociationFactory Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (instance == null)
                        instance = new AssociationFactory();
                }
                return instance;
            }
        }

        public string ResourceNamePattern { get; set; }
        public Type ReferenceType { get; set; }

        private readonly Dictionary<string, AssociationWithIntrinsicState> sharedAssocations = new Dictionary<
            string, AssociationWithIntrinsicState>();

        public AssociationWithAllState GetAssocation(AssociationExtrinsicState extrinsicState)
        {
            AssociationWithIntrinsicState assocationWithIntrinsicState;
            if (sharedAssocations.ContainsKey(extrinsicState.AssocationType))
                assocationWithIntrinsicState = sharedAssocations[extrinsicState.AssocationType];
            else
            {
                assocationWithIntrinsicState = new AssociationWithIntrinsicState();
                string resourceName = string.Format(ResourceNamePattern, extrinsicState.AssocationType);
                assocationWithIntrinsicState.LoadFromResource(resourceName, ReferenceType);
                sharedAssocations.Add(extrinsicState.AssocationType, assocationWithIntrinsicState);
            }

            return new AssociationWithAllState(assocationWithIntrinsicState, extrinsicState);
        }
    }
}
