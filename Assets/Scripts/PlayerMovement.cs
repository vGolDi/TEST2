using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 10.0f;
    public float gravity = 20.0f; // Nowa zmienna dla wartoœci przyspieszenia grawitacyjnego

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0.0f, vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection.y = 0.0f;
                moveDirection.z = 1.0f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveDirection.y = 0.0f;
                moveDirection.z = -1.0f;
            }
            else
            {
                moveDirection.y = 0.0f;
            }
        }

        // Obracanie postaci wokó³ osi Y
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        controller.Move(moveDirection * Time.deltaTime);
    }
}

