﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript_class : MonoBehaviour
{
    public CombatManager_class mRef;
    public Player_class playerRef;
    public SelectBoxScript_class selectRef;

    public int buttonNum;

    public Sprite enemyButton;
    public Sprite normalButton;
    public Sprite[] lockedSprites;

    // Start is called before the first frame update
    void Start()
    {
        switch (buttonNum)
        {
            case 1:
                mRef.GetComponent<CombatManager_class>().button1Pos = this.transform.position;
                break;

            case 2:
                mRef.GetComponent<CombatManager_class>().button2Pos = this.transform.position;
                break;

            case 3:
                mRef.GetComponent<CombatManager_class>().button3Pos = this.transform.position;
                break;

            case 4:
                mRef.GetComponent<CombatManager_class>().button4Pos = this.transform.position;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mRef.singleLock == false)
        {
            buttonChange();            
        }
        buttonLock();
    }

    //Changes the button sprites for the 3 other buttons
    void buttonChange()
    {
        if (mRef.GetComponent<CombatManager_class>().currentButton != 0 && mRef.GetComponent<CombatManager_class>().currentButton != buttonNum)
        {
            this.GetComponent<SpriteRenderer>().sprite = enemyButton;
        }

        if (mRef.GetComponent<CombatManager_class>().currentButton == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = normalButton;
        }
    }

    void buttonLock()
    {
        switch (mRef.playerNodeLock)
        {
            case 1:
                if (buttonNum == 1)
                {
                    this.GetComponent<SpriteRenderer>().sprite = lockedSprites[0];
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().sprite = normalButton;
                }
                break;

            case 2:
                if (buttonNum == 2)
                {
                    this.GetComponent<SpriteRenderer>().sprite = lockedSprites[0];
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().sprite = normalButton;
                }
                break;

            case 3:
                if (buttonNum == 3)
                {
                    this.GetComponent<SpriteRenderer>().sprite = lockedSprites[0];
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().sprite = normalButton;
                }
                break;

            case 4:
                if (buttonNum == 4)
                {
                    this.GetComponent<SpriteRenderer>().sprite = lockedSprites[0];
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().sprite = normalButton;
                }
                break;
        }
    }

    //This allows the buttons to be pressed, moving the selection box away and setting the current button in the combat manager
    private void OnMouseDown()
    {
        if (mRef.singleLock == false)
        {
            mRef.GetComponent<CombatManager_class>().playerNode = (playerNodeEnum)mRef.GetComponent<CombatManager_class>().currentButton;
            mRef.GetComponent<CombatManager_class>().playerNodeLock = (int)mRef.GetComponent<CombatManager_class>().playerNode;

            switch (buttonNum)
            {
                case 1:
                    selectRef.buttonPos = new Vector3(100, 100, 1);
                    break;

                case 2:
                    selectRef.buttonPos = new Vector3(100, 100, 1);
                    break;

                case 3:
                    selectRef.buttonPos = new Vector3(100, 100, 1);
                    break;

                case 4:
                    selectRef.buttonPos = new Vector3(100, 100, 1);
                    break;
            }
        }
    }

    private void OnMouseEnter()
    {
        //Mousing Over The Buttons

        if (mRef.singleLock == false)
        {
            switch (buttonNum)
            {
                case 1:
                    if (mRef.GetComponent<CombatManager_class>().playerNodeLock != 1)
                    {
                        playerRef.playerUpdateSprite(0);
                        mRef.GetComponent<CombatManager_class>().currentButton = 1;
                        selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                    }
                    break;

                case 2:
                    if (mRef.GetComponent<CombatManager_class>().playerNodeLock != 2)
                    {
                        playerRef.playerUpdateSprite(1);
                        mRef.GetComponent<CombatManager_class>().currentButton = 2;
                        selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                    }
                    break;

                case 3:
                    if (mRef.GetComponent<CombatManager_class>().playerNodeLock != 3)
                    {
                        playerRef.playerUpdateSprite(2);
                        mRef.GetComponent<CombatManager_class>().currentButton = 3;
                        selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                    }
                    break;

                case 4:
                    if (mRef.GetComponent<CombatManager_class>().playerNodeLock != 4)
                    {
                        playerRef.playerUpdateSprite(3);
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
        switch (buttonNum)
        {
            case 1:
                mRef.GetComponent<CombatManager_class>().currentButton = 0;
                selectRef.buttonPos = new Vector3(100, 100, 1);
                break;

            case 2:
                mRef.GetComponent<CombatManager_class>().currentButton = 0;
                selectRef.buttonPos = new Vector3(100, 100, 1);
                break;

            case 3:
                mRef.GetComponent<CombatManager_class>().currentButton = 0;
                selectRef.buttonPos = new Vector3(100, 100, 1);
                break;

            case 4:
                mRef.GetComponent<CombatManager_class>().currentButton = 0;
                selectRef.buttonPos = new Vector3(100, 100, 1);
                break;
        }
    }
}
