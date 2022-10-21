using System;
using Global;
using UnityEngine;
using VRGame.Interaction;

namespace VRGame.Player
{
    public class PlayerMovement : SimpleMovement
    {
        private Action m_OnMovementEnd;
        
        private void OnEnable()
        {
            GameManager.MovePlayer += StartPlayerMovement;
        }

        private void OnDisable()
        {
            GameManager.MovePlayer -= StartPlayerMovement;
        }

        private void StartPlayerMovement(Transform target,Action action)
        {
            MoveTo(target, false);
            m_OnMovementEnd = action;
        }

        protected override void OnMovementEnd()
        {
            base.OnMovementEnd();
            
            m_OnMovementEnd?.Invoke();
            m_OnMovementEnd = null;
        }
    }
}
