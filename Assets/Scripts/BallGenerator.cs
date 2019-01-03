using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour {

    public GameObject ballPrefab;

    private GameObject gameDirector;
    private Vector2 startPos;
    private float fireInterval = 0.12f;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, -2.88f, 0);
        gameDirector = GameObject.Find("GameDirector");
	}
	
	// Update is called once per frame
	void Update () {
        if (gameDirector.GetComponent<GameDirector>().GetGaming() == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0) && BallController.GetIsMoving() == false)
            {
                Vector2 endPos = Input.mousePosition;

                if (startPos.y - endPos.y > 3f)
                {
                    BallController.SetIsMoving(true);
                    Vector2 dir = new Vector2(startPos.x - endPos.x, startPos.y - endPos.y);
                    StartCoroutine(fire(dir));
                }
            }
        }
    }
    
    private IEnumerator fire (Vector2 dir)
    {
        for (int i = 0; i < BallController.GetBallNum(); i++)
        {
            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity) as GameObject;
            ball.GetComponent<BallController>().FireBall(dir);
            yield return new WaitForSeconds(fireInterval);
        }
    }


    public void setPos(Vector3 pos)
    {
        transform.position = pos;
    }


    void OnDrawGizmos()
    {
        if (Input.GetMouseButton(0))
        {
            Gizmos.color = Color.blue;

            // 飛ぶ方向
            Vector2 endPos = Input.mousePosition;
            Vector3 dir = new Vector3(startPos.x - endPos.x, startPos.y - endPos.y, 0);
            Gizmos.DrawRay(transform.position, dir.normalized*3);
        }
    }

}
