using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private static int ballNum = 1;
    private static bool isMoving = false;

    private float speed = 10.0f;
    private float gravity = 0.002f;

    private Rigidbody2D rb;
    private Vector2 startPos;


    void Awake () {
        this.rb = GetComponent<Rigidbody2D>();
	}
	
    
    public void FireBall(Vector2 dir)
    {
        rb.velocity = dir.normalized * speed;
        rb.gravityScale = gravity;
    }

    public void StopBall()
    {
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(transform.position.x,-2.88f,transform.position.z);
    }

    public static void SetIsMoving(bool b)
    {
        isMoving = b;
    }

    public static bool GetIsMoving()
    {
        return isMoving;
    }

    public static void IncreaseBallNum()
    {
        ballNum++;
    }

    public static int GetBallNum()
    {
        return ballNum;
    }
}
