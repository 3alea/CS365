﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : MonoBehaviour
{
    public float multiplier = 1.5f;

    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().velocity = direction * multiplier;

            //Speed sfx(this is only in miguels level)
            if (!FindObjectOfType<AudioManager>().IsPlaying("SpeedUp"))
            {
                FindObjectOfType<AudioManager>().Play("SpeedUp");
            }
        }
    }
}
