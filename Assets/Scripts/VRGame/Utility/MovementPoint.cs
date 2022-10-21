using System;
using UnityEngine;
using UnityEngine.Events;

namespace VRGame.Utility
{
    public class MovementPoint : MonoBehaviour
    {
        [SerializeField] private UnityEvent m_OnReach,m_OnMovementStart;

        protected virtual void OnEnable()
        {
            m_OnMovementStart.Invoke();
        }

        public virtual void OnReachPoint()
        {
            m_OnReach?.Invoke();
        }
    }
}
