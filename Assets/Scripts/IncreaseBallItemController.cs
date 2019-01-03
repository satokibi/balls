using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBallItemController : MonoBehaviour {

    public GameObject ballPrefab;
    private int increaseNum = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && increaseNum > 0)
        {
            increaseNum--;
            BallController.IncreaseBallNum();
            if(increaseNum <= 0)
                Destroy(gameObject);
        }
    }
}
