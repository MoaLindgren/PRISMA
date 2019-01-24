using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    float rotationSpeed;

    void Start()
    {
        rotationSpeed = transform.parent.GetComponent<PlayerBehaviour>().rotationSpeed;
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);

        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.rotation = transform.rotation;
        }
    }

}
