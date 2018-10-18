using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField]
    private Transform ballRespawnPoint;
    [SerializeField]
    private BallConfig ballConfig;
    private bool firstStart;

    private void OnEnable()
    {
        GameManager.OnStartGame += StartGame;
    }

    private void OnDisable()
    {
        GameManager.OnStartGame -= StartGame;
    }

    private void Awake()
    {
        ballConfig.inPlay = false;
        firstStart = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!ballConfig.inPlay)
            transform.position = ballRespawnPoint.position;

        if ( (!firstStart) && (Input.GetButtonDown("Jump") && !ballConfig.inPlay) )
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

    public void StartGame()
    {
        firstStart = false;
        ballConfig.inPlay = true;
        rb.AddForce(Vector2.up * ballConfig.speed);
    }
}
