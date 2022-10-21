using System;
using Global;
using UnityEngine;
using VRGame.Interaction;

namespace VRGame.Player
{
    public class PlayerMovement : SimpleMovement
    {
        private void OnEnable()
        {
            GameManager.MovePlayer += StartPlayerMovement;
        }

        private void OnDisable()
        {
            GameManager.MovePlayer -= StartPlayerMovement;
        }

        private void StartPlayerMovement(Transform target)
        {
            MoveTo(target, false);
        }
    }
}
