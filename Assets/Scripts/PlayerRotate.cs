using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    private bool m_RotateLeft = false;
    private bool m_RotateRight = false;
    private float m_SpeedTurn = 45f;
    private PlayerMove m_PlayerMove;

    private void Awake()
    {
        m_PlayerMove = GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (m_RotateLeft)
        {
            transform.Rotate(Vector3.up, -m_SpeedTurn * Time.deltaTime);
        }
        else if (m_RotateRight)
        {
            transform.Rotate(Vector3.up, m_SpeedTurn * Time.deltaTime);
        }
    }

    public void RotateLeft()
    {
        m_RotateLeft = true;
        m_PlayerMove.canGetInput = false;
    }

    public void RotateRight()
    {
        m_RotateRight = true;
        m_PlayerMove.canGetInput = false;
    }

    public void CancalRotate()
    {
        m_PlayerMove.canGetInput = true;
        m_RotateRight = false;
        m_RotateLeft = false;
    }
}