using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPersisted : MonoBehaviour
{
    public float factor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            rb.velocity = Vector3.Normalize(rb.velocity) * factor;
        }
    }
}
