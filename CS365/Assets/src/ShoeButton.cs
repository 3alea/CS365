using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeButton : MonoBehaviour
{
    public DoorOpenManager theDoorManager;
    bool alreadyActived;

    // Start is called before the first frame update
    void Start()
    {
        alreadyActived = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && alreadyActived == false)
        {
            alreadyActived = true;
            theDoorManager.Buttoncount++;

            MeshRenderer m = GetComponent<MeshRenderer>();
            m.material.color = Color.red;
        }
    }
}
