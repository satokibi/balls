using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour {

    public GameObject blockPrefab;
    public GameObject increaseBallItemPrefab;

    private int width = 7;
    private int height = 9;
    private Vector3 firstBlockPos = new Vector3(-2.4f, 2.95f, 0);
    private float createProbability = 0.4f;
    	
	public void CreateBlocks(int turn)
    {
        // 左からか右からやで
        int rorl = 1;
        if(Random.value < 0.5f)
        {
            rorl = -1;
        }

        foreach(Transform child in transform){
            if(child.transform.position.y -0.8f < -2.5f)
            {
                Destroy(child.gameObject,3f);
                GameObject.Find("GameDirector").GetComponent<GameDirector>().GameOver();
            }
            child.transform.position = new Vector3(child.transform.position.x, child.transform.position.y - 0.8f,transform.position.z);
        }

        int increaseBallItemNum = 0;

        for (int i = 0; i < width; i++)
        {
            if (Random.value < createProbability) { 
                GameObject block = Instantiate(blockPrefab, new Vector3(firstBlockPos.x * rorl + (i * 0.8f * rorl), firstBlockPos.y, firstBlockPos.z), Quaternion.identity) as GameObject;
                block.GetComponent<BlockController>().setHp(decideHp(turn));
                block.transform.parent = transform;
            } else if (increaseBallItemNum == 0)
            {
                GameObject block = Instantiate(increaseBallItemPrefab, new Vector3(firstBlockPos.x * rorl + (i * 0.8f * rorl), firstBlockPos.y, firstBlockPos.z), Quaternion.identity) as GameObject;
                block.transform.parent = transform;
                increaseBallItemNum = 1;
            }
        }
    }

    private int decideHp(int turn)
    {
        int hp = turn;
        if (Random.value < 0.4f)
            hp = hp * 2;

        return hp;
    }
}
