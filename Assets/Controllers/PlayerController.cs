using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float rotationSpeed;
    public float maxRotationSpeed;
    public GameObject followingCamera;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rotationSpeed = maxRotationSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotationSpeed = -maxRotationSpeed;
        } else
        {
            rotationSpeed = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            speed = -maxSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            speed = maxSpeed;
        }
        else
        {
            speed = 0;
        }
    }
    void FixedUpdate()
    {
        transform.Rotate(0, -rotationSpeed, 0, Space.Self);
        rb.AddForce(transform.forward * speed * Time.deltaTime);

        /* This should go at the end */
        if(followingCamera)
        {
            followingCamera.transform.position = new Vector3(
               transform.position.x,
               followingCamera.transform.position.y,
               transform.position.z
            );
        }
    }
}
