﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Dame_Trap : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider != null && other.collider.tag != "ground"){
            other.gameObject.GetComponent<Player>().Damage(5);
        }
    }
}
