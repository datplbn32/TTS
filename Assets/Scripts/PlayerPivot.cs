using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPivot : MonoBehaviour
{
    public float pivot; //Diem chot
    public bool isHorizontal = true; //Nguoi choi ngang hay doc

    private float m_Bound = 1.3f; //Gioi han
    
    private void Update()
    {
        if (isHorizontal)
        {
            if (transform.position.x > pivot + m_Bound)
            {
                transform.position = new Vector3(pivot + m_Bound, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < pivot - m_Bound)
            {
                transform.position = new Vector3(pivot - m_Bound, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (transform.position.z > pivot + m_Bound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, pivot + m_Bound);
            }
            else if (transform.position.z < pivot - m_Bound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, pivot - m_Bound);
            }
        }
    }
}