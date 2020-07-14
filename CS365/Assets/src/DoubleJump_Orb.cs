using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump_Orb : MonoBehaviour
{
    public string player_name;
    // Update is called once per frame
    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.CompareTag(player_name))
        {
            Ball BallComp = obj.gameObject.GetComponent<Ball>();
            if(BallComp.JumpsRemaining <= 1)
                BallComp.JumpsRemaining += 1;
            Destroy(this.gameObject);
        }
    }
}
