using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    public enum GameState
    {
        Menu,
        Gameplay,
        SimulationComplete
    }

    public class GameStateManager : MonoBehaviour
    {
        private GameState m_CurrentGameState;

        private void Start()
        {
            ChangeGameState(GameState.Menu);
        }

        public void ChangeGameState(GameState gameState)
        {
            m_CurrentGameState = gameState;
            OnGameStateChange_Internal(gameState);
        }

        private void OnGameStateChange_Internal(GameState gameState)
        {
            switch (m_CurrentGameState)
            {
                case GameState.SimulationComplete:
                    SoundManager.Instance.PlaySoundOneShot(SoundType.TaskComplete);
                    Invoke(nameof(ReloadScene), 1f);
                    break;
            }
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
