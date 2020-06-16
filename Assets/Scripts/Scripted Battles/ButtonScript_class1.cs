using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript_class1 : MonoBehaviour
{
    public CombatManagerV2_class1 mRef;
    public Player_class1 playerRef;
    public SelectBoxScript_class1 selectRef;
    public buttonTypeEnum buttonType;
    public CrossArrow_class1 crossRef;

    public arrowEnum arrowType;

    public Color keepArrowColor;

    public Sprite enemyButton;
    public Sprite normalButton;
    public Sprite[] lockedSprites;

    // Start is called before the first frame update
    void Start()
    {
        switch (buttonType)
        {
            case buttonTypeEnum.high:
                mRef.button1Pos = this.transform.position;
                break;

            case buttonTypeEnum.low:
                mRef.button2Pos = this.transform.position;
                break;

            case buttonTypeEnum.side:
                mRef.button3Pos = this.transform.position;
                break;

            case buttonTypeEnum.mid:
                mRef.button4Pos = this.transform.position;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mRef.playerLose == false && mRef.playerWin == false)
        {
            turnArrow();
            switch (mRef.singleLock)
            {
                case false:
                    enemyReactions();
                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    break;

                case true:
                    buttonHide();
                    spriteUpdate();
                    break;
            }
        }    
    }

    //In between turns sprite update
    void spriteUpdate()
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

    void buttonHide()
    {
        if ((int)buttonType != mRef.playerNodeLock && (int)buttonType != mRef.comPrev)
        {
            this.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 0.2f);
        }
    }


    //When a button is pressed, the combat manager takes note of which one it is, the selection boxes vanish and the button greys out
    private void OnMouseDown()
    {
        if (mRef.singleLock == false && mRef.currentButton != 0 && mRef.playerLose == false && mRef.playerWin == false && mRef.currentOpponent != currentOpponentEnum.Tutorio && mRef.dialogueLock == false)
        {
            mRef.playerNode = (playerNodeEnum)mRef.currentButton;
            mRef.playerNodeLock = (int)mRef.playerNode;

            switch (buttonType)
            {
                case buttonTypeEnum.high:
                    if (mRef.playerNodeLock == 1)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = lockedSprites[0];
                    }
                    break;

                case buttonTypeEnum.low:
                    if (mRef.playerNodeLock == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = lockedSprites[0];
                    }
                    break;

                case buttonTypeEnum.side:
                    if (mRef.playerNodeLock == 3)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = lockedSprites[0];
                    }
                    break;

                case buttonTypeEnum.mid:
                    if (mRef.playerNodeLock == 4)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = lockedSprites[0];
                    }
                    break;
            }
        }

        // Tutorial locked button order
        if (mRef.singleLock == false && mRef.currentButton != 0 && mRef.currentOpponent == currentOpponentEnum.Tutorio && mRef.dialogueLock == false)
        {
            if (mRef.dialogueChapter == 0)
            {
                mRef.buttonMode = buttonModeEnum.attackMode;
                mRef.playerNode = playerNodeEnum.node4;
                mRef.playerNodeLock = (int)mRef.playerNode;
            }
            if (mRef.dialogueChapter == 1)
            {
                mRef.buttonMode = buttonModeEnum.attackMode;
                mRef.playerNode = playerNodeEnum.node1;
                mRef.playerNodeLock = (int)mRef.playerNode;
            }
            if (mRef.dialogueChapter == 2)
            {
                mRef.buttonMode = buttonModeEnum.defenceMode;
                mRef.playerNode = playerNodeEnum.node2;
                mRef.playerNodeLock = (int)mRef.playerNode;
            }
            if (mRef.dialogueChapter == 3)
            {
                mRef.buttonMode = buttonModeEnum.defenceMode;
                mRef.playerNode = playerNodeEnum.node4;
                mRef.playerNodeLock = (int)mRef.playerNode;
            }
            if (mRef.dialogueChapter == 4)
            {
                mRef.buttonMode = buttonModeEnum.attackMode;
                mRef.playerNode = playerNodeEnum.node1;
                mRef.playerNodeLock = (int)mRef.playerNode;
            }
        }
    }

    private void OnMouseEnter()
    {
        //Mousing Over The Buttons

        if (mRef.singleLock == false && mRef.playerLose == false && mRef.playerWin == false && mRef.dialogueLock == false)
        {
            switch (buttonType)
            {
                case buttonTypeEnum.high:
                    if (mRef.playerNodeLock != 1)
                    {
                        highOver();

                        if (mRef.playerBonus == 0)
                        {
                            playerRef.playerUpdateSprite(0);
                        }
                        else
                        {
                            playerRef.playerUpdateSprite(4);
                        }
                        mRef.currentButton = 1;
                        selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                    }
                    break;

                case buttonTypeEnum.low:
                    if (mRef.playerNodeLock != 2)
                    {
                        lowOver();

                        if (mRef.playerBonus == 0)
                        {
                            playerRef.playerUpdateSprite(1);
                        }
                        else
                        {
                            playerRef.playerUpdateSprite(5);
                        }
                        mRef.currentButton = 2;
                        selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                    }
                    break;

                case buttonTypeEnum.side:
                    if (mRef.playerNodeLock != 3)
                    {
                        sideOver();

                        if (mRef.playerBonus == 0)
                        {
                            playerRef.playerUpdateSprite(2);
                        }
                        else
                        {
                            playerRef.playerUpdateSprite(6);
                        }
                        mRef.currentButton = 3;
                        selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                    }
                    break;

                case buttonTypeEnum.mid:
                    if (mRef.playerNodeLock != 4)
                    {
                        midOver();

                        if (mRef.playerBonus == 0)
                        {
                            playerRef.playerUpdateSprite(3);
                        }
                        else
                        {
                            playerRef.playerUpdateSprite(7);
                        }
                        mRef.currentButton = 4;
                        selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                    }
                    break;
            }
        }
    }

    private void OnMouseExit()
    {
        //Mousing Away From The Buttons
        mRef.currentButton = 0;
        selectRef.buttonPos = new Vector3(100, 100, 1);
    }


    void turnArrow()
    {
        if (mRef.currentButton == 0 && mRef.singleLock == false)
        {
            crossRef.crossSprite = crossEnum.None;
            crossRef.crossColor = Color.white;
        }
        if (mRef.singleLock == true && mRef.arrowKeep != arrowKeepEnum.cross)
        {
            crossRef.crossSprite = crossEnum.None;
            crossRef.crossColor = Color.white;
        }
    }


    //Governs displaying the arrows when mousing over the buttons
    void highOver()
    {
        if (mRef.buttonMode == buttonModeEnum.attackMode)
        {
            highAtt();
        }
        else
        {
            highDef();
        }
    }

    void highAtt()
    {
        if (mRef.reverseState == false)
        {
            crossRef.crossColor = Color.green;
            crossRef.crossSprite = crossEnum.SE;
        }
        else
        {
            crossRef.crossColor = Color.red;
            crossRef.crossSprite = crossEnum.NW;
        }
    }

    void highDef()
    {
        if (mRef.reverseState == false)
        {
            crossRef.crossColor = Color.grey;
            crossRef.crossSprite = crossEnum.NW;
        }
        else
        {
            crossRef.crossColor = Color.grey;
            crossRef.crossSprite = crossEnum.NW;
        }
    }


    // LOW ----------------------
    void lowOver()
    {
        if (mRef.buttonMode == buttonModeEnum.attackMode)
        {
            lowAtt();
        }
        else
        {
            lowDef();
        }
    }

    void lowAtt()
    {
        if (mRef.reverseState == false)
        {
            crossRef.crossColor = Color.red;
            crossRef.crossSprite = crossEnum.NE;
        }
        else
        {
            crossRef.crossColor = Color.green;
            crossRef.crossSprite = crossEnum.SW;
        }
    }

    void lowDef()
    {
        if (mRef.reverseState == false)
        {
            crossRef.crossColor = Color.grey;
            crossRef.crossSprite = crossEnum.NE;
        }
        else
        {
            crossRef.crossColor = Color.grey;
            crossRef.crossSprite = crossEnum.NE;
        }
    }


    //SIDE -----------------------------------------------
    void sideOver()
    {
        if (mRef.buttonMode == buttonModeEnum.attackMode)
        {
            sideAtt();
        }
        else
        {
            sideDef();
        }

    }

    void sideAtt()
    {
        if (mRef.reverseState == false)
        {
            crossRef.crossColor = Color.red;
            crossRef.crossSprite = crossEnum.SE;
        }
        else
        {
            crossRef.crossColor = Color.green;
            crossRef.crossSprite = crossEnum.NW;
        }
    }

    void sideDef()
    {
        if (mRef.reverseState == false)
        {
            crossRef.crossColor = Color.grey;
            crossRef.crossSprite = crossEnum.SE;
        }
        else
        {
            crossRef.crossColor = Color.grey;
            crossRef.crossSprite = crossEnum.SE;
        }
    }



    //MID -----------------------------------------------
    void midOver()
    {
        if (mRef.buttonMode == buttonModeEnum.attackMode)
        {
            midAtt();
        }
        else
        {
            midDef();
        }

    }

    void midAtt()
    {
        if (mRef.reverseState == false)
        {
            crossRef.crossColor = Color.green;
            crossRef.crossSprite = crossEnum.NE;
        }
        else
        {
            crossRef.crossColor = Color.red;
            crossRef.crossSprite = crossEnum.SW;
        }
    }

    void midDef()
    {
        if (mRef.reverseState == false)
        {
            crossRef.crossColor = Color.grey;
            crossRef.crossSprite = crossEnum.SW;
        }
        else
        {
            crossRef.crossColor = Color.grey;
            crossRef.crossSprite = crossEnum.SW;
        }
    }
}
