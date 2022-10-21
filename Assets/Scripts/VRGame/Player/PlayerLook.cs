using Global;
using UnityEngine;
using VRGame.Input;
using VRGame.Interaction;

namespace VRGame.Player
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] private LayerMask m_LayerMask;
        private Interactable m_CurrentInteractable;

        [SerializeField] private GameObject m_InteractionPoint;
        private Transform m_Transform;
        
        void Start()
        {
            m_Transform = transform;
        }

        // Update is called once per frame
        void Update()
        {
            PlayerLookMethod();
        }

        private void PlayerLookMethod()
        {
            if (Physics.Raycast(m_Transform.position, m_Transform.forward, out RaycastHit raycastHit, Mathf.Infinity,
                    m_LayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out Interactable interactable))
                {
                    if (interactable == m_CurrentInteractable || !interactable.IsInteractable)
                        return;
                    RegisterInteractable(interactable);
                }
                else
                {
                    NullifyInteractable();
                }
            }
            else
            {
                NullifyInteractable();
            }
        }

        private void OnPlayerInteraction()
        {
            if (m_CurrentInteractable is not null)
            {
                m_CurrentInteractable.OnInteraction(m_InteractionPoint);
                
                if (!m_CurrentInteractable.IsInteractable)
                {
                    NullifyInteractable();
                }
            }
        }

        private void RegisterInteractable(Interactable interactable)
        {
            NullifyInteractable();

            m_CurrentInteractable = interactable;
            m_CurrentInteractable.OnInteractionStart();
            
            GameManager.Aim(true);
            InputManager.Instance.RegisterInputActionEvent(OnPlayerInteraction);
        }

        private void NullifyInteractable()
        {
            if (m_CurrentInteractable is null)
                return;
            GameManager.Aim(false);
            m_CurrentInteractable.OnInteractionExit();
            m_CurrentInteractable = null;
            InputManager.Instance.UnRegisterInputActionEvent(OnPlayerInteraction);
        }
    }
}