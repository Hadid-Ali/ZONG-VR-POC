using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRGame.Interaction;

public class RandomBoxPlacer : MonoBehaviour
{
    [SerializeField] private SimpleMovement m_SimpleMovement;
    [SerializeField] private float m_RandomPlacementWait = 2f;

    [SerializeField] private Transform m_BoxA, m_BoxB;

    public void RandomPlacement()
    {
        Invoke(nameof(RandomPlacement_Internal), m_RandomPlacementWait);
    }

    private void RandomPlacement_Internal()
    {
        int randomIndex = Random.Range(0, 2);
        m_SimpleMovement.MoveTo(randomIndex < 1 ? m_BoxA : m_BoxB);
    }
}
