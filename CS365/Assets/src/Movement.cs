using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{
    public float MovSpeed;
    private Rigidbody rb;
    public float Max_time_speeded_up;
    public bool speeded_up;
    public float speeded_up_t;
    void Start(){
        rb = GetComponent<Rigidbody>();
    }
    void Update(){
        Vector3 v = new Vector3(MovSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0.0f, MovSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        rb.AddForce(v);
        Vector3 v2 = transform.forward;
        if(speeded_up)
            speeded_up_t+= Time.deltaTime;
            
        if(speeded_up_t >=Max_time_speeded_up)
        {
            speeded_up = false;
            MovSpeed = 200.0f;
        }
    } 
} 