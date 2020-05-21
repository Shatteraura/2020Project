using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerSpriteEnum { High, Low, Side, Mid, HighP, LowP, SideP, MidP }

public class Player_class : MonoBehaviour
{
    public playerSpriteEnum SetSprite;
    public Sprite[] playerSprites;
    public bool damageRed = false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = playerSprites[(int)playerSpriteEnum.Mid];
    }

    // Update is called once per frame
    void Update()
    {
        flashRed();
    }

    void flashRed()
    {
        switch (damageRed)
        {
            case true:
                this.GetComponent<SpriteRenderer>().color = Color.red;
                break;

            case false:
                this.GetComponent<SpriteRenderer>().color = Color.white;
                break;
        }
    }

    //Called From Button Script
    public void playerUpdateSprite(int spriteNum)
    {
        this.GetComponent<SpriteRenderer>().sprite = playerSprites[spriteNum];
    }
}
