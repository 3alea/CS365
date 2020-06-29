using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointWorkAround : MonoBehaviour
{
    public Rigidbody rb;
    public float maxtime;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > maxtime)
        {
            rb.AddForce(rb.velocity.normalized * 60.0f);
            timer = 0.0f;
        }
    }
}
