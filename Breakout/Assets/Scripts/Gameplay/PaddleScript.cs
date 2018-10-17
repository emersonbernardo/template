using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

    [SerializeField]
    private PaddleConfig paddleConfig;

    private void Start()
    {
        
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime * paddleConfig.speed);
        if (transform.position.x < paddleConfig.leftEdgeScreen)
        {
            transform.position = new Vector2(paddleConfig.leftEdgeScreen, transform.position.y);
        }

        if (transform.position.x > paddleConfig.rightEdgeScreen)
        {
            transform.position = new Vector2(paddleConfig.rightEdgeScreen, transform.position.y);
        }
    }
}
