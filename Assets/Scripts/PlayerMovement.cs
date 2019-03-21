using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;

    private float translation;
    private float straffe;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 2f;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            speed = 0f;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            speed = 2f;
        }
        Animating(h, v);
        Move(h, v);

    }

    void Move(float h, float v)
    {
        // ser um hreyfingu player-ins
        translation = v * speed * Time.deltaTime;
        straffe = h * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);
    }
    
    void Animating(float h, float v)
    {
        // breytir um animation thegar a vid
        bool walking = h != 0f || v != 0f;
        if(speed >= 2.1f)
        {
            anim.SetBool("IsRunning", walking);
            anim.SetBool("IsAiming", false);
            anim.SetBool("IsWalking", true);
        } else if(speed >= 0.1f && speed <= 2f)
        {
            anim.SetBool("IsWalking", walking);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsAiming", false);
        } else if(speed == 0f)
        {
            anim.SetBool("IsAiming", true);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsWalking", false);
        }
    }
}
