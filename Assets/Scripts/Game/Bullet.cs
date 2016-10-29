﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour
{
    public int damage = 25;
    //private int damageOriginal;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    public void DamageBuff(int buff)
    {
        //Adiciona o buff ao dano
        damage += buff;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!NetworkServer.active)
        {
            return;
        }

        GameObject hit = other.gameObject;
        PlayerHealth health = hit.GetComponent<PlayerHealth>();

        if (health)
            health.TakeDamage(damage);

        Destroy(gameObject);
    }
}
