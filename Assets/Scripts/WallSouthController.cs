using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSouthController : MonoBehaviour {

    private int catchBallNum = 0;
    private int turn = 1;
    private Vector3 setPos;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            
            collision.gameObject.GetComponent<BallController>().StopBall();

            catchBallNum++;

            if(catchBallNum == 1)
            {
                setPos = collision.transform.position;
            }

            Destroy(collision.gameObject);

        }
    }

    public Vector3 GetSetPos()
    {
        catchBallNum = 0;
        return setPos;
    }

}
