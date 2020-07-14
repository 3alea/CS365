using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public bool lockVerticalMovement = false;
    public bool limitVelocity = true;
    public bool EnableJumping = true;   // Used by RemoveJump script for boulder level (jump restricted works with timers)

    public Transform mCamera;
    public float MovSpeed;
    public float MaxSpeed;
    public float JumpSpeed;
    private Rigidbody rb;
    private Transform trans;

    // Freeze player
    public bool isActive;
    private Vector3 playerOrigPos;

    // Jumping Parameters
    public float JumpVertSpeedTreshhold; // Determines the vertical velocity treshhold below which the player can activate their jump ability whilst in mid-air.
    public int JumpsRemaining;  // Determines how many times the ball can jump. Decreases by one each time a jump is performed.
    private bool JumpRestricted;
    private float internalTimer;
    private bool bOnJumpableSurface;

    private float PowerUpTime;
    // Speed up
    public float Max_time_speeded_up;
    public bool speeded_up;
    public float speeded_up_t;

    // Death
    public float death_hight;

    //Enemy
    public float pushback_vel;

    public WinCondition wc;

    // Level to restart
    public string level2Load;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
        playerOrigPos = trans.localPosition;
        JumpRestricted = false;
        bOnJumpableSurface = false;
        // Make movement speed constant between all levels
        MovSpeed = 150.0f; // Acceleration (who named this???)
        MaxSpeed = 12.55f; // Self-explanatory
        JumpsRemaining = 0;
        internalTimer = 0.0f;
        PowerUpTime = 3.0f;
        JumpVertSpeedTreshhold = 0.5f;
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

        if (rb.velocity.magnitude < MaxSpeed || limitVelocity == false)
        {
            if (Input.GetKey(KeyCode.W) && lockVerticalMovement == false)
                result += view;//rb.AddForce(view * MovSpeed);
            if (Input.GetKey(KeyCode.A))
                result += right;
            if (Input.GetKey(KeyCode.S) && lockVerticalMovement == false)
                result -= view;
            if (Input.GetKey(KeyCode.D))
                result -= right;
        }

        result.Normalize();
        rb.AddForce(result * MovSpeed * Time.deltaTime / 0.007f);
        //rb.velocity += result * MovSpeed * 0.010f;


        if (JumpRestricted)
            internalTimer += Time.deltaTime;

        if (internalTimer >= PowerUpTime)
        {
            JumpRestricted = false;
            internalTimer = 0.0f;
        }

        if (EnableJumping && !JumpRestricted && JumpsRemaining > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            // If ball is in mid-air, do not allow it to jump if its vertical speed is above the treshhold.
            if( (!bOnJumpableSurface && rb.velocity.y <= JumpVertSpeedTreshhold) || bOnJumpableSurface)
            {
                rb.AddForce(0, JumpSpeed, 0, ForceMode.Impulse);
                JumpsRemaining -= 1;
            }
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
        if (trans.position.y < death_hight)
            Restart();
    }

    void OnCollisionEnter(Collision other)
    {
        bOnJumpableSurface = false;
        if (JumpsRemaining <= 0 && other.gameObject.CompareTag("Floor"))
        {
            JumpsRemaining = 1;
            bOnJumpableSurface = true;
        }

        if (other.gameObject.CompareTag("JumpRestriction"))
        {
            Destroy(other.collider.gameObject);
            JumpRestricted = true;
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

    public void Restart()
    {
        WinCondition.LoadCertainLevel(level2Load);
    }
}
