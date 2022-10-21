using System.Collections;
using UnityEngine;

namespace VRGame.Interaction
{
    public class SimpleMovement : MonoBehaviour
    {
        [SerializeField] private float m_MovementSpeed = 15f;
        [SerializeField] private float m_DistanceReachOffset = 0.5f;
    
        private Transform m_Transform;
        private bool m_IsMoving = false;
        private readonly WaitForEndOfFrame m_WaitForEndOfFrame = new WaitForEndOfFrame();
    
        private void Start()
        {
            m_Transform = transform;
        }

        public void MoveTo(Transform target,bool setParent = false)
        {
            m_Transform.SetParent(null);
            StartCoroutine(MovementRoutine(target, setParent));
        }

        private IEnumerator MovementRoutine(Transform target, bool setParent)
        {
            while (Vector3.Distance(target.position, m_Transform.position) > m_DistanceReachOffset)
            {
                m_Transform.position =
                    Vector3.MoveTowards(m_Transform.position, target.position, m_MovementSpeed * Time.deltaTime);
                yield return m_WaitForEndOfFrame;
            }

            if (setParent)
                m_Transform.SetParent(target);
            OnMovementEnd();
        }

        protected virtual void OnMovementEnd()
        {
            
        }
    }
}