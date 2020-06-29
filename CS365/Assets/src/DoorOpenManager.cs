using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenManager : MonoBehaviour
{
    public Rigidbody rbShoe;
    public int MaxButtonCount;
    public int Buttoncount;
    // Start is called before the first frame update
    void Start()
    {
        Buttoncount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Buttoncount >= MaxButtonCount)
        {
            rbShoe.isKinematic = false;
        }
    }
}
