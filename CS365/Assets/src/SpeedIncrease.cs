using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : MonoBehaviour
{
    public float multiplier = 1.5f;

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
            other.GetComponent<Rigidbody>().velocity *= multiplier;

            //Speed sfx(this is only in miguels level)


            //if (!FindObjectOfType<AudioManager>().IsPlaying("PowerUp"))
            //     FindObjectOfType<AudioManager>().Play("PowerUp");
        }
    }
}
