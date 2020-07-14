using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCollectables : MonoBehaviour{

    public int CollectableNumber;
    public UnityEngine.UI.Text CollectableText;

    // Start is called before the first frame update
    void Start(){
        CollectableNumber = 0;
        CollectableText.text = CollectableNumber.ToString();
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnTriggerEnter(Collider _col){
        if (_col.gameObject.tag == "Collectable"){
            Destroy(_col.gameObject);
            CollectableNumber++;
            CollectableText.text = CollectableNumber.ToString();

            if(!FindObjectOfType<AudioManager>().IsPlaying("Star"))
                  FindObjectOfType<AudioManager>().Play("Star");
        }
    }
}
