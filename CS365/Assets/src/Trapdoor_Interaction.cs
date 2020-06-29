using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor_Interaction : MonoBehaviour
{
    public float ray_length;
    public new Camera camera;
    // Update is called once per frame
    void Update()
    {
        // Get the direction vector to detect collision with the trapdoor which is supossed to be underneath.
            Vector3 forward = new Vector3(camera.transform.forward.x, -0.3f, camera.transform.forward.z).normalized;
            Debug.DrawRay(transform.position, forward * ray_length, Color.green);
        if(Input.GetKeyDown(KeyCode.E))
        {
            
            
            // Raycast to detect collision with all the objects in the direction of forward.
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, forward, ray_length);

            // Check with all the hit objects
            for(int i = 0 ; i < hits.Length ; i++)
            {
                if(hits[i].collider.gameObject.CompareTag("Trapdoor"))
                {
                    hits[i].collider.isTrigger = !hits[i].collider.isTrigger;
                }
            }
        }
    }
}
