using System.Collections;
using System.Collections.Generic;
using Global;
using UnityEngine;
using VRGame.Interaction;
using VRGame.UI;
using VRGame.UI.Base;

public class InteractableUI : Interactable
{
    [SerializeField] private UIComponentWithColorStates m_UIStatesHandler;

    public override void OnInteractionStart()
    {
        m_UIStatesHandler.OnFocus();
        SoundManager.Instance.PlaySoundOneShot(SoundType.Tick);
    }

    public override void OnInteractionExit()
    {
        m_UIStatesHandler.OnUnFocus();

    }
}
