using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitch_class : MonoBehaviour
{
    public CombatManagerV2_class mRef;
    public SelectBoxScript_class selectRef;

    public Sprite attackSprite;
    public Sprite defendSprite;

    // Start is called before the first frame update
    void Start()
    {
        mRef.button5Pos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        this.GetComponent<SpriteRenderer>().sprite = attackSprite;
        mRef.modeButtonText.text = "Attack Mode";
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnMouseOver()
    {
        if (mRef.playerLose == false && mRef.playerWin == false)
        {
            selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        }
    }

    private void OnMouseDown()
    {
        if (mRef.playerLose == false && mRef.playerWin == false)
        {
            if (mRef.buttonMode == buttonModeEnum.attackMode)
            {
                mRef.buttonMode = buttonModeEnum.defenceMode;
                mRef.modeButtonText.text = "Defence Mode";
                this.GetComponent<SpriteRenderer>().sprite = defendSprite;
            }

            else if (mRef.buttonMode == buttonModeEnum.defenceMode)
            {
                mRef.buttonMode = buttonModeEnum.attackMode;
                mRef.modeButtonText.text = "Attack Mode";
                this.GetComponent<SpriteRenderer>().sprite = attackSprite;
            }
        }
    }

    private void OnMouseExit()
    {
        selectRef.buttonPos = new Vector3(100, 100, 1);
    }
}
