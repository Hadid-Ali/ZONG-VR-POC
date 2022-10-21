using UnityEngine;

namespace VRGame.Interaction
{
    public class PickableBall : Interactable
    {
        [SerializeField] private SimpleMovement m_PickableMovement;
        
        public override void OnInteractionStart()
        {
            
        }

        public override void OnInteraction(GameObject interactionTarget)
        {
            base.OnInteraction(interactionTarget);
            m_PickableMovement.MoveTo(interactionTarget.transform);
        }

        public override void OnInteractionExit()
        {
            
        }
    }
}
