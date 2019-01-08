using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed;
    float moveHorizontal, moveVertical;
    public bool moveable;
    Quaternion rot;

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
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
}
