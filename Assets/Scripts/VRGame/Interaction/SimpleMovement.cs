using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using VRGame.Utility;

namespace VRGame.Interaction
{
    public class SimpleMovement : MonoBehaviour
    {
        [SerializeField] private float m_MovementSpeed = 15f;
        [SerializeField] private float m_DistanceReachOffset = 0.5f;

        [SerializeField] private UnityEvent m_OnReachEnd;
        
        private Transform m_Transform;
        private bool m_IsMoving = false;
        private readonly WaitForEndOfFrame m_WaitForEndOfFrame = new WaitForEndOfFrame();
    
        private void Start()
        {
            m_Transform = transform;
        }

        public void MoveTo(Transform target,bool setParent = false,Action actionOnReach = null)
        {
            m_Transform.SetParent(null);
            StartCoroutine(MovementRoutine(target, setParent,actionOnReach));
        }

        private IEnumerator MovementRoutine(Transform target, bool setParent,Action onReach)
        {
            while (Vector3.Distance(target.position, m_Transform.position) > m_DistanceReachOffset)
            {
                m_Transform.position =
                    Vector3.MoveTowards(m_Transform.position, target.position, m_MovementSpeed * Time.deltaTime);
                yield return m_WaitForEndOfFrame;
            }

            if (setParent)
                m_Transform.SetParent(target);

            onReach?.Invoke();
            OnMovementEnd();
        }

        protected virtual void OnMovementEnd()
        {
            m_OnReachEnd?.Invoke();
        }
    }
}