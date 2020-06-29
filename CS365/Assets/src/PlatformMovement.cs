using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Vector3 Velocity;
    private Vector3 startingPoint;
    private Vector3 pathVec;
    private Rigidbody rb;
    private bool reset;
    private bool hold;
    public float timer;
    public float waitingTimer;
    private float internalTimer2;
    private float internalTimer;

    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
        rb = GetComponent<Rigidbody>();
        reset = false;
        hold = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        rb.mass = 20000;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = new Vector3(0.0f, 0.0f, 0.0f);

        if (!hold)
        {
            internalTimer += Time.deltaTime;
            if (reset) vel = -Velocity;
            else vel = Velocity;
        }

        if (internalTimer >= timer && reset == false)
        {
            reset = true;
            vel = new Vector3(0.0f, 0.0f, 0.0f);
            hold = true;
        }

        if (internalTimer >= 2.0f * timer && reset == true)
        {
            internalTimer = 0.0f;
            reset = false;
            vel = new Vector3(0.0f, 0.0f, 0.0f);
            hold = true;
        }

        if(hold)
            internalTimer2 += Time.deltaTime;

        if (internalTimer2 >= waitingTimer)
        {
            hold = false;
            internalTimer2 = 0.0f;
        }

        transform.localPosition += vel * Time.deltaTime;
    }
}
