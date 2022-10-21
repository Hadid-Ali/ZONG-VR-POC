using System.Collections;
using System.Collections.Generic;
using Global;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private Transform m_Transform;
    
    void Start()
    {
        m_Transform = transform;
    }

    void Update()
    {
        transform.LookAt(GameManager.Instance.GlobalBillBoardTarget);
    }
}
