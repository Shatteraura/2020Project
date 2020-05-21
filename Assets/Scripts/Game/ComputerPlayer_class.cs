using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum comSpriteEnum { High, Low, Side, Mid }

public class ComputerPlayer_class : MonoBehaviour
{
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
                this.GetComponent<SpriteRenderer>().color = Color.red;
                break;

            case false:
                this.GetComponent<SpriteRenderer>().color = Color.white;
                break;
        }
    }

    //Called From Button Script
    public void comUpdateSprite(int spriteNum)
    {
        this.GetComponent<SpriteRenderer>().sprite = comSprites[spriteNum];
    }
}
