using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpOrb : MonoBehaviour
{
    public float speed_up_factor;
    public string player_name;

    // Update is called once per frame
    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.CompareTag(player_name))
        {
            obj.gameObject.GetComponent<Ball>().MovSpeed *= speed_up_factor;
            obj.gameObject.GetComponent<Ball>().speeded_up = true;
            obj.gameObject.GetComponent<Ball>().speeded_up_t = 0.0f;
            Destroy(this.gameObject);

            if(!FindObjectOfType<AudioManager>().IsPlaying("SpeedUp"))
            {
                FindObjectOfType<AudioManager>().Play("SpeedUp");
            }
        }
    }
}
