using Global;
using UnityEngine;
using UnityEngine.Events;

namespace VRGame.Utility
{
   public class PlayerMovementPoint : MonoBehaviour
   {
      [SerializeField] private UnityEvent m_OnReach;

      private void OnEnable()
      {
         GameManager.MovePlayer(transform, OnReachPoint);
      }

      protected virtual void OnReachPoint()
      {
         m_OnReach?.Invoke();
      }
   }
}
