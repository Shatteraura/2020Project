using System.Collections;
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
    public Player_class playerRef;

    public int playerHealth = 10;
    public int computerHealth = 10;

    public int currentButton;

    public int comPrev;

    public int playerNodeLock = 0;

    public int comDice;
    public int comDefDice;
    public int cNodePick;

    public int playerBonus = 0;
    public int comBonus = 0;
    public int pBCount = 0;
    public int cBCount = 0;

    public int endTurnTimer = 300;

    public bool comDef = false;

    public bool reverseState = false;

    public bool singleLock = false;
    public bool singleLockCom = false;

    public Text PNodeTxt;
    public Text CNodeText;
    public Text modeButtonText;
    public Text cLockText;
    public Text reverseText;
    public Text actionText;

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
        turnTimeout();
        nodeLogic();
        computerPlayerLogic();
        textDisplay();
    }

    //Resets single values at the end of a turn
    void turnLogic()
    {
        if (singleLock == true && singleLockCom == true && endTurnTimer <= 0)
        {
            playerNode = playerNodeEnum.noNode;
            bonusReset();
            endTurnTimer = 300;
            comDef = false;
            singleLock = false;
            singleLockCom = false;
            CNodeText.text = "";
            comRef.damageRed = false;
            playerRef.damageRed = false;
            actionText.color = Color.white;
            actionText.text = "";
        }
    }

    //Governs actions taking place duing the turn timer also shows what the computer decided to do
    void turnTimeout()
    {
        if (singleLock == true && singleLockCom == true && endTurnTimer > 0)
        {
            endTurnTimer--;
            comTextDisplay();
            currentButton = 0;

            switch (comPrev)
            {
                case 1:
                    cLockText.text = "High";
                    break;

                case 2:
                    cLockText.text = "Low";
                    break;

                case 3:
                    cLockText.text = "Side";
                    break;

                case 4:
                    cLockText.text = "Mid";
                    break;
            }            
        }
    }

    //Makes sure the bonus numbers reset
    void bonusReset()
    {
        switch (playerBonus)
        {
            case 0:
                pBCount = 0;
                break;

           case 1:
                pBCount++;
                if (pBCount == 2)
                {
                    playerBonus = 0;
                }
                break;
        }

        switch (comBonus)
        {
            case 0:
                cBCount = 0;
                break;

            case 1:
                cBCount++;
                if (cBCount == 2)
                {
                    comBonus = 0;
                }
                break;
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

    }

    //Node in use by the computer --- During turn timer --- Governs Sprites and text
    void comTextDisplay ()
    {
        switch (comPrev)
        {
            case 1:
                if (comBonus == 0)
                {
                    comRef.comUpdateSprite(0);
                }
                else
                {
                    comRef.comUpdateSprite(4);
                }
                
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
                if (comBonus == 0)
                {
                    comRef.comUpdateSprite(1);
                }
                else
                {
                    comRef.comUpdateSprite(5);
                }

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
                if (comBonus == 0)
                {
                    comRef.comUpdateSprite(2);
                }
                else
                {
                    comRef.comUpdateSprite(6);
                }

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
                if (comBonus == 0)
                {
                    comRef.comUpdateSprite(3);
                }
                else
                {
                    comRef.comUpdateSprite(7);
                }

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
        if (reverseState == false)
        {
            reverseText.text = "Normal";
        }
        else
        {
            reverseText.text = "Reverse";
        }

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
                            actionText.text = "BLOCK!";
                            break;

                        case computerNodeEnum.node2:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node3:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node4:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
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
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node2:
                            reverseState = true;
                            actionText.text = "BLOCK!";
                            break;

                        case computerNodeEnum.node3:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node4:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
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
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node2:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node3:
                            reverseState = true;
                            actionText.text = "BLOCK!";
                            break;

                        case computerNodeEnum.node4:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
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
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node2:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node3:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node4:
                            reverseState = true;
                            actionText.text = "BLOCK!";
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
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node2:
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node3:
                            computerHealth -= playerBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                comRef.damageRed = true;
                            }
                            break;

                        case computerNodeEnum.node4:
                            comBonus += 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
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
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnum.node2:
                            reverseState = true;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node3:
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node4:
                            computerHealth -= playerBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                comRef.damageRed = true;
                            }
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            computerHealth -= playerBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                comRef.damageRed = true;
                            }
                            break;

                        case computerNodeEnum.node2:
                            comBonus += 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnum.node3:
                            reverseState = true;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node4:
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node4)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node2:
                            computerHealth -= playerBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                comRef.damageRed = true;
                            }
                            break;

                        case computerNodeEnum.node3:
                            comBonus += 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnum.node4:
                            reverseState = true;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
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
                            actionText.text = "BLOCK!";
                            break;

                        case computerNodeEnum.node2:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node3:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node4:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
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
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node2:
                            reverseState = false;
                            actionText.text = "BLOCK!";
                            break;

                        case computerNodeEnum.node3:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node4:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
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
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node2:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node3:
                            reverseState = false;
                            actionText.text = "BLOCK!";
                            break;

                        case computerNodeEnum.node4:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
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
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node2:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node3:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node4:
                            reverseState = false;
                            actionText.text = "BLOCK!";
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
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node2:
                            comBonus += 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnum.node3:
                            computerHealth -= playerBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                comRef.damageRed = true;
                            }
                            break;

                        case computerNodeEnum.node4:
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node2:
                            reverseState = true;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node3:
                            comBonus += 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnum.node4:
                            computerHealth -= playerBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                comRef.damageRed = true;
                            }
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            computerHealth -= playerBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                comRef.damageRed = true;
                            }
                            break;

                        case computerNodeEnum.node2:
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node3:
                            reverseState = true;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node4:
                            comBonus += 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
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
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnum.node2:
                            computerHealth -= playerBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                comRef.damageRed = true;
                            }
                            break;

                        case computerNodeEnum.node3:
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnum.node4:
                            reverseState = true;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
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
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node2:
                            playerBonus += 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnum.node3:
                            playerHealth -= comBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                playerRef.damageRed = true;
                            }
                            break;

                        case computerNodeEnum.node4:
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;
                    }
                    singleLock = true;
                }


                if (playerNode == playerNodeEnum.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node2:
                            reverseState = true;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node3:
                            playerBonus += 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnum.node4:
                            playerHealth -= comBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                playerRef.damageRed = true;
                            }
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            playerHealth -= comBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                playerRef.damageRed = true;
                            }
                            break;

                        case computerNodeEnum.node2:
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node3:
                            reverseState = true;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node4:
                            playerBonus += 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
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
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnum.node2:
                            playerHealth -= comBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                playerRef.damageRed = true;
                            }
                            break;

                        case computerNodeEnum.node3:
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node4:
                            reverseState = true;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
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
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node2:
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node3:
                            playerHealth -= comBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                playerRef.damageRed = true;
                            }
                            break;

                        case computerNodeEnum.node4:
                            playerBonus += 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
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
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnum.node2:
                            reverseState = true;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node3:
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node4:
                            playerHealth -= comBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                playerRef.damageRed = true;
                            }
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            playerHealth -= comBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                playerRef.damageRed = true;
                            }
                            break;

                        case computerNodeEnum.node2:
                            playerBonus += 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnum.node3:
                            reverseState = true;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node4:
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;
                    }
                    singleLock = true;
                }

                if (playerNode == playerNodeEnum.node4)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnum.node1:
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnum.node2:
                            playerHealth -= comBonus;
                            if (playerBonus == 0)
                            {
                                actionText.color = Color.white;
                                actionText.text = "BLOCK!";
                            }
                            else
                            {
                                actionText.color = Color.blue;
                                actionText.text = "GRAZE!";
                                playerRef.damageRed = true;
                            }
                            break;

                        case computerNodeEnum.node3:
                            playerBonus += 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnum.node4:
                            reverseState = true;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
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
        //At the beginning of the game the computer selects a node at random
        if (singleLockCom == false && computerNode == computerNodeEnum.noNode)
        {
                comDice = Random.Range(1, 5);

                if (comDice == 1)
                {
                    computerNode = computerNodeEnum.node1;
                    comPrev = 1;
                }
                if (comDice == 2)
                {
                    computerNode = computerNodeEnum.node2;
                    comPrev = 2;
                }
                if (comDice == 3)
                {
                    computerNode = computerNodeEnum.node3;
                    comPrev = 3;
                }
                if (comDice == 4)
                {
                    computerNode = computerNodeEnum.node4;
                    comPrev = 4;
                }
                singleLockCom = true;
        }



        if (singleLockCom == false && computerNode != computerNodeEnum.noNode)
        {
            //Rolls the Node Dice
            comDice = Random.Range(1, 10);

            //Rolls the defense dice
            comDefDice = Random.Range(1, 11);

            if (reverseState == false)
            {
                switch(comPrev)
                {
                    case 1:

                        if (comDice >= 3)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false; 
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node2;
                            comPrev = 2;
                        }

                        else if (comDice >= 6)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node3;
                            comPrev = 3;
                        }

                        else if (comDice >= 9)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node4;
                            comPrev = 4;
                        }
                        break;

                    case 2:

                        if (comDice >= 3)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node1;
                            comPrev = 1;
                        }

                        else if (comDice >= 6)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node3;
                            comPrev = 3;
                        }

                        else if (comDice >= 9)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node4;
                            comPrev = 4;
                        }
                        break;

                    case 3:

                        if (comDice >= 3)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node1;
                            comPrev = 1;
                        }

                        else if (comDice >= 6)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node2;
                            comPrev = 2;
                        }

                        else if (comDice >= 9)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node4;
                            comPrev = 4;
                        }
                        break;

                    case 4:

                        if (comDice >= 3)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node1;
                            comPrev = 1;
                        }

                        else if (comDice >= 6)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node2;
                            comPrev = 2;
                        }

                        else if (comDice >= 9)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node3;
                            comPrev = 3;
                        }
                        break;
                }

                singleLockCom = true;

            }

            if (reverseState == true)
            {
                switch (comPrev)
                {
                    case 1:

                        if (comDice >= 3)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node2;
                            comPrev = 2;
                        }

                        else if (comDice >= 6)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node3;
                            comPrev = 3;
                        }

                        else if (comDice >= 9)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node4;
                            comPrev = 4;
                        }
                        break;

                    case 2:

                        if (comDice >= 3)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node1;
                            comPrev = 1;
                        }

                        else if (comDice >= 6)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node3;
                            comPrev = 3;
                        }

                        else if (comDice >= 9)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node4;
                            comPrev = 4;
                        }
                        break;

                    case 3:

                        if (comDice >= 3)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node1;
                            comPrev = 1;
                        }

                        else if (comDice >= 6)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node2;
                            comPrev = 2;
                        }

                        else if (comDice >= 9)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node4;
                            comPrev = 4;
                        }
                        break;

                    case 4:

                        if (comDice >= 3)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node1;
                            comPrev = 1;
                        }

                        else if (comDice >= 6)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node2;
                            comPrev = 2;
                        }

                        else if (comDice >= 9)
                        {
                            if (comDefDice >= 5)
                            {
                                comDef = false;
                            }
                            else
                            {
                                comDef = true;
                            }
                            computerNode = computerNodeEnum.node3;
                            comPrev = 3;
                        }
                        break;
                }

                singleLockCom = true;

            }

        }
        
    }
}
