using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum currentOpponentEnum { Tutorio, Duo, Trio, Win }

public class CombatManagerV2_class1 : MonoBehaviour
{
    public playerNodeEnum playerNode;
    public computerNodeEnum computerNode;
    public buttonModeEnum buttonMode;
    public modeComparisonEnum modeComparison;
    public resultListEnum resultList;
    public arrowKeepEnum arrowKeep;
    public arrowRecolourEnum arrowRecolour;
    public arrowChangePosEnum arrowChangePos;

    public currentOpponentEnum currentOpponent;

    public ComputerPlayer_class1 comRef;
    public Player_class1 playerRef;
    public Victory_class1 vRef;
    public Defeat_class1 dRef;
    public CrossArrow_class1 crossRef;
    public Reverse_class1 reverseRef;

    public int playerHealth = 5;
    public int computerHealth = 5;

    public int currentButton;

    public int comPrev;

    public int playerNodeLock = 0;

    public int comDice;
    public int comDefDice;
    public int cNodePick;

    public int newNode;

    public int low;
    public int med;
    public int high;

    public int defRange;

    public int playerBonus = 0;
    public int comBonus = 0;

    public int trioDice;

    public int endTurnTimer = 300;

    public int endGameTimer = 150;

    public int dialogueNum;
    public int dialogueChapter;

    public bool comDef = false;

    public bool reverseState = false;

    public bool singleLock = false;
    public bool singleLockCom = false;

    public bool playerWin = false;
    public bool playerLose = false;

    public bool dialogueLock;

    public bool defLock = true;

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

    public Vector3 comLife1;
    public Vector3 comLife2;
    public Vector3 comLife3;
    public Vector3 comLife4;
    public Vector3 comLife5;

