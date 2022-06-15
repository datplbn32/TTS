using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaughtPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMove playerMove = other.GetComponent<PlayerMove>();
        if (playerMove)
        {
            transform.position = playerMove.transform.position - playerMove.transform.forward.normalized;
            GameManager.Instance.GameOver();
        }
    }
}
