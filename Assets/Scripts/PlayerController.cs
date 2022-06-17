using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private CharacterController controller;

    private Vector3 moveDirection = Vector3.zero;

    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float gravity;
    [SerializeField] private bool isGrounded = false;

    private Vector3 velocity = Vector3.zero;

    private void Start() 
    {
        controller = GetComponent<CharacterController>();
        Walk();
    }

    private void Update() 
    {

        isGrounded = Physics.CheckSphere(transform.position, groundDistance, layerMask);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
            
            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; //locks velocity at -2 if grounded, prevents from going below -2.
            }

            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                Run();
            }

            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                Walk();
            }
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = moveDirection.normalized; //same speed for moving diagonally

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
    }

    private void Run()
    {
        moveSpeed = runSpeed;
    }

    private void Jump()
    {
        velocity.y += Mathf.Sqrt(2 * -2f * gravity);
    }   
}