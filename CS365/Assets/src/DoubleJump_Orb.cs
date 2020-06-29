﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump_Orb : MonoBehaviour
{
    public string player_name;
    // Update is called once per frame
    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.CompareTag(player_name))
        {
            obj.gameObject.GetComponent<Ball>().DoubleJump = true;
            Destroy(this.gameObject);
        }
    }
}
