using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;


    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private float gravity;

    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float groundDistance;
    
    
    [SerializeField]
    private float jumpHeight;



    bool IsGrounded;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    // Update is called once per frame
    void Update()
    {

        IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(IsGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }





        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

       if ( Input.GetButtonDown("Jump") && IsGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }



        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);



    }
}
