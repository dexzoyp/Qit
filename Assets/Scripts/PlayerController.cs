using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public LayerMask groundMask;
    public Transform groundCheck;

    public float speed = 7.5f;
    public float gravity = -32f;
    float groundDistance = 0.4f;
    float jumpHeigth = 1.5f;
    Vector3 velocity;

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
    bool isJumped()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Debug.Log("Jumped");
            return true;
        }
        return false;
    }
    void Update()
    {
        isJumped();
        if (isGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);


        if (isJumped())
        {
            velocity.y = Mathf.Sqrt(jumpHeigth * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
