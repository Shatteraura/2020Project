﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum playerNodeEnum { noNode, node1, node2, node3, node4 }
public enum computerNodeEnum { noNode, node1, node2, node3, node4 }
public enum buttonModeEnum { attackMode, defenceMode }

public class CombatManager_class : MonoBehaviour
{
    public playerNodeEnum playerNode;
    public computerNodeEnum computerNode;
    public buttonModeEnum buttonMode;

    public ComputerPlayer_class comRef;

    public int playerHealth = 5;
    public int computerHealth = 5;

    public int currentButton;
    public int comPrev;

    public int playerNodeLock = 0;
    public int comNodeLock = 0;

    public int comDice;
    public int comDefDice;

    public int playerBonus = 0;
    public int comBonus = 0;

    //public int endTurnTimer;

    public bool comDef = false;

    public bool reverseState = false;

    public bool singleLock = false;
    public bool singleLockCom = false;

    public Text PNodeTxt;
    public Text CNodeText;

    public Vector3 button1Pos;
    public Vector3 button2Pos;
    public Vector3 button3Pos;
    public Vector3 button4Pos;
    public Vector3 button5Pos;

    public Vector3 left;
    public Vector3 right;
    public Vector3 bottom;
    public Vector3 top;
    public Vector3 middle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnLogic();
        playerBonusLogic();
        nodeLogic();
        computerPlayerLogic();
        textDisplay();
    }

    //Handles single values and End Turn
    void turnLogic()
    {
        if (singleLock == true && singleLockCom == true)
        {
            playerNode = playerNodeEnum.noNode;
            currentButton = 0;
            comDef = false;
            singleLock = false;
            singleLockCom = false;
        }
    }

    //The bonus number is generated on a successful defence, this prevents it from getting too high
    void playerBonusLogic()
    {
        if (playerBonus > 1)
        {
            playerBonus = 0;
        }
    }

    void textDisplay()
    {
        //Current Player Node
        switch (currentButton)
        {
            case 1:
                if (buttonMode == buttonModeEnum.attackMode)
                {
                    PNodeTxt.text = "High Attack";
                }

                else
                {
                    PNodeTxt.text = "Defend High";
                }
                break;

            case 2:
                if (buttonMode == buttonModeEnum.attackMode)
                {
                    PNodeTxt.text = "Low Attack";
                }

                else
                {
                    PNodeTxt.text = "Defend Low";
                }
                break;

            case 3:
                if (buttonMode == buttonModeEnum.attackMode)
                {
                    PNodeTxt.text = "Side Attack";
                }

                else
                {
                    PNodeTxt.text = "Defend Side";
                }
                break;

            case 4:
                if (buttonMode == buttonModeEnum.attackMode)
                {
                    PNodeTxt.text = "Mid Attack";
                }

                else
                {
                    PNodeTxt.text = "Defend Mid";
                }
                break;
        }

        //Last Used Node by the computer!
        switch (comPrev)
        {
            case 1:
                comRef.comUpdateSprite(0);
                if (comDef == false)
                {
                    CNodeText.text = "High Attack";
                }

                else
                {
                    CNodeText.text = "Defend High";
                }
                break;

            case 2:
                comRef.comUpdateSprite(1);
                if (comDef == false)
                {
                    CNodeText.text = "Low Attack";
                }

                else
                {
                    CNodeText.text = "Defend Low";
                }
                break;

            case 3:
                comRef.comUpdateSprite(2);
                if (comDef == false)
                {
                    CNodeText.text = "Side Attack";
                }

                else
                {
                    CNodeText.text = "Defend Side";
                }
                break;

            case 4:
                comRef.comUpdateSprite(3);
                if (comDef == false)
                {
                    CNodeText.text = "Mid Attack";
                }

                else
                {
                    CNodeText.text = "Defend Mid";
                }
                break;
        }
    }

    //The logic that activates when a Node is clicked
    void nodeLogic()
    {
        if (reverseState == false && singleLock == false)
            {
                switch (buttonMode)
                {
                    case buttonModeEnum.attackMode:
                        attackLogic();
                        break;

                    case buttonModeEnum.defenceMode:
                        defenceLogic();
                        break;
                }
            }

        //Node functionality when the node outcomes are reversed
        if (reverseState == true && singleLock == false)
            {
                switch (buttonMode)
                {
                    case buttonModeEnum.attackMode:
                        reverseAttackLogic();
                        break;

                    case buttonModeEnum.defenceMode:
                        reverseDefenceLogic();
                        break;
                }
            }
    }

    //Logic for normal attacks - Checks to see if the computer is defending or not
    void attackLogic()
    {
        switch (comDef)
        {
            case false:
                if (playerNode == playerNodeEnum.node1)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node2:
                            computerHealth -= 1 + playerBonus;
                            break;

                        case computerNodeEnum.node3:
                            computerHealth -= 1 + playerBonus;
                            break;

                        case computerNodeEnum.node4:
                            playerHealth -= 1 + comBonus;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            playerHealth -= 1 + comBonus;
                            break;

                        case computerNodeEnum.node2:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node3:
                            computerHealth -= 1 + playerBonus;
                            break;

                        case computerNodeEnum.node4:
                            playerHealth -= 1 + comBonus;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            playerHealth -= 1 + comBonus;
                            break;

                        case computerNodeEnum.node2:
                            playerHealth -= 1 + comBonus;
                            break;

                        case computerNodeEnum.node3:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node4:
                            computerHealth -= 1 + playerBonus;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node4)
                {

                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            computerHealth -= 1 + playerBonus;
                            break;

                        case computerNodeEnum.node2:
                            computerHealth -= 1 + playerBonus;
                            break;

                        case computerNodeEnum.node3:
                            playerHealth -= 1 + comBonus;
                            break;

                        case computerNodeEnum.node4:
                            reverseState = true;
                            break;
                    }
                    singleLock = true;
                }
                break;

                //Computer is defending
            case true:
                if (playerNode == playerNodeEnum.node1)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node2:
                            comBonus += 1;
                            break;

                        case computerNodeEnum.node3:
                            break;

                        case computerNodeEnum.node4:
                            computerHealth -= playerBonus;
                            break;
                    }
                    singleLock = true;
                }


                if (playerNode == playerNodeEnum.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            computerHealth -= playerBonus;
                            break;

                        case computerNodeEnum.node2:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node3:
                            comBonus += 1;
                            break;

                        case computerNodeEnum.node4:
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            break;

                        case computerNodeEnum.node2:
                            computerHealth -= playerBonus;
                            break;

                        case computerNodeEnum.node3:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node4:
                            comBonus += 1;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node4)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            comBonus += 1;
                            break;

                        case computerNodeEnum.node2:
                            break;

                        case computerNodeEnum.node3:
                            computerHealth -= playerBonus;
                            break;

                        case computerNodeEnum.node4:
                            reverseState = true;
                            break;
                    }
                    singleLock = true;
                }
                break;
        }
    }

    //Logic for reversed attacks - Checks to see if the computer is defending or not
    void reverseAttackLogic()
    {
        switch (comDef)
        {
            case false:
                if (playerNode == playerNodeEnum.node1)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            reverseState = false;
                            break;

                        case computerNodeEnum.node2:
                            playerHealth -= 1 + comBonus;
                            break;

                        case computerNodeEnum.node3:
                            playerHealth -= 1 + comBonus;
                            break;

                        case computerNodeEnum.node4:
                            computerHealth -= 1 + playerBonus;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            computerHealth -= 1 + playerBonus;
                            break;

                        case computerNodeEnum.node2:
                            reverseState = false;
                            break;

                        case computerNodeEnum.node3:
                            playerHealth -= 1 + comBonus;
                            break;

                        case computerNodeEnum.node4:
                            computerHealth -= 1 + playerBonus;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            computerHealth -= 1 + playerBonus;
                            break;

                        case computerNodeEnum.node2:
                            computerHealth -= 1 + playerBonus;
                            break;

                        case computerNodeEnum.node3:
                            reverseState = false;
                            break;

                        case computerNodeEnum.node4:
                            playerHealth -= 1 + comBonus;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node4)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            playerHealth -= 1 + comBonus;
                            break;

                        case computerNodeEnum.node2:
                            playerHealth -= 1 + comBonus;
                            break;

                        case computerNodeEnum.node3:
                            computerHealth -= 1 + playerBonus;
                            break;

                        case computerNodeEnum.node4:
                            reverseState = false;
                            break;
                    }
                    singleLock = true;
                }
                break;

                //Computer is Defending
            case true:
                if (playerNode == playerNodeEnum.node1)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node2:
                            computerHealth -= playerBonus;
                            break;

                        case computerNodeEnum.node3:
                            break;

                        case computerNodeEnum.node4:
                            comBonus += 1;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            comBonus += 1;
                            break;

                        case computerNodeEnum.node2:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node3:
                            computerHealth -= playerBonus;
                            break;

                        case computerNodeEnum.node4:
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            break;

                        case computerNodeEnum.node2:
                            comBonus += 1;
                            break;

                        case computerNodeEnum.node3:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node4:
                            computerHealth -= playerBonus;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node4)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            computerHealth -= playerBonus;
                            break;

                        case computerNodeEnum.node2:
                            break;

                        case computerNodeEnum.node3:
                            comBonus += 1;
                            break;

                        case computerNodeEnum.node4:
                            reverseState = true;
                            break;
                    }
                    singleLock = true;
                }
                break;
        }
    }

    //Normal Defence Logic
    void defenceLogic()
    {
        switch (comDef)
        {
            case false:
                if (playerNode == playerNodeEnum.node1)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node2:
                            playerBonus += 1;
                            break;

                        case computerNodeEnum.node3:
                            break;

                        case computerNodeEnum.node4:
                            playerHealth -= comBonus;
                            break;
                    }
                    singleLock = true;
                }


                if (playerNode == playerNodeEnum.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            playerHealth -= comBonus;
                            break;

                        case computerNodeEnum.node2:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node3:
                            playerBonus += 1;
                            break;

                        case computerNodeEnum.node4:
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            break;

                        case computerNodeEnum.node2:
                            playerHealth -= comBonus;
                            break;

                        case computerNodeEnum.node3:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node4:
                            playerBonus += 1;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node4)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            playerBonus += 1;
                            break;

                        case computerNodeEnum.node2:
                            break;

                        case computerNodeEnum.node3:
                            playerHealth -= comBonus;
                            break;

                        case computerNodeEnum.node4:
                            reverseState = true;
                            break;
                    }
                    singleLock = true;
                }
                break;

            case true:
                if (playerNode != playerNodeEnum.noNode)
                {
                    singleLock = true;
                }
                break;
        }
    }

    //Reversed Defence logic
    void reverseDefenceLogic()
    {
        switch (comDef)
        {
            case false:
                if (playerNode == playerNodeEnum.node1)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node2:
                            playerHealth -= comBonus;
                            break;

                        case computerNodeEnum.node3:
                            break;

                        case computerNodeEnum.node4:
                            playerBonus += 1;
                            break;
                    }
                    singleLock = true;
                }


                if (playerNode == playerNodeEnum.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            playerBonus += 1;
                            break;

                        case computerNodeEnum.node2:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node3:
                            playerHealth -= comBonus;
                            break;

                        case computerNodeEnum.node4:
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            break;

                        case computerNodeEnum.node2:
                            playerBonus += 1;
                            break;

                        case computerNodeEnum.node3:
                            reverseState = true;
                            break;

                        case computerNodeEnum.node4:
                            playerHealth -= comBonus;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node4)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            playerHealth -= comBonus;
                            break;

                        case computerNodeEnum.node2:
                            break;

                        case computerNodeEnum.node3:
                            playerBonus += 1;
                            break;

                        case computerNodeEnum.node4:
                            reverseState = true;
                            break;
                    }
                    singleLock = true;
                }
                break;

            case true:
                if (playerNode != playerNodeEnum.noNode)
                {
                    singleLock = true;
                }
                break;
        }
    }

    //Picks a Node for the Computer Player and Governs Swtiching to Defence Mode
    void computerPlayerLogic()
    {
        if (singleLockCom == false)
        {

            comDefDice = Random.Range(1, 5);

            if (comDefDice > 3)
            {
                comDef = false;
            }

            else if (comDefDice <= 3)
            {
                comDef = true;
            }

            switch (computerNode)
            {
                case computerNodeEnum.noNode:
                    comDice = Random.Range(1, 5);
                    break;

                case computerNodeEnum.node1:
                    comDice = Random.Range(1, 4);

                    if (comDice == 1)
                    {
                        comDice++;
                    }
                    break;

                case computerNodeEnum.node2:
                    comDice = Random.Range(1, 4);

                    if (comDice == 2)
                    {
                        comDice++;
                    }
                    break;

                case computerNodeEnum.node3:
                    comDice = Random.Range(1, 4);

                    if (comDice == 3)
                    {
                        comDice++;
                    }
                    break;

                case computerNodeEnum.node4:
                    comDice = Random.Range(1, 4);
                    break;
            }
            singleLockCom = true;

            //Once the computer makes a desision this sets the choice
            switch (comDice)
            {
                case 1:
                    computerNode = computerNodeEnum.node1;
                    comPrev = 1;
                    break;

                case 2:
                    computerNode = computerNodeEnum.node2;
                    comPrev = 2;
                    break;

                case 3:
                    computerNode = computerNodeEnum.node3;
                    comPrev = 3;
                    break;

                case 4:
                    computerNode = computerNodeEnum.node4;
                    comPrev = 4;
                    break;
            }

        }
        
    }
}
