using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerRotate playerRotate = other.GetComponent<PlayerRotate>();

        if (playerRotate)
        {
            playerRotate.RotateRight();
        }
    }
}
