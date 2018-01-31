using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule_movement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float sprint = 8.0F;
    public float rotationSpeed = 100.0F;
    public bool a = false;
    private int doble_salto = 0;
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody _rigidbody;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float mouse_x = Input.GetAxis("Mouse X");
        if (mouse_x != 0.0f)
        {
            transform.Rotate(0, Mathf.Lerp(0, mouse_x * rotationSpeed, Time.deltaTime), 0);
        }
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetKey(KeyCode.LeftShift))
                moveDirection *= sprint;
            else 
                moveDirection *= speed;
            if (Input.GetKeyDown("space"))
            {
                moveDirection.y = jumpSpeed;
                doble_salto = 1;
            }
        }
        else if (doble_salto < 2 && Input.GetKeyDown("space"))
        {
            moveDirection.y = jumpSpeed;
            doble_salto = 2;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Wall_walker")
        {
            a = true;
            transform.Rotate(0, 0, 60);
        }
    }



}