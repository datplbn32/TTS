using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float speedUp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            other.GetComponent<PlayerMove>().SpeedUp(speedUp);
            Destroy(gameObject);
        }
    }
}
