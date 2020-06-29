using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Transform mCamera;
    public float MovSpeed;
    public float MaxSpeed;
    public float JumpSpeed;
    private Rigidbody rb;
    private Transform trans;

    // Freeze player
    public bool isActive;
    private Vector3 playerOrigPos;

    // Double jump
    public float doubleJump_max_time;
    public bool DoubleJump;
    private bool JumpRestricted;
    float DoubleJump_time;
    private int JumpCount;
    private float internalTimer;
    private float PowerUpTime;
    
    // Speed up
    public float Max_time_speeded_up;
    public bool speeded_up;
    public float speeded_up_t;

    // Death
    public float death_hight;

    //Enemy
    public float pushback_vel;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
        playerOrigPos = trans.localPosition;
        DoubleJump = false;
        JumpRestricted = false;
        JumpCount = 0;
        internalTimer = 0.0f;
        PowerUpTime = 3.0f;
        DoubleJump_time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
            return;

        Vector3 direction = transform.position - mCamera.position;
        Vector3 view = new Vector3(direction.x, 0.0f, direction.z);
        Vector3 right = Vector3.Cross(view, new Vector3(0.0f, 1.0f, 0.0f));
        view.Normalize();
        right.Normalize();

        Vector3 result = new Vector3(0, 0, 0);

        if (rb.velocity.magnitude < MaxSpeed)
        {
            if (Input.GetKey(KeyCode.W))
                result += view;//rb.AddForce(view * MovSpeed);
            if (Input.GetKey(KeyCode.A))
                result += right;
            if (Input.GetKey(KeyCode.S))
                result -= view;
            if (Input.GetKey(KeyCode.D))
                result -= right;
        }

        result.Normalize();
        rb.AddForce(result * MovSpeed);


        if (JumpRestricted)
            internalTimer += Time.deltaTime;

        if (internalTimer >= PowerUpTime)
        {
            JumpRestricted = false;
            internalTimer = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if ((!DoubleJump && JumpCount == 1) || (DoubleJump && JumpCount == 2) || JumpRestricted)
                return;
            rb.AddForce(0, JumpSpeed, 0, ForceMode.Impulse);
            JumpCount += 1;
        }

        // Double Jump timer
        if(DoubleJump)
        {
            if(doubleJump_max_time < DoubleJump_time)
                DoubleJump = false;
            DoubleJump_time += Time.deltaTime;
        }
        
        // Speed up timer
        if(speeded_up)
            speeded_up_t+= Time.deltaTime;
        if(speeded_up_t >=Max_time_speeded_up)
        {
            speeded_up = false;
            MovSpeed = 200.0f;
        }

        // F YOU DIED
        if(trans.position.y < death_hight)
            SceneManager.LoadScene("Scenes/Menu");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            JumpCount = 0;
        }

        if (other.gameObject.CompareTag("JumpRestriction"))
        {
            Destroy(other.collider.gameObject);
            JumpRestricted = true;
            JumpCount = 0;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Vector3 enemy_trans = other.transform.position;
            Vector3 direction = Vector3.Normalize(trans.position - enemy_trans);
            Vector3 v = new Vector3(pushback_vel * direction.x * Time.deltaTime, 0.0f, pushback_vel * direction.z * Time.deltaTime);
            rb.AddForce(v);
        }
    }

    public void SetActive(bool active)
    {
        
    }
}
