﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript_class : MonoBehaviour
{
    public GameObject combatManagerRef;
    public int buttonNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        if (buttonNum == 1)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 1;
        }

        if (buttonNum == 2)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 2;
        }

        if (buttonNum == 3)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 3;
        }

        if (buttonNum == 4)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 4;
        }
    }

    private void OnMouseExit()
    {
        if (buttonNum == 1)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 0;
        }

        if (buttonNum == 2)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 0;
        }

        if (buttonNum == 3)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 0;
        }

        if (buttonNum == 4)
        {
            combatManagerRef.GetComponent<CombatManager_class>().currentButton = 0;
        }
    }
}