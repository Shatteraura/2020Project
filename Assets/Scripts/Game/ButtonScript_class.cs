using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript_class : MonoBehaviour
{
    public GameObject combatManagerRef;
    public Player_class playerRef;
    public SelectBoxScript_class selectRef;

    public int buttonNum;
    public bool attack = true;
    public Sprite attackSprite;
    public Sprite defendSprite;

    // Start is called before the first frame update
    void Start()
    {
        switch (buttonNum)
        {
            case 1:
                combatManagerRef.GetComponent<CombatManager_class>().button1Pos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                break;

            case 2:
                combatManagerRef.GetComponent<CombatManager_class>().button2Pos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                break;

            case 3:
                combatManagerRef.GetComponent<CombatManager_class>().button3Pos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                break;

            case 4:
                combatManagerRef.GetComponent<CombatManager_class>().button4Pos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                break;

            case 5:
                combatManagerRef.GetComponent<CombatManager_class>().button5Pos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                this.GetComponent<SpriteRenderer>().sprite = defendSprite;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Clicking the buttons sends the selection box offscreen, also governs changing the attack/defend sprite
    private void OnMouseDown()
    {

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

            case 5:
                if (attack == true)
                {
                    attack = false;
                    this.GetComponent<SpriteRenderer>().sprite = attackSprite;
                }
                else if (attack == false)
                {
                    attack = true;
                    this.GetComponent<SpriteRenderer>().sprite = defendSprite;
                }
                break;
        }

        if (buttonNum == 5 && combatManagerRef.GetComponent<CombatManager_class>().buttonMode == buttonModeEnum.attackMode)
        {
            combatManagerRef.GetComponent<CombatManager_class>().buttonMode = buttonModeEnum.defenceMode;
        }

        else if (buttonNum == 5 && combatManagerRef.GetComponent<CombatManager_class>().buttonMode == buttonModeEnum.defenceMode)
        {
            combatManagerRef.GetComponent<CombatManager_class>().buttonMode = buttonModeEnum.attackMode;
        }
    }

    private void OnMouseEnter()
    {
        //Mousing Over The Buttons
        switch (buttonNum)
        {
            case 1:
                if (combatManagerRef.GetComponent<CombatManager_class>().playerNodeLock != 1)
                {
                    playerRef.playerUpdateSprite(0);
                    combatManagerRef.GetComponent<CombatManager_class>().currentButton = 1;
                    selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                }
                break;

            case 2:
                if (combatManagerRef.GetComponent<CombatManager_class>().playerNodeLock != 2)
                {
                    playerRef.playerUpdateSprite(1);
                    combatManagerRef.GetComponent<CombatManager_class>().currentButton = 2;
                    selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                }
                break;

            case 3:
                if (combatManagerRef.GetComponent<CombatManager_class>().playerNodeLock != 3)
                {
                    playerRef.playerUpdateSprite(2);
                    combatManagerRef.GetComponent<CombatManager_class>().currentButton = 3;
                    selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                }
                break;

            case 4:
                if (combatManagerRef.GetComponent<CombatManager_class>().playerNodeLock != 4)
                {
                    playerRef.playerUpdateSprite(3);
                    combatManagerRef.GetComponent<CombatManager_class>().currentButton = 4;
                    selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                }
                break;

            case 5:
                combatManagerRef.GetComponent<CombatManager_class>().currentButton = 5;
                selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                break;
        }
    }

    private void OnMouseExit()
    {
        //Mousing Away From The Buttons
        switch (buttonNum)
        {
            case 1:
                combatManagerRef.GetComponent<CombatManager_class>().currentButton = 0;
                selectRef.buttonPos = new Vector3(100, 100, 1);
                break;

            case 2:
                combatManagerRef.GetComponent<CombatManager_class>().currentButton = 0;
                selectRef.buttonPos = new Vector3(100, 100, 1);
                break;

            case 3:
                combatManagerRef.GetComponent<CombatManager_class>().currentButton = 0;
                selectRef.buttonPos = new Vector3(100, 100, 1);
                break;

            case 4:
                combatManagerRef.GetComponent<CombatManager_class>().currentButton = 0;
                selectRef.buttonPos = new Vector3(100, 100, 1);
                break;

            case 5:
                combatManagerRef.GetComponent<CombatManager_class>().currentButton = 0;
                selectRef.buttonPos = new Vector3(100, 100, 1);
                break;
        }
    }
}
