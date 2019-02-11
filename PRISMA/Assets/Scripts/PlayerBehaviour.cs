using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed, rotationSpeed;
    [SerializeField]
    float rotationUp, rotationDown;
    bool moveable;
    public bool Moveable
    {
        set { moveable = value; }
    }

    void Start()
    {
        moveable = true;
    }
    void Update()
    {
        if (moveable)
        {
            Move();
        }
    }
    void Move()
    {
        //float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //float xRotation = Input.GetAxis("Mouse X");

        //Vector3 movement = new Vector3(-horizontal, 10, -vertical);
        //Vector3 rotation = new Vector3(0, xRotation, 0);
        //Quaternion rot = Quaternion.Euler(rotation * rotationSpeed * Time.deltaTime);
        //Rigidbody rb = GetComponent<Rigidbody>();

        //if(movement != Vector3.zero)
        //{
        //    rb.MovePosition(transform.position + movement);
        //    rb.MoveRotation(transform.rotation * rot);
        //}


        if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);
        }

        transform.position = new Vector3(transform.position.x, 10, transform.position.z);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
