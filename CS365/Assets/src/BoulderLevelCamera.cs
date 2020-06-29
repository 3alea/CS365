using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderLevelCamera : MonoBehaviour
{
    public float distance = 20;
    public Transform playerTransform;
    public Transform floor;

    private float inclineDegrees;
    private Vector3 direction;
    private float originalZ;

    // Start is called before the first frame update
    void Start()
    {
        inclineDegrees = floor.rotation.z;
        direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * inclineDegrees) * distance, Mathf.Sin(Mathf.Deg2Rad * inclineDegrees) * distance, 0.0f);
        transform.position = playerTransform.position + direction;
        originalZ = playerTransform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // No need to multiply by the distance since the direction has already been scaled in Start
        float x = playerTransform.position.x + direction.x;
        float y = playerTransform.position.y + direction.y;

        transform.position = new Vector3(x, y, transform.position.z);
        transform.LookAt(new Vector3(playerTransform.position.x, playerTransform.position.y, originalZ));
    }
}
