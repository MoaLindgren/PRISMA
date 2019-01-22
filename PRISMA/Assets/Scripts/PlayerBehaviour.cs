using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField]
    float rotationSpeed, rotationUp, rotationDown;
    float moveHorizontal, moveVertical;
    Vector3 destination, movement;
    public bool moveable;
    Quaternion rot;
    //Animator anim;
    GameObject camera;

    void Start()
    {
        camera = GameObject.Find("Main Camera");
        //anim = GetComponent<Animator>();
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
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");
        movement = new Vector3(-moveVertical, 0, moveHorizontal);


        if (!Input.GetKey(KeyCode.LeftControl))
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);
        }


        print(transform.rotation.x);


        //transform.Rotate(-Vector3.down * rotationSpeed * Time.deltaTime);


        //if (movement != Vector3.zero)
        //{

        //    transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        //}
        transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        ////Back and turn left:
        //if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        //{
        //    transform.Rotate(-Vector3.down * rotationSpeed * Time.deltaTime);
        //}
        //Turn left:
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        ////Back and turn right:
        //if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        //{
        //    transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
        //}
        //Turn right:
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        //Forward:
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            //transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }
        //Back:
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
