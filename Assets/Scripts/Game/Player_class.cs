using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerSpriteEnum { High, Low, Side, Mid, HighP, LowP, SideP, MidP }

public class Player_class : MonoBehaviour
{
    public CombatManager_class mRef;
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
                if (mRef.endTurnTimer < 100)
                {
                    this.GetComponent<SpriteRenderer>().color = Color.red;
                }
                break;

            case false:
                this.GetComponent<SpriteRenderer>().color = Color.white;
                break;
        }
    }

    //Called From Button Script
    public void playerUpdateSprite(int spriteNum)
    {
        if (mRef.endTurnTimer > 200)
        {
            this.GetComponent<SpriteRenderer>().sprite = playerSprites[spriteNum];
        }
        else if (mRef.endTurnTimer <= 200 && mRef.playerBonus == 0 && mRef.buttonMode == buttonModeEnum.attackMode)
        {
            this.GetComponent<SpriteRenderer>().sprite = playerSprites[spriteNum + 8];
        }
        else if (mRef.endTurnTimer <= 200 && mRef.playerBonus == 1 && mRef.buttonMode == buttonModeEnum.attackMode)
        {
            this.GetComponent<SpriteRenderer>().sprite = playerSprites[spriteNum + 4];
        }
    }
}
