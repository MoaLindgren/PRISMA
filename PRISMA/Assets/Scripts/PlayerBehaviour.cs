using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField]
    float rotationSpeed, rotationUp, rotationDown;
    //float moveHorizontal, moveVertical;
    //Vector3 movement;
    public bool moveable;
    GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
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
        //moveVertical = Input.GetAxis("Vertical");
        //moveHorizontal = Input.GetAxis("Horizontal");
        //movement = new Vector3(-moveVertical, 0, moveHorizontal);


        if (!Input.GetKey(KeyCode.LeftControl))
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            mainCamera.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);

        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            mainCamera.transform.rotation = transform.rotation;
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
