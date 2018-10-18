using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField]
    private Transform ballRespawnPoint;

    [SerializeField]
    private BallConfig ballConfig;

    private void Awake()
    {
        ballConfig.inPlay = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!ballConfig.inPlay)
            transform.position = ballRespawnPoint.position;

        if (Input.GetButtonDown("Jump") && !ballConfig.inPlay)
        {
            ballConfig.inPlay = true;
            rb.AddForce(Vector2.up * ballConfig.speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BottomCollider"))
        {
            rb.velocity = Vector2.zero;
            ballConfig.inPlay = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("RedBrick"))
        {
            Destroy(other.gameObject);
        }
    }
}
