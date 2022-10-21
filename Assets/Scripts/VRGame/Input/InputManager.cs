using System;
using Global;
using Google.XR.Cardboard;
using UnityEngine;

namespace VRGame.Input
{
    public class InputManager : MonoSingleton<InputManager>
    {
        private Action m_InputAction;
        
        private Action<Action> m_OnInputInit;
        private Action m_OnInputDiscard;

        public void RegisterOnInputEvents(Action<Action>  onInputInit, Action onInputDiscard)
        {
            m_OnInputInit += onInputInit;
            m_OnInputDiscard += onInputDiscard;
        }
        
        public void UnregisterOnInputEvents(Action<Action> onInputInit, Action onInputDiscard)
        {
            m_OnInputInit -= onInputInit;
            m_OnInputDiscard -= onInputDiscard;
        }

        public void RegisterInputActionEvent(Action action)
        {
            Debug.LogError("Register Input");
            m_InputAction += action;
            m_OnInputInit?.Invoke(m_InputAction);
        }

        public void UnRegisterInputActionEvent(Action action)
        {
            Debug.LogError("UnRegister Input");

            m_InputAction -= action;
            m_OnInputDiscard?.Invoke();
        }
        
        private void Update()
        {
            ProcessInputs();
        }

        void ProcessInputs()
        {
            if(m_InputAction is null)
                return;

            if (Api.IsTriggerPressed)
            {
                m_InputAction.Invoke();
                SoundManager.Instance.PlaySoundOneShot(SoundType.Click);
            }
        }
    }
}
