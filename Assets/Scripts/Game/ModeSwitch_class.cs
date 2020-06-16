using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitch_class : MonoBehaviour
{
    public CombatManagerV2_class mRef;
    public SelectBoxScript_class selectRef;

    // Start is called before the first frame update
    void Start()
    {
        mRef.modeButtonText.text = "Attack Mode";
    }

    // Update is called once per frame
    void Update()
    {
        if (mRef.buttonMode == buttonModeEnum.defenceMode)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
    }

    private void OnMouseOver()
    {
        if (mRef.playerLose == false && mRef.playerWin == false && mRef.dialogueLock == false)
        {
            selectRef.buttonPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        }
    }

    private void OnMouseDown()
    {
        if (mRef.playerLose == false && mRef.playerWin == false && mRef.dialogueLock == false)
        {
            if (mRef.buttonMode == buttonModeEnum.defenceMode)
            {
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                mRef.buttonMode = buttonModeEnum.attackMode;
                mRef.modeButtonText.text = "Attack Mode";
            }
        }
    }

    private void OnMouseExit()
    {
        selectRef.buttonPos = new Vector3(100, 100, 1);
    }
}
