using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed, rotationSpeed;
    [SerializeField]
    float rotationUp, rotationDown;
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
