using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_Speed; //Speed of bullet
    [SerializeField] private float m_Damage;//Make player Slower

    //Des troy this 5s
    private void Start()
    {
        Destroy(gameObject,5f);
    }
    
    //Make bullet forward
    private void Update()
    {
        transform.Translate(Vector3.forward * (m_Speed * Time.deltaTime));
    }

    //If trigged player make player slow, not boss, see in project setting physic
    private void OnTriggerEnter(Collider other)
    {
        PlayerMove playerMove = other.GetComponent<PlayerMove>();
        if (playerMove != null)
        {
            playerMove.Slow(m_Damage);
            Destroy(gameObject);
        }
    }
}