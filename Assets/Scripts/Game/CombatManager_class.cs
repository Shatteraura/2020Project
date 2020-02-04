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
    public int bonusNumber = 0;
    public int bonusNumberLocation = 0;

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
        nodeRelationLogic();
    }

    //Handles single values and turn over
    void turnLogic()
    {
        if (singleLock == true)
        {
            playerNode = playerNodeEnum.noNode;
            computerNode = computerNodeEnum.noNode;
            bonusNumberLocation = Random.Range(1, 100);
            singleLock = false;
        }
    }

    //Dictates where the bonus number appears, if at all
    void bonusNumberLogic()
    {

    }

    //The logic that states what beats what
    void nodeRelationLogic()
    {
        if (reverseState == false)
        {
            //Versus Logic
            if (playerNode == playerNodeEnum.node1 && singleLock == false)
            {
                if (computerNode == computerNodeEnum.node2 || computerNode == computerNodeEnum.node3)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node4)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node1 && singleLock == false)
                {
                    reverseState = true;
                    singleLock = true;
                }
            }

            if (playerNode == playerNodeEnum.node2 && singleLock == false)
            {
                if (computerNode == computerNodeEnum.node3)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node1 || computerNode == computerNodeEnum.node4)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node2 && singleLock == false)
                {
                    reverseState = true;
                    singleLock = true;
                }
            }

            if (playerNode == playerNodeEnum.node3 && singleLock == false)
            {
                if (computerNode == computerNodeEnum.node4)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node2 || computerNode == computerNodeEnum.node1)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node3 && singleLock == false)
                {
                    reverseState = true;
                    singleLock = true;
                }
            }

            if (playerNode == playerNodeEnum.node4 && singleLock == false)
            {
                if (computerNode == computerNodeEnum.node1 || computerNode == computerNodeEnum.node2)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node3)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node4 && singleLock == false)
                {
                    reverseState = true;
                    singleLock = true;
                }
            }
        }



        if (reverseState == true)
        {
            //Reversed Versus Logic
            if (playerNode == playerNodeEnum.node1 && singleLock == false)
            {
                if (computerNode == computerNodeEnum.node2 || computerNode == computerNodeEnum.node3)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node4)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node1 && singleLock == false)
                {
                    reverseState = false;
                    singleLock = true;
                }
            }

            if (playerNode == playerNodeEnum.node2 && singleLock == false)
            {
                if (computerNode == computerNodeEnum.node3)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node1 || computerNode == computerNodeEnum.node4)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node2 && singleLock == false)
                {
                    reverseState = false;
                    singleLock = true;
                }
            }

            if (playerNode == playerNodeEnum.node3 && singleLock == false)
            {
                if (computerNode == computerNodeEnum.node4)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node2 || computerNode == computerNodeEnum.node1)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node3 && singleLock == false)
                {
                    reverseState = false;
                    singleLock = true;
                }
            }

            if (playerNode == playerNodeEnum.node4 && singleLock == false)
            {
                if (computerNode == computerNodeEnum.node1 || computerNode == computerNodeEnum.node2)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node3)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node4 && singleLock == false)
                {
                    reverseState = false;
                    singleLock = true;
                }
            }
        }
    }
}
