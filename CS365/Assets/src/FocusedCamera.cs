using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCaptureHandler
{
    static private List<MouseCapturer> sCapturers = new List<MouseCapturer>();

    public static void RegisterCapturer(MouseCapturer _capturer)
    {
        if(_capturer != null)
        {
            sCapturers.Add(_capturer);
            _capturer.ActivateCapturer();
        }
    }

    public static void ReleaseCapturer(MouseCapturer _capturer)
    {
        if(_capturer != null)
        {
            sCapturers.Remove(_capturer);
            if (sCapturers.Count != 0)
                sCapturers[sCapturers.Count-1].ActivateCapturer();
            else
                Cursor.lockState = CursorLockMode.None;
        }
    }
}

public class MouseCapturer
{
    private CursorLockMode mMode;
    
    public MouseCapturer(CursorLockMode _mode)
    {
        mMode = _mode;
        MouseCaptureHandler.RegisterCapturer(this);
    }

    public void ActivateCapturer()
    {
        Cursor.lockState = mMode;
    }

    public void UpdateMouseCaptureMode(CursorLockMode _mode)
    {
        if(mMode != _mode)
        {
            mMode = _mode;
            ActivateCapturer();
        }
    }

    ~MouseCapturer()
    {
        MouseCaptureHandler.ReleaseCapturer(this);
    }
}

public class FocusedCamera : MonoBehaviour
{
    public Transform target;
    public float cameraRadius;
    public float rotationSpeed_X;
    public float rotationSpeed_Y;

    public float minY;
    public float maxY;

    public bool bCameraActive;
    private bool bPrevCamActiveState;

    public bool bInvertX;
    public bool bInvertY;

    float mouse_X;
    float mouse_Y;

    private MouseCapturer mMouseCapturer;

    // Start is called before the first frame update
    void Start()
    {
        mouse_X = 0.0f;
        mouse_Y = Mathf.PI / 2.0f;
        bInvertX = false;
        bInvertY = true;
        bCameraActive = true;
        bPrevCamActiveState = !bCameraActive;

        mMouseCapturer = new MouseCapturer(CursorLockMode.Locked);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(bCameraActive)
        {
            // Camera input
            mouse_X -= rotationSpeed_X * Time.deltaTime * Input.GetAxis("Mouse X") * (bInvertX ? -1.0f : 1.0f);
            mouse_Y += rotationSpeed_Y * Time.deltaTime * Input.GetAxis("Mouse Y") * (bInvertY ? -1.0f : 1.0f);

            if (mouse_Y < minY)
                mouse_Y = minY;
            else if (mouse_Y > maxY)
                mouse_Y = maxY;
        }

        Vector3 desired_position;
        desired_position.x = target.position.x + cameraRadius * Mathf.Sin(mouse_Y) * Mathf.Cos(mouse_X);
        desired_position.y = target.position.y + cameraRadius * Mathf.Cos(mouse_Y);
        desired_position.z = target.position.z + cameraRadius * Mathf.Sin(mouse_Y) * Mathf.Sin(mouse_X);
        transform.position = desired_position;        
        transform.LookAt(target);
    }
}
