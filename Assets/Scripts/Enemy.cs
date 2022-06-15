using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject m_Bullet;
    [SerializeField] private float repeatRate;

    private void Start()
    {
        InvokeRepeating(nameof(Shoot), 0f, repeatRate);
    }

    void Shoot()
    {
        Instantiate(m_Bullet, transform.position, transform.rotation);
    }
}