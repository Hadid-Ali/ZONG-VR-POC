using Global;
using UnityEngine;
using UnityEngine.Events;

namespace VRGame.Interaction
{
    public class PlacementPoint : MonoBehaviour
    {
        [SerializeField] private Transform m_PlacementPoint;
        [SerializeField] private UnityEvent m_OnPlacementStart, m_OnPointReach;

        public Transform PlacementPointTransform => m_PlacementPoint;

        public void OnSelectPoint()
        {
            m_OnPlacementStart.Invoke();
        }

        public void OnReachPoint()
        {
            m_OnPointReach.Invoke();
        }
    }
}
