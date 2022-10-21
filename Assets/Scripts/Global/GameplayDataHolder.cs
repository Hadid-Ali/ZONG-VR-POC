using System;
using UnityEngine;

namespace Global
{
    [Serializable]
    public class GameplayData
    {
        [SerializeField] private CameraManager m_CameraManager;
        public CameraManager CameraManager => m_CameraManager;
    }
    
    public class GameplayDataHolder : MonoBehaviour
    {
        [SerializeField] private GameplayData m_GameplayData = new();

        private void OnEnable()
        {
            GameManager.Instance.RegisterGameplayData(m_GameplayData);
        }

        private void OnDisable()
        {
            GameManager.Instance.UnRegisterGameplayData(m_GameplayData);
        }
    }
}