    public Vector3 playerDialogue = new Vector3(-3, 1.5f, 0);
    public Vector3 comDialogue = new Vector3(3, 1.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        currentOpponent = currentOpponentEnum.Tutorio;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerWin == false && playerLose == false)
        {
            turnLogic();
            turnTimeout();
            textDisplay();
            if (currentOpponent == currentOpponentEnum.Tutorio)
            {
                tutorioNode();
            }
            if (currentOpponent == currentOpponentEnum.Duo)
            {
                duoNode();
                if (computerHealth == 0)
                {
                    dialogueLock = true;
                    dialogueChapter = 8;
                }
            }
            if (currentOpponent == currentOpponentEnum.Trio)
            {
                trioNode();
                if (computerHealth == 0)
                {
                    dialogueLock = true;
                    dialogueChapter = 11;
                }
            }
            dialogueSystem();

            if (singleLock == false)
            {
                modeCompare();
                nodeComparison();
            }
        }
        returnToTitle();
    }

    void dialogueSystem()
    {
        if (dialogueLock == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dialogueNum++;
            }
        }
    }

    void returnToTitle()
    {
        if (playerWin == true && endGameTimer > 0 || playerLose == true && endGameTimer > 0 && currentOpponent == currentOpponentEnum.Win)
        {
            endGameTimer--;
        }

        if (playerWin == true)
        {
            vRef.victoryDisplay();
        }

        if (endGameTimer <= 0 && playerWin == true)
        {
            returnText.text = "Click anywhere to continue!";

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Game", LoadSceneMode.Single);
            }
        }

        if (endGameTimer <= 0 && playerWin == false)
        {
            returnText.text = "Click anywhere to continue!";

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
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
    }

    //Resets single values at the end of a turn, ends the game if someones hp hits 0
    void turnLogic()
    {
        if (singleLock == true && singleLockCom == true && endTurnTimer <= 0)
        {
            endGame();
            playerNode = playerNodeEnum.noNode;
            endTurnTimer = 300;
            comDef = false;
            singleLock = false;
            singleLockCom = false;
            CNodeText.text = "";
            comRef.damageRed = false;
            playerRef.damageRed = false;
            actionText.color = Color.white;
            actionText.text = "";
            resultList = resultListEnum.none;
            arrowKeep = arrowKeepEnum.left;
            arrowRecolour = arrowRecolourEnum.white;
            arrowChangePos = arrowChangePosEnum.none;
            reverseRef.visible = false; 
            if (currentOpponent == currentOpponentEnum.Tutorio)
            {
                dialogueNum = 1;
                dialogueChapter++;
            }
            trioDice = Random.Range(1, 4);

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
        if (reverseState == false)
        {
            reverseText.text = "Normal";
        }
        else
        {
            reverseText.text = "Reverse";
        }

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
    void comTextDisplay()
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


    //Comparitor Section: Sets the values to be read by the logic section

    //Checks who is attacking and defending setting a flag for the next set of comparisons
    void modeCompare()
    {
        switch (buttonMode)
        {
            case buttonModeEnum.attackMode:
                switch (comDef)
                {
                    case false:
                        modeComparison = modeComparisonEnum.ATTATT;
                        break;

                    case true:
                        modeComparison = modeComparisonEnum.ATTDEF;
                        break;
                }
                break;

            case buttonModeEnum.defenceMode:
                switch (comDef)
                {
                    case false:
                        modeComparison = modeComparisonEnum.DEFATT;
                        break;

                    case true:
                        modeComparison = modeComparisonEnum.DEFDEF;
                        break;
                }
                break;
        }
    }

    // Looks at which node the player picked
    void nodeComparison()
    {
        switch (playerNode)
        {
            case playerNodeEnum.node1:
                node1Logic();
                break;

            case playerNodeEnum.node2:
                node2Logic();
                break;

            case playerNodeEnum.node3:
                node3Logic();
                break;

            case playerNodeEnum.node4:
                node4Logic();
                break;
        }
    }

    //Compares the nodes the computer and player picked alongside who is attacking and defending and moves forward to the outcome logic
    void node1Logic()
    {
        switch (computerNode)
        {
            case computerNodeEnum.node1:
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        attackDraw();
                        break;

                    case modeComparisonEnum.ATTDEF:
                        comHit();
                        break;

                    case modeComparisonEnum.DEFATT:
                        playerHit();
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;

            case computerNodeEnum.node2:
                arrowChangePos = arrowChangePosEnum.top;
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.right;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.left;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        break;

                    case modeComparisonEnum.ATTDEF:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.right;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.right;
                            arrowRecolour = arrowRecolourEnum.blue;
                            comParry();
                        }

                        break;

                    case modeComparisonEnum.DEFATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.up;
                            arrowRecolour = arrowRecolourEnum.blue;
                            playerParry();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.right;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;

            case computerNodeEnum.node3:
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.cross;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.cross;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        break;

                    case modeComparisonEnum.ATTDEF:
                        arrowKeep = arrowKeepEnum.cross;
                        comBlock();
                        break;

                    case modeComparisonEnum.DEFATT:
                        arrowKeep = arrowKeepEnum.cross;
                        playerBlock();
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;

            case computerNodeEnum.node4:
                arrowChangePos = arrowChangePosEnum.left;
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.up;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.down;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        break;

                    case modeComparisonEnum.ATTDEF:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.down;
                            arrowRecolour = arrowRecolourEnum.blue;
                            comParry();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.down;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        break;

                    case modeComparisonEnum.DEFATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.up;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.up;
                            arrowRecolour = arrowRecolourEnum.blue;
                            playerParry();
                        }
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;
        }
    }

    //Node 2
    void node2Logic()
    {
        switch (computerNode)
        {
            case computerNodeEnum.node1:
                arrowChangePos = arrowChangePosEnum.top;
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.right;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.left;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        break;

                    case modeComparisonEnum.ATTDEF:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.left;
                            arrowRecolour = arrowRecolourEnum.blue;
                            comParry();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.left;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        break;

                    case modeComparisonEnum.DEFATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.right;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.right;
                            arrowRecolour = arrowRecolourEnum.blue;
                            playerParry();
                        }
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;

            case computerNodeEnum.node2:
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        attackDraw();
                        break;

                    case modeComparisonEnum.ATTDEF:
                        comHit();
                        break;

                    case modeComparisonEnum.DEFATT:
                        playerHit();
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;

            case computerNodeEnum.node3:
                arrowChangePos = arrowChangePosEnum.right;
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.down;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.up;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        break;

                    case modeComparisonEnum.ATTDEF:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.down;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.down;
                            arrowRecolour = arrowRecolourEnum.blue;
                            comParry();
                        }
                        break;

                    case modeComparisonEnum.DEFATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.up;
                            arrowRecolour = arrowRecolourEnum.blue;
                            playerParry();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.up;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;

            case computerNodeEnum.node4:
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.cross;
                            arrowRecolour = arrowRecolourEnum.green;
                            playerHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.cross;
                            arrowRecolour = arrowRecolourEnum.red;
                            comHit();
                        }
                        break;

                    case modeComparisonEnum.ATTDEF:
                        arrowKeep = arrowKeepEnum.cross;
                        comBlock();
                        break;

                    case modeComparisonEnum.DEFATT:
                        arrowKeep = arrowKeepEnum.cross;
                        playerBlock();
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;
        }
    }

    //Node 3
    void node3Logic()
    {
        switch (computerNode)
        {
            case computerNodeEnum.node1:
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.cross;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.cross;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        break;

                    case modeComparisonEnum.ATTDEF:
                        arrowKeep = arrowKeepEnum.cross;
                        comBlock();
                        break;

                    case modeComparisonEnum.DEFATT:
                        arrowKeep = arrowKeepEnum.cross;
                        playerBlock();
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;

            case computerNodeEnum.node2:
                arrowChangePos = arrowChangePosEnum.right;
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.down;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.up;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        break;

                    case modeComparisonEnum.ATTDEF:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.up;
                            arrowRecolour = arrowRecolourEnum.blue;
                            comParry();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.up;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        break;

                    case modeComparisonEnum.DEFATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.down;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.down;
                            arrowRecolour = arrowRecolourEnum.blue;
                            playerParry();
                        }
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;

            case computerNodeEnum.node3:
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        attackDraw();
                        break;

                    case modeComparisonEnum.ATTDEF:
                        comBlock();
                        break;

                    case modeComparisonEnum.DEFATT:
                        playerBlock();
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;

            case computerNodeEnum.node4:
                arrowChangePos = arrowChangePosEnum.bottom;
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.left;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.right;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        break;

                    case modeComparisonEnum.ATTDEF:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.left;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.left;
                            arrowRecolour = arrowRecolourEnum.blue;
                            comParry();
                        }
                        break;

                    case modeComparisonEnum.DEFATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.right;
                            arrowRecolour = arrowRecolourEnum.blue;
                            playerParry();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.right;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;
        }
    }

    //Node 4
    void node4Logic()
    {
        switch (computerNode)
        {
            case computerNodeEnum.node1:
                arrowChangePos = arrowChangePosEnum.left;
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.up;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.down;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        break;

                    case modeComparisonEnum.ATTDEF:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.up;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.up;
                            arrowRecolour = arrowRecolourEnum.blue;
                            comParry();
                        }
                        break;

                    case modeComparisonEnum.DEFATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.down;
                            arrowRecolour = arrowRecolourEnum.blue;
                            playerParry();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.down;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }

                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;

            case computerNodeEnum.node2:
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.cross;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.cross;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        break;

                    case modeComparisonEnum.ATTDEF:
                        arrowKeep = arrowKeepEnum.cross;
                        comBlock();
                        break;

                    case modeComparisonEnum.DEFATT:
                        arrowKeep = arrowKeepEnum.cross;
                        playerBlock();
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;

            case computerNodeEnum.node3:
                arrowChangePos = arrowChangePosEnum.bottom;
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.left;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.right;
                            arrowRecolour = arrowRecolourEnum.red;
                            comHit();
                        }
                        break;

                    case modeComparisonEnum.ATTDEF:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.right;
                            arrowRecolour = arrowRecolourEnum.blue;
                            comParry();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.right;
                            arrowRecolour = arrowRecolourEnum.green;
                            comHit();
                        }
                        break;

                    case modeComparisonEnum.DEFATT:
                        if (reverseState == false)
                        {
                            arrowKeep = arrowKeepEnum.left;
                            arrowRecolour = arrowRecolourEnum.red;
                            playerHit();
                        }
                        else
                        {
                            arrowKeep = arrowKeepEnum.left;
                            arrowRecolour = arrowRecolourEnum.blue;
                            playerParry();
                        }
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;

            case computerNodeEnum.node4:
                switch (modeComparison)
                {
                    case modeComparisonEnum.ATTATT:
                        attackDraw();
                        break;

                    case modeComparisonEnum.ATTDEF:
                        comBlock();
                        break;

                    case modeComparisonEnum.DEFATT:
                        playerBlock();
                        break;

                    case modeComparisonEnum.DEFDEF:
                        reverseOnly();
                        break;
                }
                break;
        }
    }


    //Logic section, all possible logic for every outcome these are called once the combination of nodes and other variables are set

    //Computer Taking damage
    void comHit()
    {
        computerHealth -= 1 + playerBonus;
        comRef.damageRed = true;
        actionText.text = "HIT";
        actionText.color = Color.green;
        bonusReset();
        resultList = resultListEnum.comHit;
        singleLock = true;
    }

    //Player Taking Damage
    void playerHit()
    {
        playerHealth -= 1 + comBonus;
        playerRef.damageRed = true;
        actionText.text = "HIT!";
        actionText.color = Color.red;
        bonusReset();
        resultList = resultListEnum.playerHit;
        singleLock = true;
    }



    //Player attack vs Enemy attack same node
    void attackDraw()
    {
        reverseState = !reverseState;
        reverseRef.visible = true;
        actionText.color = Color.white;
        actionText.text = "BLOCK!";
        bonusReset();
        resultList = resultListEnum.attackDraw;
        singleLock = true;
    }



    //Player Attack Blocked by def or grazing though
    void comBlock()
    {
        computerHealth -= playerBonus;
        if (playerBonus == 0)
        {
            actionText.color = Color.white;
            actionText.text = "BLOCK!";
            resultList = resultListEnum.comBlock;
            arrowRecolour = arrowRecolourEnum.grey;
        }
        else
        {
            actionText.color = Color.blue;
            actionText.text = "GRAZE!";
            comRef.damageRed = true;
            resultList = resultListEnum.playerGraze;
            arrowRecolour = arrowRecolourEnum.blue;
        }
        bonusReset();
        singleLock = true;
    }

    //Player Defence Block --- Allows for graze damage
    void playerBlock()
    {
        playerHealth -= comBonus;
        if (comBonus == 0)
        {
            actionText.color = Color.white;
            actionText.text = "BLOCK!";
            resultList = resultListEnum.playerBlock;
            arrowRecolour = arrowRecolourEnum.grey;
        }
        else
        {
            actionText.color = Color.blue;
            actionText.text = "GRAZE!";
            playerRef.damageRed = true;
            resultList = resultListEnum.comGraze;
            arrowRecolour = arrowRecolourEnum.blue;
        }
        bonusReset();
        singleLock = true;
    }



    //Player Defense Win Parry
    void playerParry()
    {
        playerBonus = 1;
        actionText.text = "PARRY!";
        actionText.color = Color.blue;
        if (comBonus == 1)
        {
            comBonus = 0;
        }
        resultList = resultListEnum.playerParry;
        singleLock = true;
    }

    // Computer Parry
    void comParry()
    {
        comBonus = 1;
        actionText.text = "PARRY!";
        actionText.color = Color.blue;
        if (playerBonus == 1)
        {
            playerBonus = 0;
        }
        resultList = resultListEnum.comParry;
        singleLock = true;
    }




    //Just Reverse --- If both players defend on the same node
    void reverseOnly()
    {
        reverseState = !reverseState;
        reverseRef.visible = true;
        bonusReset();
        resultList = resultListEnum.justReverse;
        singleLock = true;
    }

    //Resets the bonus number unless it has just been aquired
    void bonusReset()
    {
        if (playerBonus == 1)
        {
            playerBonus = 0;
        }
        if (comBonus == 1)
        {
            comBonus = 0;
        }
    }



    //Tutorio's node picks

    void tutorioNode()
    {
        switch (dialogueChapter)
        {
            case 0:
                comPickNode1();
                break;

            case 1:
                comPickNode2();
                break;

            case 2:
                comPickNode4();
                break;

            case 3:
                comPickNode1();
                break;

            case 4:
                comPickNode3();
                break;
        }
    }


    //Duo's dual node pick

    void duoNode()
    {
        if (dialogueLock == false)
        {
            if (computerNode == computerNodeEnum.noNode)
            {
                comPickNode1();
            }

            if (comPrev == 1 && singleLockCom == false)
            {
                comPickNode3();
            }

            if (comPrev == 3 && singleLockCom == false)
            {
                comPickNode1();
            }
        }
    }


    //Trio's random three nodes

    void trioNode()
    {
        if (singleLockCom == false)
        {
            comDefDice = Random.Range(1, 3);
        }

        if (comDefDice == 1 && comBonus == 0)
        {
            comDef = true;
        }
        else
        {
            comDef = false;
        }

        if (trioDice == 1 && comPrev != 1 && singleLockCom == false)
        {
            comPickNode1();
        }
        else if (trioDice == 1 && comPrev == 1 && singleLockCom == false)
        {
            comPickNode2();
        }

        if (trioDice == 2 && comPrev != 2 && singleLockCom == false)
        {
            comPickNode2();
        }
        else if (trioDice == 2 && comPrev == 2 && singleLockCom == false)
        {
            comPickNode3();
        }

        if (trioDice == 3 && comPrev != 3 && singleLockCom == false)
        {
            comPickNode3();
        }
        else if (trioDice == 3 && comPrev == 3 && singleLockCom == false)
        {
            comPickNode1();
        }
    }

    //Computer Logic Results -----------------

    void comPickNode1()
    {
        computerNode = computerNodeEnum.node1;
        comPrev = 1;
        singleLockCom = true;
    }

    void comPickNode2()
    {
        computerNode = computerNodeEnum.node2;
        comPrev = 2;
        singleLockCom = true;
    }

    void comPickNode3()
    {
        computerNode = computerNodeEnum.node3;
        comPrev = 3;
        singleLockCom = true;
    }

    void comPickNode4()
    {
        computerNode = computerNodeEnum.node4;
        comPrev = 4;
        singleLockCom = true;
    }

}

