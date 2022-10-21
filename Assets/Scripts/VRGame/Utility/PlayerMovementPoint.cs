using Global;
using UnityEngine;
using UnityEngine.Events;

namespace VRGame.Utility
{
   public class PlayerMovementPoint : MovementPoint
   {
      protected override void OnEnable()
      {
         base.OnEnable();
         GameManager.MovePlayer(transform, OnReachPoint);
      }
   }
}
