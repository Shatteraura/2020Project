using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum PlayerNodeEnumOLD { noNode, node1, node2, node3, node4 }
public enum computerNodeEnumOLD { noNode, node1, node2, node3, node4 }
public enum buttonModeEnumOLD { attackMode, defenceMode }

public class CombatManager_class : MonoBehaviour
{
    public PlayerNodeEnumOLD playerNode;
    public computerNodeEnumOLD computerNode;
    public buttonModeEnumOLD buttonMode;

    public ComputerPlayer_class comRef;
    public Player_class playerRef;
    public Victory_class vRef;
    public Defeat_class dRef;

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

    public int endTurnTimer = 300;

    public int endGameTimer = 150;

    public bool comDef = false;

    public bool reverseState = false;

    public bool singleLock = false;
    public bool singleLockCom = false;

    public bool playerWin = false;
    public bool playerLose = false;

    public Text PNodeTxt;
    public Text CNodeText;
    public Text modeButtonText;
    public Text cLockText;
    public Text reverseText;
    public Text actionText;
    public Text returnText;

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
        if (playerWin == false && playerLose == false)
        {
            turnLogic();
            turnTimeout();
            nodeLogic();
            computerPlayerLogic();
            textDisplay();
        }
        returnToTitle();
    }

    void returnToTitle()
    {
        if (playerWin == true && endGameTimer > 0 || playerLose == true && endGameTimer > 0)
        {
            endGameTimer--;
        }

        if (endGameTimer <= 0)
        {
            returnText.text = "Click anywhere to return to the menu!";

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
            }
        }
    }

    //Detects when the player or the computer reach 0 hp
    void endGame()
    {
        if (playerHealth <= 0)
        {
            playerLose = true;
            dRef.defeatDisplay();
        }

        if (computerHealth <= 0)
        {
            playerWin = true;
            vRef.victoryDisplay();
        }
    }

    //Resets single values at the end of a turn, ends the game if someones hp hits 0
    void turnLogic()
    {
        if (singleLock == true && singleLockCom == true && endTurnTimer <= 0)
        {
            endGame();
            playerNode = PlayerNodeEnumOLD.noNode;
            endTurnTimer = 300;
            comDef = false;
            singleLock = false;
            singleLockCom = false;
            CNodeText.text = "";
            comRef.damageRed = false;
            playerRef.damageRed = false;
            actionText.color = Color.white;
            actionText.text = "";

            if (comBonus == 0)
            {
                comRef.comUpdateSprite(comPrev - 1);
            }
            if (comBonus == 1)
            {
                comRef.comUpdateSprite(comPrev + 3);
            }
            
            if (playerBonus == 0)
            {
                playerRef.playerUpdateSprite(playerNodeLock - 1);
            }
            if (playerBonus == 1)
            {
                playerRef.playerUpdateSprite(playerNodeLock + 3);
            }
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

    void textDisplay()
    {
        //Current Player Node
        switch (currentButton)
        {
            case 1:
                if (buttonMode == buttonModeEnumOLD.attackMode)
                {
                    PNodeTxt.text = "High Attack";
                }

                else
                {
                    PNodeTxt.text = "Defend High";
                }
                break;

            case 2:
                if (buttonMode == buttonModeEnumOLD.attackMode)
                {
                    PNodeTxt.text = "Low Attack";
                }

                else
                {
                    PNodeTxt.text = "Defend Low";
                }
                break;

            case 3:
                if (buttonMode == buttonModeEnumOLD.attackMode)
                {
                    PNodeTxt.text = "Side Attack";
                }

                else
                {
                    PNodeTxt.text = "Defend Side";
                }
                break;

            case 4:
                if (buttonMode == buttonModeEnumOLD.attackMode)
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
                    comRef.comUpdateSprite(comPrev - 1);
                }
                else
                {
                    comRef.comUpdateSprite(comPrev + 3);
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
                    comRef.comUpdateSprite(comPrev - 1);
                }
                else
                {
                    comRef.comUpdateSprite(comPrev + 3);
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
                    comRef.comUpdateSprite(comPrev - 1);
                }
                else
                {
                    comRef.comUpdateSprite(comPrev + 3);
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
                    comRef.comUpdateSprite(comPrev - 1);
                }
                else
                {
                    comRef.comUpdateSprite(comPrev + 3);
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
                    case buttonModeEnumOLD.attackMode:
                        attackLogic();
                        break;

                    case buttonModeEnumOLD.defenceMode:
                        defenceLogic();
                        break;
                }
            }

        //Node functionality when the node outcomes are reversed
        if (reverseState == true && singleLock == false)
            {
                switch (buttonMode)
                {
                    case buttonModeEnumOLD.attackMode:
                        reverseAttackLogic();
                        break;

                    case buttonModeEnumOLD.defenceMode:
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
                if (playerNode == PlayerNodeEnumOLD.node1)
                {                  
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            actionText.text = "BLOCK!";
                            break;

                        case computerNodeEnumOLD.node2:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node3:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node4:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node2:
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            actionText.text = "BLOCK!";
                            break;

                        case computerNodeEnumOLD.node3:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node4:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node2:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node3:
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            actionText.text = "BLOCK!";
                            break;

                        case computerNodeEnumOLD.node4:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node4)
                {

                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node2:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node3:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node4:
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            actionText.text = "BLOCK!";
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }
                break;

                //Computer is defending
            case true:
                if (playerNode == PlayerNodeEnumOLD.node1)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            comBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node2:
                            comBonus = 0;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node3:
                            comBonus = 0;
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

                        case computerNodeEnumOLD.node4:
                            comBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    singleLock = true;
                }


                if (playerNode == PlayerNodeEnumOLD.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            comBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnumOLD.node2:
                            comBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node3:
                            comBonus = 0;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node4:
                            comBonus = 0;
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
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            comBonus = 0;
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

                        case computerNodeEnumOLD.node2:
                            comBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnumOLD.node3:
                            comBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node4:
                            comBonus = 0;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node4)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            comBonus = 0;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node2:
                            comBonus = 0;
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

                        case computerNodeEnumOLD.node3:
                            comBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnumOLD.node4:
                            comBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
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
                if (playerNode == PlayerNodeEnumOLD.node1)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            actionText.text = "BLOCK!";
                            break;

                        case computerNodeEnumOLD.node2:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node3:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node4:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node2:
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            actionText.text = "BLOCK!";
                            break;

                        case computerNodeEnumOLD.node3:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node4:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node2:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node3:
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            actionText.text = "BLOCK!";
                            break;

                        case computerNodeEnumOLD.node4:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node4)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node2:
                            playerHealth -= 1 + comBonus;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node3:
                            computerHealth -= 1 + playerBonus;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node4:
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            actionText.text = "BLOCK!";
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }
                break;

                //Computer is Defending
            case true:
                if (playerNode == PlayerNodeEnumOLD.node1)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            comBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node2:
                            comBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnumOLD.node3:
                            comBonus = 0;
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

                        case computerNodeEnumOLD.node4:
                            comBonus = 0;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            comBonus = 0;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node2:
                            comBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node3:
                            comBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnumOLD.node4:
                            comBonus = 0;
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
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            comBonus = 0;
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

                        case computerNodeEnumOLD.node2:
                            comBonus = 0;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node3:
                            comBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node4:
                            comBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node4)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            comBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnumOLD.node2:
                            comBonus = 0;
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

                        case computerNodeEnumOLD.node3:
                            comBonus = 0;
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;

                        case computerNodeEnumOLD.node4:
                            comBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            computerHealth -= playerBonus + 1;
                            comRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.green;
                            break;
                    }
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
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
                if (playerNode == PlayerNodeEnumOLD.node1)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            playerBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node2:
                            playerBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnumOLD.node3:
                            playerBonus = 0;
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

                        case computerNodeEnumOLD.node4:
                            playerBonus = 0;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }


                if (playerNode == PlayerNodeEnumOLD.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            playerBonus = 0;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node2:
                            playerBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node3:
                            playerBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnumOLD.node4:
                            playerBonus = 0;
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
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            playerBonus = 0;
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

                        case computerNodeEnumOLD.node2:
                            playerBonus = 0;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node3:
                            playerBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node4:
                            playerBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node4)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            playerBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnumOLD.node2:
                            playerBonus = 0;
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

                        case computerNodeEnumOLD.node3:
                            playerBonus = 0;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node4:
                            playerBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }
                break;

            case true:
                if (playerNode != PlayerNodeEnumOLD.noNode)
                {
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
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
                if (playerNode == PlayerNodeEnumOLD.node1)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            playerBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node2:
                            playerBonus = 0;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node3:
                            playerBonus = 0;
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

                        case computerNodeEnumOLD.node4:
                            playerBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }


                if (playerNode == PlayerNodeEnumOLD.node2)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            playerBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnumOLD.node2:
                            playerBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node3:
                            playerBonus = 0;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node4:
                            playerBonus = 0;
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
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node3)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            playerBonus = 0;
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

                        case computerNodeEnumOLD.node2:
                            playerBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnumOLD.node3:
                            playerBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node4:
                            playerBonus = 0;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }

                if (playerNode == PlayerNodeEnumOLD.node4)
                {
                    switch (computerNode)
                    {
                        case computerNodeEnumOLD.node1:
                            playerBonus = 0;
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;

                        case computerNodeEnumOLD.node2:
                            playerBonus = 0;
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

                        case computerNodeEnumOLD.node3:
                            playerBonus = 1;
                            actionText.text = "PARRY!";
                            actionText.color = Color.blue;
                            break;

                        case computerNodeEnumOLD.node4:
                            playerBonus = 0;
                            if (reverseState == true)
                            {
                                reverseState = false;
                            }
                            else
                            {
                                reverseState = true;
                            }
                            playerHealth -= comBonus + 1;
                            playerRef.damageRed = true;
                            actionText.text = "HIT!";
                            actionText.color = Color.red;
                            break;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }
                break;

            case true:
                if (playerNode != PlayerNodeEnumOLD.noNode)
                {
                    if (playerBonus == 1)
                    {
                        playerBonus = 0;
                    }
                    if (comBonus == 1)
                    {
                        comBonus = 0;
                    }
                    singleLock = true;
                }
                break;
        }
    }

    //Picks a Node for the Computer Player and Governs Swtiching to Defence Mode
    void computerPlayerLogic()
    {
        //At the beginning of the game the computer selects a node at random
        if (singleLockCom == false && computerNode == computerNodeEnumOLD.noNode)
        {
                comDice = Random.Range(1, 5);

                if (comDice == 1)
                {
                    computerNode = computerNodeEnumOLD.node1;
                    comPrev = 1;
                }
                if (comDice == 2)
                {
                    computerNode = computerNodeEnumOLD.node2;
                    comPrev = 2;
                }
                if (comDice == 3)
                {
                    computerNode = computerNodeEnumOLD.node3;
                    comPrev = 3;
                }
                if (comDice == 4)
                {
                    computerNode = computerNodeEnumOLD.node4;
                    comPrev = 4;
                }
                singleLockCom = true;
        }



        if (singleLockCom == false && computerNode != computerNodeEnumOLD.noNode)
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
                        //range 1 - 3
                        if (comDice <= 3)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node2;
                            comPrev = 2;
                        }
                        //range 4 - 6
                        else if (comDice <= 6)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node3;
                            comPrev = 3;
                        }
                        //range 7 - 9
                        else if (comDice <= 9)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node4;
                            comPrev = 4;
                        }
                        break;

                    case 2:

                        if (comDice <= 3)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node1;
                            comPrev = 1;
                        }

                        else if (comDice <= 6)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node3;
                            comPrev = 3;
                        }

                        else if (comDice <= 9)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node4;
                            comPrev = 4;
                        }
                        break;

                    case 3:

                        if (comDice <= 3)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node1;
                            comPrev = 1;
                        }

                        else if (comDice <= 6)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node2;
                            comPrev = 2;
                        }

                        else if (comDice <= 9)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node4;
                            comPrev = 4;
                        }
                        break;

                    case 4:

                        if (comDice <= 3)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node1;
                            comPrev = 1;
                        }

                        else if (comDice <= 6)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node2;
                            comPrev = 2;
                        }

                        else if (comDice <= 9)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node3;
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

                        if (comDice <= 3)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node2;
                            comPrev = 2;
                        }

                        else if (comDice <= 6)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node3;
                            comPrev = 3;
                        }

                        else if (comDice <= 9)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node4;
                            comPrev = 4;
                        }
                        break;

                    case 2:

                        if (comDice >= 3)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node1;
                            comPrev = 1;
                        }

                        else if (comDice <= 6)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node3;
                            comPrev = 3;
                        }

                        else if (comDice <= 9)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node4;
                            comPrev = 4;
                        }
                        break;

                    case 3:

                        if (comDice <= 3)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node1;
                            comPrev = 1;
                        }

                        else if (comDice <= 6)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node2;
                            comPrev = 2;
                        }

                        else if (comDice <= 9)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node4;
                            comPrev = 4;
                        }
                        break;

                    case 4:

                        if (comDice <= 3)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node1;
                            comPrev = 1;
                        }

                        else if (comDice <= 6)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node2;
                            comPrev = 2;
                        }

                        else if (comDice <= 9)
                        {
                            if (comDefDice >= 5 && comBonus == 0)
                            {
                                comDef = true;
                            }
                            else if (comDefDice < 5 || comBonus == 1)
                            {
                                comDef = false;
                            }
                            computerNode = computerNodeEnumOLD.node3;
                            comPrev = 3;
                        }
                        break;
                }

                singleLockCom = true;

            }

        }
        
    }
}
