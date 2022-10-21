using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRGame.Input;

public class FillerBar : MonoBehaviour
{
   [SerializeField] private Image m_FillerImage;
   [SerializeField] private float m_TimeBeforeCompleteFill = 3.5f;

   private float m_FillAmount;
   private readonly WaitForEndOfFrame m_WaitForSeconds = new WaitForEndOfFrame();

   private void Start()
   {
      m_FillAmount = 1 / (m_TimeBeforeCompleteFill * 60);
   }

   private void OnEnable()
   {
      InputManager.Instance.RegisterOnInputEvents(StartFillerForAction, StopFillerAction);
   }

   private void OnDisable()
   {
      InputManager.Instance.UnregisterOnInputEvents(StartFillerForAction, StopFillerAction);
   }

   private void StartFillerForAction(Action action)
   {
      StopFillerAction();
      StartCoroutine(FillerRoutine(action));
   }

   private void StopFillerAction()
   {
      m_FillerImage.fillAmount = 0;
      StopAllCoroutines();
   }
   
   private IEnumerator FillerRoutine(Action action)
   {
      while (m_FillerImage.fillAmount < 1)
      {
         m_FillerImage.fillAmount += m_FillAmount;
         yield return m_WaitForSeconds;
      }
      StopFillerAction();
      action.Invoke();
   }
}
