﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletShell : MonoBehaviour
{
    [SerializeField]
    private float _bulletSpeed, lifeTime;
    [SerializeField]
    private Rigidbody rgb;
    [SerializeField]
    private GameObject impactEffect;
    private int bulletDamage = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        rgb.velocity = transform.forward * _bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            AlienHealth _alienHealth = other.GetComponent<AlienHealth>();
            _alienHealth.Damage(bulletDamage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
    }

}