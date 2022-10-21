using System;
using Global;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace VRGame.Interaction
{
    public class RandomBoxPlacer : MonoBehaviour
    {
        [SerializeField] private SimpleMovement m_SimpleMovement;
        [SerializeField] private float m_RandomPlacementWait = 2f;

        [SerializeField] private PlacementPoint[] m_PlacementPoints;

        private PlacementPoint m_FinalPlacementPoint;
        
        public void RandomPlacement()
        {
            Invoke(nameof(RandomPlacement_Internal), m_RandomPlacementWait);
        }

        private void RandomPlacement_Internal()
        {
            m_FinalPlacementPoint = m_PlacementPoints[Random.Range(0, m_PlacementPoints.Length)];
            m_FinalPlacementPoint.OnSelectPoint();

            m_SimpleMovement.MoveTo(m_FinalPlacementPoint.PlacementPointTransform, true, OnPointReach);
        }

        private void OnPointReach()
        {
            m_FinalPlacementPoint.OnReachPoint();
            GameManager.Instance.ChangeGameState(GameState.SimulationComplete);
        }
    }
}
