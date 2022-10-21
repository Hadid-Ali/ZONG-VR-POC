using UnityEngine;
using UnityEngine.Events;

namespace VRGame.Interaction
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] private bool m_IsPersistentInteractable = false;
        private bool m_IsInteractable = true;

        [SerializeField] private UnityEvent m_OnInteractionUnityEvent;
        
        public bool IsInteractable
        {
            protected set => m_IsInteractable = value;
            get => m_IsInteractable;
        }

        public abstract void OnInteractionStart();

        public virtual void OnInteraction(GameObject interactionTarget)
        {
            IsInteractable = m_IsPersistentInteractable;
            m_OnInteractionUnityEvent?.Invoke();
        }
        
        public abstract void OnInteractionExit();
    }
}
