using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGame.UI.Base
{
    public enum FocusState
    {
        UnFocused,
        Focused
    }

    public abstract class UIComponentWithStates : MonoBehaviour
    {
        public FocusState FocusState
        {
            get;
            protected set;
        }

        protected virtual void OnFocus()
        {
            FocusState = FocusState.Focused;
        }

        protected virtual void OnUnFocus()
        {
            FocusState = FocusState.UnFocused;
        }
    }
}