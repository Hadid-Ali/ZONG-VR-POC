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

        public virtual void OnFocus()
        {
            FocusState = FocusState.Focused;
        }

        public virtual void OnUnFocus()
        {
            FocusState = FocusState.UnFocused;
        }
    }
}