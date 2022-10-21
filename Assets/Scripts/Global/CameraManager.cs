using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera m_MainCamera;
    private Transform m_MainCameraTransform;
    
    public Camera MainCameraObject => m_MainCamera;
    public Transform MainCameraTransform
    {
        get
        {
            if (m_MainCameraTransform is null)
                m_MainCameraTransform = m_MainCamera.transform;

            return m_MainCameraTransform;
        }
    }
}
