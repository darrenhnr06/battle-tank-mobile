using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTank : MonoBehaviour
{
    private CharacterController charController;
    public float movement_Speed = 3f;
    public float gravity = 9.8f;
    public float rotation_Speed = 0.15f;
    public float rotateDegreesPerSecond = 180f;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Rotate();
    }


    void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }
    }

    void Rotate()
    {
        Vector3 rotation_Direction = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation_Direction = transform.TransformDirection(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation_Direction = transform.TransformDirection(Vector3.right);
        }
        if (rotation_Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotation_Direction), rotateDegreesPerSecond * Time.deltaTime);
        }
    }
}
