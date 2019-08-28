using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float rotationSpeed;
    public float maxRotationSpeed;
    public float direction;

    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
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
            speed = maxSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            speed = -maxSpeed;
        }
        else
        {
            speed = 0;
        }
    }
    void FixedUpdate()
    {
        direction += rotationSpeed;
        transform.Rotate(0, -rotationSpeed, 0, Space.Self);
        Vector3 forward = new Vector3(
            Mathf.Cos(direction * Mathf.PI / 180),
            0,
            Mathf.Sin(direction * Mathf.PI / 180)
        );
        characterController.SimpleMove(forward * speed * Time.deltaTime);
    }
}
