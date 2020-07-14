using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutlineFlux : MonoBehaviour
{
    public Outline outline;
    private int value;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vec;
        vec.x = 1;
        vec.y = 3 * Mathf.Sin(Mathf.Deg2Rad * (value++));
        outline.effectDistance = vec;
    }
}
