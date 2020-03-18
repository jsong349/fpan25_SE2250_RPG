﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private int Damage = 20;
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start() {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == PlayerSingleton.player){
            GameEvents.current.PlayerGetsDamaged(Damage);
        }

        EnemyStats enemy = other.GetComponent<EnemyStats>();
        if (enemy != null){
            enemy.TakeDamage(Damage);
        }
    }
    //For each projectile override this method with stats, etc.
    public int ProjectileDamage{
        get {
            return Damage;
        }
        set {
            //Put multipliers here
            Damage = value;
        }
    }
}
