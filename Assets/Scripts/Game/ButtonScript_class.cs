using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum buttonTypeEnum { none, high, low, side, mid }

public class ButtonScript_class : MonoBehaviour
{
    public CombatManager_class mRef;
    public Player_class playerRef;
    public SelectBoxScript_class selectRef;
    public buttonTypeEnum buttonType;

    public Sprite enemyButton;
    public Sprite normalButton;
    public Sprite[] lockedSprites;

    // Start is called before the first frame update
    void Start()
    {
        switch (buttonType)
        {
            case buttonTypeEnum.high:
                mRef.GetComponent<CombatManager_class>().button1Pos = this.transform.position;
                break;

            case buttonTypeEnum.low:
                mRef.GetComponent<CombatManager_class>().button2Pos = this.transform.position;
                break;

            case buttonTypeEnum.side:
                mRef.GetComponent<CombatManager_class>().button3Pos = this.transform.position;
                break;

            case buttonTypeEnum.mid:
                mRef.GetComponent<CombatManager_class>().button4Pos = this.transform.position;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyReactions();
        spriteUpdate(); 
    }

    //In between turns sprite update
    void spriteUpdate()
    {
        if (mRef.singleLock == true)
        {
            if (mRef.endTurnTimer > 0 && mRef.playerBonus == 0)
            {
                playerRef.playerUpdateSprite(mRef.playerNodeLock - 1);
            }
            else if (mRef.endTurnTimer > 0 && mRef.playerBonus == 1)
            {
                playerRef.playerUpdateSprite(mRef.playerNodeLock + 3);
            }
        }
    }

    //Changes the buttons to display the enemy reactions
    void enemyReactions()
    {
        switch (mRef.currentButton)
        {
            case 0:
                if ((int)buttonType != mRef.playerNodeLock)
                {
                    this.GetComponent<SpriteRenderer>().sprite = normalButton;
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().sprite = lockedSprites[0];
                }
                break;

            case 1:
                if (buttonType != buttonTypeEnum.high)
                {
                    this.GetComponent<SpriteRenderer>().sprite = enemyButton;
                }
                break;

            case 2:
                if (buttonType != buttonTypeEnum.low)
                {
                    this.GetComponent<SpriteRenderer>().sprite = enemyButton;
                }
                break;

            case 3:
                if (buttonType != buttonTypeEnum.side)
                {
                    this.GetComponent<SpriteRenderer>().sprite = enemyButton;
                }
                break;

            case 4:
                if (buttonType != buttonTypeEnum.mid)
                {
                    this.GetComponent<SpriteRenderer>().sprite = enemyButton;
                }
                break;
        }
    }


    //When a button is pressed, the combat manager takes note of which one it is, the selection boxes vanish and the button greys out
    private void OnMouseDown()
    {
        if (mRef.singleLock == false && mRef.currentButton != 0)
        {
            mRef.GetComponent<CombatManager_class>().playerNode = (playerNodeEnum)mRef.GetComponent<CombatManager_class>().currentButton;
            mRef.GetComponent<CombatManager_class>().playerNodeLock = (int)mRef.GetComponent<CombatManager_class>().playerNode;
            selectRef.buttonPos = new Vector3(100, 100, 1);

            switch (buttonType)
            {
                case buttonTypeEnum.high:
                    if (mRef.GetComponent<CombatManager_class>().playerNodeLock == 1)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = lockedSprites[0];
                    }
                    break;

                case buttonTypeEnum.low:
                    if (mRef.GetComponent<CombatManager_class>().playerNodeLock == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = lockedSprites[0];
                    }
                    break;

                case buttonTypeEnum.side:
                    if (mRef.GetComponent<CombatManager_class>().playerNodeLock == 3)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = lockedSprites[0];
                    }
                    break;

                case buttonTypeEnum.mid:
                    if (mRef.GetComponent<CombatManager_class>().playerNodeLock == 4)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = lockedSprites[0];
                    }
                    break;
            }
        }
    }

    private void OnMouseEnter()
    {
        //Mousing Over The Buttons

        if (mRef.singleLock == false)
        {
            switch (buttonType)
            {
                case buttonTypeEnum.high:
                    if (mRef.GetComponent<CombatManager_class>().playerNodeLock != 1)
                    {
                        if (mRef.GetComponent<CombatManager_class>().playerBonus == 0)
                        {
                            playerRef.playerUpdateSprite(0);
                        }
                        else
                        {
                            playerRef.playerUpdateSprite(4);
                        }
                        mRef.GetComponent<CombatManager_class>().currentButton = 1;
                        selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                    }
                    break;

                case buttonTypeEnum.low:
                    if (mRef.GetComponent<CombatManager_class>().playerNodeLock != 2)
                    {
                        if (mRef.GetComponent<CombatManager_class>().playerBonus == 0)
                        {
                            playerRef.playerUpdateSprite(1);
                        }
                        else
                        {
                            playerRef.playerUpdateSprite(5);
                        }
                        mRef.GetComponent<CombatManager_class>().currentButton = 2;
                        selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                    }
                    break;

                case buttonTypeEnum.side:
                    if (mRef.GetComponent<CombatManager_class>().playerNodeLock != 3)
                    {
                        if (mRef.GetComponent<CombatManager_class>().playerBonus == 0)
                        {
                            playerRef.playerUpdateSprite(2);
                        }
                        else
                        {
                            playerRef.playerUpdateSprite(6);
                        }
                        mRef.GetComponent<CombatManager_class>().currentButton = 3;
                        selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                    }
                    break;

                case buttonTypeEnum.mid:
                    if (mRef.GetComponent<CombatManager_class>().playerNodeLock != 4)
                    {
                        if (mRef.GetComponent<CombatManager_class>().playerBonus == 0)
                        {
                            playerRef.playerUpdateSprite(3);
                        }
                        else
                        {
                            playerRef.playerUpdateSprite(7);
                        }
                        mRef.GetComponent<CombatManager_class>().currentButton = 4;
                        selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                    }
                    break;
            }
        }
    }

    private void OnMouseExit()
    {
        //Mousing Away From The Buttons
        mRef.GetComponent<CombatManager_class>().currentButton = 0;
        selectRef.buttonPos = new Vector3(100, 100, 1);
    }
}
