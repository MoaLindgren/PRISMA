using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField]
    float rotationSpeed;
    float moveHorizontal, moveVertical;
    Vector3 destination;
    public bool moveable;
    Quaternion rot;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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
        //Back and turn left:
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-Vector3.down * rotationSpeed * Time.deltaTime);
        }
        //Turn left:
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
        //Back and turn right:
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
        }
        //Turn right:
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
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
