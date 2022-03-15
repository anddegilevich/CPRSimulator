using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform GroundCheck;
    public LayerMask groundMask;
    public float speed = 5f;
    public float gravity = 9.8f;

    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public Animator anim;
    public GameObject cam;
    public GameObject maincam;
    Vector3 velocity;

    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            anim.SetFloat("X", Input.GetAxis("Horizontal"));
            anim.SetFloat("Y", Input.GetAxis("Vertical"));
             
        }
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * gravity);
            anim.SetTrigger("Jump");
        }
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (Input.GetKey("c"))
        {
            controller.height = 1f;
        }
        else
        {
            controller.height = 1.75f;
        }
        if(Input.GetKey("left shift"))
        {
            speed = 10f;
            anim.SetFloat("Y", 2);
            cam.SetActive(true);
            maincam.SetActive(false);
        }
        else
        {
            speed = 5f;
            cam.SetActive(false);
            maincam.SetActive(true);
        }
    }
}
