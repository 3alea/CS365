using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedZonePass : MonoBehaviour{
    public float SpeedUp;
    private Rigidbody rb;
    private Vector3 lastPosition;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update(){
            lastPosition = transform.position;
    }

    void OnTriggerEnter(Collider _col){
        if (_col.gameObject.tag == "SpeedUp"){
            var direction = (transform.position - lastPosition)  / Time.deltaTime;
            //var localDirection = transform.InverseTransformDirection(direction);
            direction.Normalize();
            Debug.Log(direction);
            Vector3 v = direction * SpeedUp;
            rb.AddForce(v);
            lastPosition = transform.position;

            if (!FindObjectOfType<AudioManager>().IsPlaying("PowerUp"))
                 FindObjectOfType<AudioManager>().Play("PowerUp");
        }
    }
}
