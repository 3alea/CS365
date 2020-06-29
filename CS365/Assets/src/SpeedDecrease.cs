﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDecrease : MonoBehaviour
{
    public float multiplier = 0.4f;

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
            other.GetComponent<Rigidbody>().velocity *= multiplier;
    }
}
