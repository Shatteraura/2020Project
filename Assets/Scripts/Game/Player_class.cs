using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerSpriteEnum { High, Low, Side, Mid, EnumEnd }

public class Player_class : MonoBehaviour
{
    public playerSpriteEnum SetSprite;
    public Sprite[] playerSprites;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = playerSprites[(int)playerSpriteEnum.Mid];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerUpdateSprite(int spriteNum)
    {
        this.GetComponent<SpriteRenderer>().sprite = playerSprites[spriteNum];
    }
}
