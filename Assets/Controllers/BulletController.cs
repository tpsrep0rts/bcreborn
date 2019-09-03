using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float initialVelocity;
    public float velocity;
    public float lifetime;
    public float lifetimeRemaining;
    public Vector3 forward;
    MeshRenderer mr;
  
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (velocity <= 0)
        {
            return;
        }

        transform.position = transform.position + forward * velocity * Time.deltaTime;
        lifetimeRemaining -= Time.deltaTime;
        if(lifetimeRemaining < 0)
        {
            Destroy(gameObject);
            Debug.Log("Destroy this");
        }
    }

    public void Fire(Vector3 direction)
    {
        forward = direction;
        Debug.Log(forward);
        lifetimeRemaining = lifetime;
        velocity = initialVelocity;
        mr = GetComponent<MeshRenderer>();
        mr.enabled = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        Destroy(gameObject);
    }
}
