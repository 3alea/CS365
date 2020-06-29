using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGravity : MonoBehaviour
{
    public Vector3 newGravity;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = newGravity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
