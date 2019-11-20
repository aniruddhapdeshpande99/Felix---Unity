﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Script8 : MonoBehaviour
{
    // Start is called before the first frame update
    //public float health = 100.0f;
    //public float damage = 5.0f;
    public GameObject other;
    private Rigidbody rb;
    public int count = 0;
    public Truck8 truckScript;
    public Color greenColor = new Color(0.0F, 1.0F, 0.0F, 1.0F);
    public Health health;


    void Start()
    {
        health = other.GetComponent<Health>();
        rb = GetComponent<Rigidbody>();
        GameObject theTruck = GameObject.Find("Truck8");

        truckScript = theTruck.GetComponent<Truck8>();
    }

    void Update()
    {

        if (count == 5 && truckScript.destructible)
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.material.color = greenColor;
            truckScript.destructible = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && truckScript.destructible)
        {
            //rb.mass -= 100;
            health.TakeDamage(20);
            Debug.Log(count);
            count++;
        }
    }
}

