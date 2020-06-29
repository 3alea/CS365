using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour
{
    public float trigger_distance;
    public float movement_velocity;
    public GameObject player;
    private Rigidbody rb;
    private Transform mTransform;
    private Transform player_transform;
    public bool activated;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, trigger_distance);
    }
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        rb = GetComponent<Rigidbody>();
        mTransform = GetComponent<Transform>();
        player_transform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(mTransform.position, player_transform.position);
        if (trigger_distance >= Mathf.Abs(distance))
            activated = true;
        if(activated)
        {
            Vector3 movement = Vector3.Normalize(player_transform.position - mTransform.position);
            Vector3 v = new Vector3(movement_velocity * movement.x * Time.deltaTime, 0.0f, movement_velocity * movement.z * Time.deltaTime);
            rb.AddForce(v);
        }
    }
}
