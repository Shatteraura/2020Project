using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerNodeEnum { noNode, node1, node2, node3, node4 }
public enum computerNodeEnum { noNode, node1, node2, node3, node4 }

public class CombatManager_class : MonoBehaviour
{
    playerNodeEnum playerNode;
    computerNodeEnum computerNode;

    public int playerHealth = 5;
    public int computerHealth = 5;
    public int bonusNumber = 0;

    bool reverseState = false;
    bool singleLock = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nodeRelationLogic();
    }

    //The logic that states what beats what
    void nodeRelationLogic()
    {
        if (reverseState == false)
        {
            if (playerNode == playerNodeEnum.node1)
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
            }

            if (playerNode == playerNodeEnum.node2)
            {
                if (computerNode == computerNodeEnum.node3)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node1)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }
            }

            if (playerNode == playerNodeEnum.node3)
            {
                if (computerNode == computerNodeEnum.node4 || computerNode == computerNodeEnum.node2)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node2)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }
            }

            if (playerNode == playerNodeEnum.node4)
            {
                if (computerNode == computerNodeEnum.node1)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node3)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }
            }
        }



        if (reverseState == true)
        {
            if (playerNode == playerNodeEnum.node1)
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
            }

            if (playerNode == playerNodeEnum.node2)
            {
                if (computerNode == computerNodeEnum.node3)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node1)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }
            }

            if (playerNode == playerNodeEnum.node3)
            {
                if (computerNode == computerNodeEnum.node4 || computerNode == computerNodeEnum.node2)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node2)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }
            }

            if (playerNode == playerNodeEnum.node4)
            {
                if (computerNode == computerNodeEnum.node1)
                {
                    playerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }

                if (computerNode == computerNodeEnum.node3)
                {
                    computerHealth -= 1 - bonusNumber;
                    singleLock = true;
                }
            }
        }
    }
}
