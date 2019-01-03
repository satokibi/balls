using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour {

    private GameObject ballNum;
    private GameObject turnNum;

    private GameObject wallSouth;
    private int turn = 0;
    private float checkBallNumInterval = 0.2f;
    private float timer = 0.0f;
    private bool Gaming;

    // Use this for initialization
    void Start () {
        ballNum = GameObject.Find("BallNum");
        turnNum = GameObject.Find("TurnNum");
        wallSouth = GameObject.Find("WallSouth");

        setTurn();
        Gaming = true;
	}

    void Update()
    {
        ballNum.GetComponent<Text>().text = "ball:  "+BallController.GetBallNum().ToString();

        // nextTurn
        if (BallController.GetIsMoving() == true && Gaming == true)
        {
            timer += Time.deltaTime;
            if (timer > checkBallNumInterval)
            {
                if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
                {
                    setTurn();
                }
            }
        } else
        {
            timer = 0;
        }
    }

    void setTurn()
    {
        turn++;
        GameObject.Find("BallGenerator").GetComponent<BallGenerator>().setPos(wallSouth.GetComponent<WallSouthController>().GetSetPos());
        GameObject.Find("BlockGenerator").GetComponent<BlockGenerator>().CreateBlocks(turn);
        BallController.SetIsMoving(false);
        turnNum.GetComponent<Text>().text = "turn: "+turn.ToString();
    }

    public void GameOver()
    {
        Gaming = false;
        Debug.Log("GameOver");
        SceneManager.LoadScene("GameScene");
    }

    public bool GetGaming()
    {
        return Gaming;
    }
}
