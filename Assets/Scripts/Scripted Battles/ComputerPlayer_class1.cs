using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer_class1 : MonoBehaviour
{
    public CombatManagerV2_class1 mRef;
    public comSpriteEnum SetSprite;
    public Sprite[] comSprites;
    public bool damageRed = false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = comSprites[(int)comSpriteEnum.Mid];
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

    //Called From Combat Manager
    public void comUpdateSprite(int spriteNum)
    {
        if (mRef.endTurnTimer > 200)
        {
            this.GetComponent<SpriteRenderer>().sprite = comSprites[spriteNum];
        }
        else if (mRef.endTurnTimer <= 200 && mRef.comBonus == 0 && mRef.comDef == false)
        {
            this.GetComponent<SpriteRenderer>().sprite = comSprites[spriteNum + 8];
        }
        else if (mRef.endTurnTimer <= 200 && mRef.comBonus == 1 && mRef.comDef == false)
        {
            this.GetComponent<SpriteRenderer>().sprite = comSprites[spriteNum + 4];
        }
    }
}
