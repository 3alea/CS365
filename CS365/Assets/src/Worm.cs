using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Worm : MonoBehaviour{

    private Vector3 InitialPos;
    private float timer;
    private int Direction = 1;
    private Rigidbody rb;
    public float TravelTime = 1.0f;
    public bool TavelInX = true;
    public float Speed = 1.0f;

    // Start is called before the first frame update
    void Start(){
        InitialPos = transform.localScale;
        rb = GetComponent<Rigidbody>();
        if (!TavelInX){
            Vector3 scale = new Vector3(transform.localScale.z, transform.localScale.y, transform.localScale.x);
            transform.localScale = scale;

        }
    }

    // Update is called once per frame
    void Update(){
        timer += Time.deltaTime;
        if(timer >= TravelTime){
            Direction = -Direction;
            timer = 0;
        }

        if (TavelInX){
            rb.velocity = new Vector3(Speed * Direction, 0.0f, 0.0f);
        } else {
            rb.velocity = new Vector3(0.0f, 0.0f, Speed * Direction);
        }
    }

    void OnCollisionEnter(Collision _col){
        if (_col.gameObject.tag == "Player"){

            float heightDiff = _col.gameObject.transform.position.y - transform.position.y;

            if (heightDiff > 0.13){
                Destroy(this.gameObject);
            }
        }
    }
}
