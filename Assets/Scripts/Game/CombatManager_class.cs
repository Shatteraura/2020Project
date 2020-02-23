using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerNodeEnum { noNode, node1, node2, node3, node4 }
public enum computerNodeEnum { noNode, node1, node2, node3, node4 }

public class CombatManager_class : MonoBehaviour
{
    public playerNodeEnum playerNode;
    public computerNodeEnum computerNode;

    public int playerHealth = 5;
    public int computerHealth = 5;

    public int currentButton;

    public int playerNodeLock = 0;
    public int computerNodeLock = 0;

    public int comDice;

    public int bonusNumber = 0;
    public int bonusNumberLocation = 0;
    public int bonusNumberDice = 0;

    public bool reverseState = false;
    public bool singleLock = false;
    public bool singleLockCom = false;

    public Vector3 button1Pos;
    public Vector3 button2Pos;
    public Vector3 button3Pos;
    public Vector3 button4Pos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnLogic();
        bonusNumberLogic();
        nodeButtonLogic();
        nodeRelationLogic();
        computerPlayerLogic();
    }

    //Handles single values and End Turn
    void turnLogic()
    {
        if (singleLock == true && singleLockCom == true)
        {
            playerNode = playerNodeEnum.noNode;
            computerNode = computerNodeEnum.noNode;
            bonusNumberDice = Random.Range(1, 100);
            comDice = 0;
            singleLock = false;
            singleLockCom = false;
        }
    }

    //Dictates where the bonus number appears, if at all
    void bonusNumberLogic()
    {
        if (bonusNumberDice < 40)
        {
            bonusNumberLocation = 0;
            bonusNumber = 0;
        }

        else if (bonusNumberDice < 55)
        {
            bonusNumberLocation = 1;
            bonusNumber = -1;
        }

        else if (bonusNumberDice < 70)
        {
            bonusNumberLocation = 2;
            bonusNumber = -1;
        }

        else if (bonusNumberDice < 85)
        {
            bonusNumberLocation = 3;
            bonusNumber = -1;
        }

        else if (bonusNumberDice <= 100)
        {
            bonusNumberLocation = 4;
            bonusNumber = -1;
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
    void nodeRelationLogic()
    {
        if (reverseState == false)
        {

            if (playerNode == playerNodeEnum.node1 && singleLock == false)
            {
                playerNodeLock = 1;

                switch (computerNode)
                {
                    case computerNodeEnum.node1:
                        reverseState = true;
                        computerNodeLock = 1;
                        break;

                    case computerNodeEnum.node2:
                        computerHealth -= 1 - bonusNumber;
                        computerNodeLock = 2;
                        break;

                    case computerNodeEnum.node3:
                        computerHealth -= 1 - bonusNumber;
                        computerNodeLock = 3;
                        break;

                    case computerNodeEnum.node4:
                        playerHealth -= 1 - bonusNumber;
                        computerNodeLock = 4;
                        break;
                    default:
                        return;
                }

                singleLock = true;
            }


            if (playerNode == playerNodeEnum.node2 && singleLock == false)
            {
                playerNodeLock = 2;

                switch (computerNode)
                {
                    case computerNodeEnum.node1:
                        playerHealth -= 1 - bonusNumber;
                        computerNodeLock = 1;
                        break;

                    case computerNodeEnum.node2:
                        reverseState = true;
                        computerNodeLock = 2;
                        break;

                    case computerNodeEnum.node3:
                        computerHealth -= 1 - bonusNumber;
                        computerNodeLock = 3;
                        break;

                    case computerNodeEnum.node4:
                        playerHealth -= 1 - bonusNumber;
                        computerNodeLock = 4;
                        break;
                    default:
                        return;
                }

                singleLock = true;
            }

            if (playerNode == playerNodeEnum.node3 && singleLock == false)
            {
                playerNodeLock = 3;

                switch (computerNode)
                {
                    case computerNodeEnum.node1:
                        playerHealth -= 1 - bonusNumber;
                        computerNodeLock = 1;
                        break;

                    case computerNodeEnum.node2:
                        playerHealth -= 1 - bonusNumber;
                        computerNodeLock = 2;
                        break;

                    case computerNodeEnum.node3:
                        reverseState = true;
                        computerNodeLock = 3;
                        break;

                    case computerNodeEnum.node4:
                        computerHealth -= 1 - bonusNumber;
                        computerNodeLock = 4;
                        break;
                    default:
                        return;
                }

                singleLock = true;
            }

            if (playerNode == playerNodeEnum.node4 && singleLock == false)
            {
                playerNodeLock = 4;

                switch (computerNode)
                {
                    case computerNodeEnum.node1:
                        computerHealth -= 1 - bonusNumber;
                        computerNodeLock = 1;
                        break;

                    case computerNodeEnum.node2:
                        computerHealth -= 1 - bonusNumber;
                        computerNodeLock = 2;
                        break;

                    case computerNodeEnum.node3:
                        playerHealth -= 1 - bonusNumber;
                        computerNodeLock = 3;
                        break;

                    case computerNodeEnum.node4:
                        reverseState = true;
                        computerNodeLock = 4;
                        break;
                    default:
                        return;
                }

                singleLock = true;
            }
        }



        //Node functionality when the node outvomes are reversed
        if (reverseState == true)
        {
            if (playerNode == playerNodeEnum.node1 && singleLock == false)
            {
                playerNodeLock = 1;

                switch (computerNode)
                {
                    case computerNodeEnum.node1:
                        reverseState = false;
                        computerNodeLock = 1;
                        break;

                    case computerNodeEnum.node2:
                        playerHealth -= 1 - bonusNumber;
                        computerNodeLock = 2;
                        break;

                    case computerNodeEnum.node3:
                        playerHealth -= 1 - bonusNumber;
                        computerNodeLock = 3;
                        break;

                    case computerNodeEnum.node4:
                        computerHealth -= 1 - bonusNumber;
                        computerNodeLock = 4;
                        break;
                    default:
                        return;
                }

                singleLock = true;
            }

            if (playerNode == playerNodeEnum.node2 && singleLock == false)
            {
                playerNodeLock = 2;

                switch (computerNode)
                {
                    case computerNodeEnum.node1:
                        computerHealth -= 1 - bonusNumber;
                        computerNodeLock = 1;
                        break;

                    case computerNodeEnum.node2:
                        reverseState = false;
                        computerNodeLock = 2;
                        break;

                    case computerNodeEnum.node3:
                        playerHealth -= 1 - bonusNumber;
                        computerNodeLock = 3;
                        break;

                    case computerNodeEnum.node4:
                        computerHealth -= 1 - bonusNumber;
                        computerNodeLock = 4;
                        break;
                    default:
                        return;
                }

                singleLock = true;
            }

            if (playerNode == playerNodeEnum.node3 && singleLock == false)
            {
                playerNodeLock = 3;

                switch (computerNode)
                {
                    case computerNodeEnum.node1:
                        computerHealth -= 1 - bonusNumber;
                        computerNodeLock = 1;
                        break;

                    case computerNodeEnum.node2:
                        computerHealth -= 1 - bonusNumber;
                        computerNodeLock = 2;
                        break;

                    case computerNodeEnum.node3:
                        reverseState = false;
                        computerNodeLock = 3;
                        break;

                    case computerNodeEnum.node4:
                        playerHealth -= 1 - bonusNumber;
                        computerNodeLock = 4;
                        break;
                    default:
                        return;
                }

                singleLock = true;
            }

            if (playerNode == playerNodeEnum.node4 && singleLock == false)
            {
                playerNodeLock = 4;

                switch (computerNode)
                {
                    case computerNodeEnum.node1:
                        playerHealth -= 1 - bonusNumber;
                        computerNodeLock = 1;
                        break;

                    case computerNodeEnum.node2:
                        playerHealth -= 1 - bonusNumber;
                        computerNodeLock = 2;
                        break;

                    case computerNodeEnum.node3:
                        computerHealth -= 1 - bonusNumber;
                        computerNodeLock = 3;
                        break;

                    case computerNodeEnum.node4:
                        reverseState = false;
                        computerNodeLock = 4;
                        break;
                    default:
                        return;
                }

                singleLock = true;
            }
        }
    }

    //Picks a Node for the Computer Player
    void computerPlayerLogic()
    {
        if (singleLockCom == false)
        {
            switch (computerNodeLock)
            {
                case 0:
                    comDice = Random.Range(1, 5);
                    singleLockCom = true;
                    break;

                case 1:
                    comDice = Random.Range(1, 4);

                    if (comDice >= 1)
                    {
                        comDice++;
                    }
                    singleLockCom = true;
                    break;

                case 2:
                    comDice = Random.Range(1, 4);

                    if (comDice >= 2)
                    {
                        comDice++;
                    }

                    singleLockCom = true;
                    break;

                case 3:
                    comDice = Random.Range(1, 4);

                    if (comDice >= 3)
                    {
                        comDice++;
                    }

                    singleLockCom = true;
                    break;

                case 4:
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
