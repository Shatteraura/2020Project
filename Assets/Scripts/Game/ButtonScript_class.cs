using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript_class : MonoBehaviour
{
    public GameObject combatManagerRef;
    public SelectBoxScript_class selectRef;
    public int buttonNum;

    // Start is called before the first frame update
    void Start()
    {
        if (buttonNum == 1)
        {
            combatManagerRef.GetComponent<CombatManager_class>().button1Pos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        }
        if (buttonNum == 2)
        {
            combatManagerRef.GetComponent<CombatManager_class>().button2Pos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        }
        if (buttonNum == 3)
        {
            combatManagerRef.GetComponent<CombatManager_class>().button3Pos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        }
        if (buttonNum == 4)
        {
            combatManagerRef.GetComponent<CombatManager_class>().button4Pos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (buttonNum == 1)
        {
            selectRef.buttonPos = new Vector3(100, 100, 1);
        }

        if (buttonNum == 2)
        {
            selectRef.buttonPos = new Vector3(100, 100, 1);
        }

        if (buttonNum == 3)
        {
            selectRef.buttonPos = new Vector3(100, 100, 1);
        }

        if (buttonNum == 4)
        {
            selectRef.buttonPos = new Vector3(100, 100, 1);
        }
    }

    private void OnMouseEnter()
    {
        if (buttonNum == 1 && combatManagerRef.GetComponent<CombatManager_class>().playerNodeLock != 1)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 1;
            selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        }

        if (buttonNum == 2 && combatManagerRef.GetComponent<CombatManager_class>().playerNodeLock != 2)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 2;
            selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        }

        if (buttonNum == 3 && combatManagerRef.GetComponent<CombatManager_class>().playerNodeLock != 3)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 3;
            selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        }

        if (buttonNum == 4 && combatManagerRef.GetComponent<CombatManager_class>().playerNodeLock != 4)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 4;
            selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        }
    }

    private void OnMouseExit()
    {
        if (buttonNum == 1)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 0;
            selectRef.buttonPos = new Vector3(100, 100, 1);
        }

        if (buttonNum == 2)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 0;
            selectRef.buttonPos = new Vector3(100, 100, 1);
        }

        if (buttonNum == 3)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 0;
            selectRef.buttonPos = new Vector3(100, 100, 1);
        }

        if (buttonNum == 4)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 0;
            selectRef.buttonPos = new Vector3(100, 100, 1);
        }
    }
}
