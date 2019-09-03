using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public bool isShooting;
    public GameObject bulletPrefab;
    public float shootCooldown;
    public float shootCooldownRemaining;
    public GameObject tank;
    public GameObject bulletOrigin;

    public float rotationSpeed;
    public float maxRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotationSpeed = -maxRotationSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotationSpeed = maxRotationSpeed;
        }
        else
        {
            rotationSpeed = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }

    void FixedUpdate()
    {
        if (shootCooldownRemaining > 0)
        {
            shootCooldownRemaining = Mathf.Max(shootCooldownRemaining - Time.deltaTime, 0);
        }
        else if(isShooting)
        {
            Shoot();
        }

        transform.Rotate(0, rotationSpeed, 0, Space.Self);
    }

    bool Shoot()
    {
        if(shootCooldownRemaining > 0)
        {
            return false;
        }
        GameObject bullet = Instantiate(bulletPrefab, bulletOrigin.transform.position, Quaternion.identity);
        BulletController bulletController = bullet.GetComponent<BulletController>();

        Vector3 direction = Quaternion.Euler(0, 90, 0) * transform.forward;
        bulletController.Fire(direction);
        shootCooldownRemaining = shootCooldown;
        return true;
    }

    public void SetIsShooting(bool shooting)
    {
        isShooting = shooting;
    }
}
