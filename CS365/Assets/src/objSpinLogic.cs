using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objSpinLogic : MonoBehaviour
{
    public Vector3 spinVec;
    public float spinIntensity;

    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        spinVec.Normalize();
        tr.Rotate(spinVec, spinIntensity);
    }
}
