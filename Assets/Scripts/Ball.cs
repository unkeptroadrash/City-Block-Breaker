using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // configuration parameters
    [SerializeField] Paddle paddle;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 10f;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted == false)
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    }

    private void LaunchBallOnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddleToBallVector + paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted == true)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
