using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupScene : MonoBehaviour
{
    [SerializeField] private float m_WaitBeforeGameplayLoading = 3.5f;
    
    void Start()
    {
        Invoke(nameof(LoadGameplay),m_WaitBeforeGameplayLoading);
    }

    private void LoadGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
