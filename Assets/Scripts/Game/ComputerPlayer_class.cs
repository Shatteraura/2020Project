using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum comSpriteEnum { Mid, High, Side, Low, EnumEnd }

public class ComputerPlayer_class : MonoBehaviour
{
    public comSpriteEnum SetSprite;
    public Sprite[] comSprites;
    //public Sprite[] comSprites = new Sprite[(int)SpriteEnum.EnumEnd];

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = comSprites[(int)comSpriteEnum.Mid];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
