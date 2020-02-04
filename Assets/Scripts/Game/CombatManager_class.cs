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

    public int playerNodeLock = 0;
    public int computerNodeLock = 0;

    public int bonusNumber = 0;
    public int bonusNumberLocation = 0;
    public int bonusNumberDice = 0;

    public bool reverseState = false;
    public bool singleLock = false;


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
    }

    //Handles single values and turn over
    void turnLogic()
    {
        if (singleLock == true)
        {
            playerNode = playerNodeEnum.noNode;
            computerNode = computerNodeEnum.noNode;
            bonusNumberDice = Random.Range(1, 100);
            singleLock = false;
        }
    }

    //Dictates where the bonus number appears, if at all
    void bonusNumberLogic()
    {
        if (bonusNumberDice < 40)
        {
            bonusNumberLocation = 0;
        }

        if (bonusNumberDice >= 40 && bonusNumberDice < 55)
        {
            bonusNumberLocation = 1;
        }

        if (bonusNumberDice >= 55 && bonusNumberDice < 70)
        {
            bonusNumberLocation = 2;
        }

        if (bonusNumberDice >= 70 && bonusNumberDice < 85)
        {
            bonusNumberLocation = 3;
        }

        if (bonusNumberDice >= 85 && bonusNumberDice <= 100)
        {
            bonusNumberLocation = 4;
        }
    }

    //Dictates what buttons can be clicked based on the game rules
    void nodeButtonLogic()
    {

    }

    //The logic that states what beats what
    void nodeRelationLogic()
    {
        //If the game logic is normal
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



        //If the game logic is reversed 
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
}
