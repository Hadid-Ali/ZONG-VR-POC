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

        public void RandomPlacement()
        {
            Invoke(nameof(RandomPlacement_Internal), m_RandomPlacementWait);
        }

        private void RandomPlacement_Internal()
        {
            PlacementPoint point = m_PlacementPoints[Random.Range(0, m_PlacementPoints.Length)];
            point.OnSelectPoint();

            m_SimpleMovement.MoveTo(point.PlacementPointTransform, true, point.OnReachPoint);
        }
    }
}
