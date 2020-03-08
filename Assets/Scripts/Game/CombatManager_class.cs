using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerNodeEnum { noNode, node1, node2, node3, node4 }
public enum computerNodeEnum { noNode, node1, node2, node3, node4 }
public enum buttonModeEnum { attackMode, defenceMode }
public enum computerModeEnum { attackMode, defenceMode }

public class CombatManager_class : MonoBehaviour
{
    public playerNodeEnum playerNode;
    public computerNodeEnum computerNode;
    public buttonModeEnum buttonMode;
    public computerModeEnum computerMode;

    public int playerHealth = 5;
    public int computerHealth = 5;

    public int currentButton;

    public int playerNodeLock = 0;

    public int comDice;

    public int playerBonus = 0;
    public int comBonus = 0;

    public bool reverseState = false;
    public bool singleLock = false;
    public bool singleLockCom = false;

    public Vector3 button1Pos;
    public Vector3 button2Pos;
    public Vector3 button3Pos;
    public Vector3 button4Pos;
    public Vector3 button5Pos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnLogic();
        playerBonusLogic();
        nodeButtonLogic();
        nodeLogic();
        computerPlayerLogic();
    }

    //Handles single values and End Turn
    void turnLogic()
    {
        if (singleLock == true && singleLockCom == true)
        {
            playerNode = playerNodeEnum.noNode;
            computerNode = computerNodeEnum.noNode;
            comDice = 0;
            currentButton = 0;
            singleLock = false;
            singleLockCom = false;
        }
    }

    //Rework In Progress, The bonus number is generated on a successful defence
    void playerBonusLogic()
    {
        if (playerBonus > 1)
        {
            playerBonus = 0;
        }
    }

    //Facilitates the clicking of the node buttons
    void nodeButtonLogic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (currentButton)
            {
                case 1:
                    playerNode = playerNodeEnum.node1;
                    break;

                case 2:
                    playerNode = playerNodeEnum.node2;
                    break;

                case 3:
                    playerNode = playerNodeEnum.node3;
                    break;

                case 4:
                    playerNode = playerNodeEnum.node4;
                    break;
            }
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

    //Logic for normal attacks
    void attackLogic()
    {
        if (playerNode == playerNodeEnum.node1)
        {
            playerNodeLock = 1;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    reverseState = true;
                    break;

                case computerNodeEnum.node2:
                    computerHealth -= 1 - playerBonus;
                    break;

                case computerNodeEnum.node3:
                    computerHealth -= 1 - playerBonus;
                    break;

                case computerNodeEnum.node4:
                    playerHealth -= 1 - comBonus;
                    break;
            }

            singleLock = true;
        }


        if (playerNode == playerNodeEnum.node2)
        {
            playerNodeLock = 2;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node2:
                    reverseState = true;
                    break;

                case computerNodeEnum.node3:
                    computerHealth -= 1 - playerBonus;
                    break;

                case computerNodeEnum.node4:
                    playerHealth -= 1 - comBonus;
                    break;
            }

            singleLock = true;
        }

        if (playerNode == playerNodeEnum.node3)
        {
            playerNodeLock = 3;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node2:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node3:
                    reverseState = true;
                    break;

                case computerNodeEnum.node4:
                    computerHealth -= 1 - playerBonus;
                    break;
            }

            singleLock = true;
        }

        if (playerNode == playerNodeEnum.node4)
        {
            playerNodeLock = 4;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    computerHealth -= 1 - playerBonus;
                    break;

                case computerNodeEnum.node2:
                    computerHealth -= 1 - playerBonus;
                    break;

                case computerNodeEnum.node3:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node4:
                    reverseState = true;
                    break;
            }

            singleLock = true;
        }
    }

    //Logic for reversed attacks
    void reverseAttackLogic()
    {
        if (playerNode == playerNodeEnum.node1)
        {
            playerNodeLock = 1;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    reverseState = false;
                    break;

                case computerNodeEnum.node2:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node3:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node4:
                    computerHealth -= 1 - playerBonus;
                    break;
            }

            singleLock = true;
        }

        if (playerNode == playerNodeEnum.node2)
        {
            playerNodeLock = 2;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    computerHealth -= 1 - playerBonus;
                    break;

                case computerNodeEnum.node2:
                    reverseState = false;
                    break;

                case computerNodeEnum.node3:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node4:
                    computerHealth -= 1 - playerBonus;
                    break;
            }

            singleLock = true;
        }

        if (playerNode == playerNodeEnum.node3)
        {
            playerNodeLock = 3;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    computerHealth -= 1 - playerBonus;
                    break;

                case computerNodeEnum.node2:
                    computerHealth -= 1 - playerBonus;
                    break;

                case computerNodeEnum.node3:
                    reverseState = false;
                    break;

                case computerNodeEnum.node4:
                    playerHealth -= 1 - comBonus;
                    break;
            }

            singleLock = true;
        }

        if (playerNode == playerNodeEnum.node4)
        {
            playerNodeLock = 4;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node2:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node3:
                    computerHealth -= 1 - playerBonus;
                    break;

                case computerNodeEnum.node4:
                    reverseState = false;
                    break;
            }

            singleLock = true;
        }
    }

    //Normal Defence Logic
    void defenceLogic()
    {
        if (playerNode == playerNodeEnum.node1)
        {
            playerNodeLock = 1;

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
                    playerHealth -= 1 - comBonus;
                    break;
            }

            singleLock = true;
        }


        if (playerNode == playerNodeEnum.node2)
        {
            playerNodeLock = 2;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node2:
                    reverseState = true;
                    break;

                case computerNodeEnum.node3:
                    playerBonus += 1;
                    break;

                case computerNodeEnum.node4:
                    playerHealth -= comBonus;
                    break;
            }

            singleLock = true;
        }

        if (playerNode == playerNodeEnum.node3)
        {
            playerNodeLock = 3;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    playerHealth -= comBonus;
                    break;

                case computerNodeEnum.node2:
                    playerHealth -= 1 - comBonus;
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
            playerNodeLock = 4;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    playerBonus += 1;
                    break;

                case computerNodeEnum.node2:
                    break;

                case computerNodeEnum.node3:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node4:
                    reverseState = true;
                    break;
            }

            singleLock = true;
        }
    }

    //Reversed Defence logic
    void reverseDefenceLogic()
    {
        if (playerNode == playerNodeEnum.node1)
        {
            playerNodeLock = 1;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    reverseState = true;
                    break;

                case computerNodeEnum.node2:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node3:
                    playerHealth -= comBonus;
                    break;

                case computerNodeEnum.node4:
                    playerBonus += 1;
                    break;
            }

            singleLock = true;
        }


        if (playerNode == playerNodeEnum.node2)
        {
            playerNodeLock = 2;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    playerBonus += 1;
                    break;

                case computerNodeEnum.node2:
                    reverseState = true;
                    break;

                case computerNodeEnum.node3:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node4:
                    break;
            }

            singleLock = true;
        }

        if (playerNode == playerNodeEnum.node3)
        {
            playerNodeLock = 3;

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
                    playerHealth -= 1 - comBonus;
                    break;
            }

            singleLock = true;
        }

        if (playerNode == playerNodeEnum.node4)
        {
            playerNodeLock = 4;

            switch (computerNode)
            {
                case computerNodeEnum.node1:
                    playerHealth -= 1 - comBonus;
                    break;

                case computerNodeEnum.node2:
                    playerHealth -= comBonus;
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
    }

    //Picks a Node for the Computer Player
    void computerPlayerLogic()
    {
        if (singleLockCom == false)
        {
            switch (computerNode)
            {
                case computerNodeEnum.noNode:
                    comDice = Random.Range(1, 5);
                    singleLockCom = true;
                    break;

                case computerNodeEnum.node1:
                    comDice = Random.Range(1, 4);

                    if (comDice >= 1)
                    {
                        comDice++;
                    }
                    singleLockCom = true;
                    break;

                case computerNodeEnum.node2:
                    comDice = Random.Range(1, 4);

                    if (comDice >= 2)
                    {
                        comDice++;
                    }

                    singleLockCom = true;
                    break;

                case computerNodeEnum.node3:
                    comDice = Random.Range(1, 4);

                    if (comDice >= 3)
                    {
                        comDice++;
                    }

                    singleLockCom = true;
                    break;

                case computerNodeEnum.node4:
                    comDice = Random.Range(1, 4);

                    if (comDice >= 4)
                    {
                        comDice++;
                    }

                    singleLockCom = true;
                    break;
            }

        }

        //Once the computer makes a desision this sets the choice
        switch (comDice)
        {
            case 1:
                computerNode = computerNodeEnum.node1;
                break;

            case 2:
                computerNode = computerNodeEnum.node2;
                break;

            case 3:
                computerNode = computerNodeEnum.node3;
                break;

            case 4:
                computerNode = computerNodeEnum.node4;
                break;
        }
    }
}
