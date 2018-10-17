using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private Rigidbody2D rb;
    private bool inPlay;
    [SerializeField]
    private Transform paddle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.AddForce(Vector2.up * 500);
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BottomCollider"))
        {
            Debug.Log("Ball hit the bottom of the screen");
        }
    }
}
