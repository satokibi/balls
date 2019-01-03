using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockController : MonoBehaviour {

    private int hp = 1;
    private Text hpText;

    private void Awake()
    {
        hpText = gameObject.transform.Find("Canvas/blockHp").gameObject.GetComponent<Text>();
    }

    public void setHp(int hp)
    {
        this.hp = hp;
        hpText.text = hp.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hp -= 1;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        hpText.text = hp.ToString();
    }
}
