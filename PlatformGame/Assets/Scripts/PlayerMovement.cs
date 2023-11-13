using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 0.1f;
    [SerializeField] float rotationSpeed = 1.5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float smallJumpForce = 3f;
    private float sqrt_2 = MathF.Sqrt(2f);
    private float centerRotation = 0f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 velocityX;
        Vector3 velocityY;

        if(horizontalInput + verticalInput != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (horizontalInput!=0 && verticalInput!=0)
        {
            velocityX = transform.forward *  verticalInput * movementSpeed/sqrt_2;
            velocityY = transform.right * horizontalInput * movementSpeed/sqrt_2;
        }
        else
        {
            velocityX = transform.forward * verticalInput * movementSpeed;
            velocityY = transform.right * horizontalInput * movementSpeed;
        }
        

        rb.velocity = (velocityX  + velocityY + Vector3.up * rb.velocity.y);
        transform.Rotate(new Vector3(0, mouseX * rotationSpeed, 0));
        if( !((centerRotation - mouseY*rotationSpeed)<-40 || (centerRotation - mouseY*rotationSpeed) > 63) )
        {
            centerRotation -= mouseY*rotationSpeed;
            transform.Find("Center").Rotate(-mouseY*rotationSpeed, 0, 0);
        }
        


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        if(IsGrounded())
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.pitch = 1f;
        jumpSound.Play();
    }

    void SmallJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, smallJumpForce, rb.velocity.z);
        jumpSound.pitch = 1.5f;
        jumpSound.Play();
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            SmallJump();
        }
    }
}
