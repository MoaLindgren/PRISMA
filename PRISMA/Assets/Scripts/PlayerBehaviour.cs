using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed;
    float moveHorizontal, moveVertical;
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
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


        if (movement != Vector3.zero)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
            anim.Play("RunningAnimation");
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
}
