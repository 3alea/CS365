using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objSpinLogic : MonoBehaviour
{
    public Vector3 spinVec;
    public float spinIntensity;

    public bool startRotating = true;
    public bool randomStartRotation = false;

    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();

        if (randomStartRotation)
        {
            Vector3 startingRot = transform.eulerAngles;
            
            if (spinVec.x != 0.0f)
                startingRot.x = Random.Range(0.0f, 360.0f);
            if (spinVec.y != 0.0f)
                startingRot.y = Random.Range(0.0f, 360.0f);
            if (spinVec.z != 0.0f)
                startingRot.z = Random.Range(0.0f, 360.0f);

            transform.eulerAngles = startingRot;
        }
    }

    // Update is called once per frame
    void Update()
    {
        spinVec.Normalize();
        tr.Rotate(spinVec, spinIntensity);
    }
}
