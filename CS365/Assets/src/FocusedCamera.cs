using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusedCamera : MonoBehaviour
{
    public Transform target;
    public float cameraRadius;
    public float rotationSpeed_X;
    public float rotationSpeed_Y;

    public float minY;
    public float maxY;

    float mouse_X;
    float mouse_Y;

    // Start is called before the first frame update
    void Start()
    {
        mouse_X = 0.0f;
        mouse_Y = Mathf.PI / 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Camera input
        mouse_X -= rotationSpeed_X * Time.deltaTime * Input.GetAxis("Mouse X");
        mouse_Y += rotationSpeed_Y * Time.deltaTime * Input.GetAxis("Mouse Y");

        if (mouse_Y < minY)
            mouse_Y = minY;
        else if (mouse_Y > maxY)
            mouse_Y = maxY;

        Vector3 desired_position;
        desired_position.x = target.position.x + cameraRadius * Mathf.Sin(mouse_Y) * Mathf.Cos(mouse_X);
        desired_position.y = target.position.y + cameraRadius * Mathf.Cos(mouse_Y);
        desired_position.z = target.position.z + cameraRadius * Mathf.Sin(mouse_Y) * Mathf.Sin(mouse_X);
        transform.position = desired_position;        
        transform.LookAt(target);
    }
}
