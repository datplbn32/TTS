using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const float SpeedVertical = 2;
    
    private float m_SpeedHorizontal = 3;
    private float m_SpeedVertical = 2;
    private float horizontalInput = 0;
    private GameManager m_GameManager;

    public bool canGetInput = true;
    public bool isBoss;
    
    private void Start()
    {
        m_GameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (m_GameManager.IsGameActive)
        {
            Move();
        }
    }

    private void Move()
    {
        if (canGetInput && !isBoss)
        {
            horizontalInput = 0;
            if (Input.GetMouseButton(0))
            {
                horizontalInput = Input.mousePosition.x > Screen.width / 2 ? 1 : -1;
                transform.Translate(Vector3.right * (horizontalInput * m_SpeedHorizontal * Time.deltaTime));
            }
            
        }
        transform.Translate(Vector3.forward * (m_SpeedVertical * Time.deltaTime));
    }
    
    public void SpeedUp(float speedUp)
    {
        m_SpeedVertical = SpeedVertical + speedUp;
        Invoke(nameof(Reset),2f);
    }
    
    public void Slow(float speedSlow)
    {
        m_SpeedVertical = SpeedVertical - speedSlow;
        Invoke(nameof(Reset),3f);
    }

    private void Reset()
    {
        m_SpeedVertical = SpeedVertical;
    }
}