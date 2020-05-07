using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitch_class : MonoBehaviour
{
    public GameObject combatManagerRef;
    public SelectBoxScript_class selectRef;

    public Sprite attackSprite;
    public Sprite defendSprite;

    // Start is called before the first frame update
    void Start()
    {
        combatManagerRef.GetComponent<CombatManager_class>().button5Pos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        this.GetComponent<SpriteRenderer>().sprite = attackSprite;
        combatManagerRef.GetComponent<CombatManager_class>().modeButtonText.text = "Attack Mode";
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnMouseOver()
    {
        selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
    }

    private void OnMouseDown()
    {
        if (combatManagerRef.GetComponent<CombatManager_class>().buttonMode == buttonModeEnum.attackMode)
        {
            combatManagerRef.GetComponent<CombatManager_class>().buttonMode = buttonModeEnum.defenceMode;
            combatManagerRef.GetComponent<CombatManager_class>().modeButtonText.text = "Defence Mode";
            this.GetComponent<SpriteRenderer>().sprite = defendSprite;
        }

        else if (combatManagerRef.GetComponent<CombatManager_class>().buttonMode == buttonModeEnum.defenceMode)
        {
            combatManagerRef.GetComponent<CombatManager_class>().buttonMode = buttonModeEnum.attackMode;
            combatManagerRef.GetComponent<CombatManager_class>().modeButtonText.text = "Attack Mode";
            this.GetComponent<SpriteRenderer>().sprite = attackSprite;
        }
    }

    private void OnMouseExit()
    {
        selectRef.buttonPos = new Vector3(100, 100, 1);
    }
}
