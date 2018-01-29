using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed = 10.0f;
    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        Vector3 velocity = new Vector3(0, speed, 0);
        velocity = gameObject.transform.TransformDirection(velocity);
        rb.velocity = velocity;
    }

    void MoveForward(float speed)
    {
        Vector3 velocity = new Vector3(0, speed, 0);
        velocity = gameObject.transform.TransformDirection(velocity);
        rb.velocity = velocity;
    }

    // remove the bullet and the enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.tag == "Enemy")
                collision.gameObject.SetActive(false);
            rb.velocity = Vector3.zero;
            Destroy(gameObject);
        }
    }
}
