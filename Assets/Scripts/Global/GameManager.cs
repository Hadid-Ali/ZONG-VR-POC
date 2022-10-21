using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Global
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public static Action<bool> Aim;
        public static Action<Transform> MovePlayer;
        
        private GameplayData m_GameplayData;

        public Camera MainCamera => m_GameplayData.CameraManager.MainCameraObject;
        public Transform GlobalBillBoardTarget => m_GameplayData.CameraManager.MainCameraTransform;

        private void Start()
        {
            Application.targetFrameRate = 60;
        }

        public void RegisterGameplayData(GameplayData gameplayData)
        {
            m_GameplayData = gameplayData;
        }

        public void UnRegisterGameplayData(GameplayData gameplayData)
        {
            if (m_GameplayData == gameplayData)
                m_GameplayData = null;
        }
    }
}
