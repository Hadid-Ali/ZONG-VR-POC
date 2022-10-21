using System;
using Global;
using UnityEngine;
using VRGame.UI.Base;

namespace VRGame.UI
{
    public class Crosshair : UIComponentWithColorStates
    {
        private void OnEnable()
        {
            GameManager.Aim += OnAim;
        }

        private void OnDisable()
        {
            GameManager.Aim -= OnAim;
        }

        private void OnAim(bool b)
        {
            if(b)
                OnFocus();
            else
            {
                OnUnFocus();
            }
        }
    }
}
