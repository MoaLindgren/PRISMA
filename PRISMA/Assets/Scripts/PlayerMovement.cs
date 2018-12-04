using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float moveSpeed;
    float moveHorizontal, moveVertical;

    Quaternion rot;

    void Update()
    {
        Move();
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
