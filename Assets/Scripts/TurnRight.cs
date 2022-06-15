using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRight : MonoBehaviour
{
    [SerializeField] private Transform newPivot;

    private void OnTriggerEnter(Collider other)
    {
        PlayerPivot playerPivot = other.GetComponent<PlayerPivot>();

        if (playerPivot != null)
        {
            other.GetComponent<PlayerRotate>().CancalRotate();
            if (playerPivot.isHorizontal)
            {
                playerPivot.pivot = newPivot.position.z;
                playerPivot.isHorizontal = !playerPivot.isHorizontal;
            }
            else
            {
                playerPivot.pivot = newPivot.position.x;
                playerPivot.isHorizontal = !playerPivot.isHorizontal;
            }

            Quaternion rot = Quaternion.LookRotation(transform.right);
            playerPivot.transform.rotation = rot;
            Destroy(gameObject);
        }
    }
}
