using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum vsColourEnum { greenOne, greenTwo, redOne, redTwo, blueOne }

public class VSBoxGraphic_class : MonoBehaviour
{
    public vsColourEnum vsColour;
    public CombatManagerV2_class mRef;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(100, 100, 1);
    }

    // Update is called once per frame
    void Update()
    {
        switch (mRef.singleLock)
        {
            case false:
                vsBoxPositions();
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                break;

            case true:
                if (mRef.buttonMode == buttonModeEnum.attackMode)
                {
                    boxHide();
                }
                if (mRef.buttonMode == buttonModeEnum.defenceMode && mRef.comDef == false)
                {
                    boxHideDef();
                }
                else if (mRef.buttonMode == buttonModeEnum.defenceMode && mRef.comDef == true)
                {
                    doubleDef();
                }
                break;
        }  
    }

    //Logic for highlighting the buttons to show what beats what, 1 and 2 are green 3 and 4 are red
    void vsBoxPositions()
    {
        if (mRef.reverseState == false)
        {
            switch (mRef.currentButton)
            {
                case 0:
                    this.transform.position = new Vector3(100, 100, 1);
                    break;

                case 1:
                    switch (vsColour)
                    {
                        case vsColourEnum.greenOne:                           
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button2Pos;
                            }
                            break;

                        case vsColourEnum.blueOne:
                            if (mRef.buttonMode == buttonModeEnum.defenceMode)
                            {
                                this.transform.position = mRef.button2Pos;
                            }
                            break;

                        case vsColourEnum.greenTwo:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button3Pos;
                            }

                            else
                            {
                                this.transform.position = new Vector3(100, 100, 0);
                            }
                            break;

                        case vsColourEnum.redOne:
                            this.transform.position = mRef.button4Pos;
                            break;
                    }
                    break;

                case 2:
                    switch (vsColour)
                    {
                        case vsColourEnum.greenOne:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button3Pos;
                            }
                            break;

                        case vsColourEnum.blueOne:
                            if (mRef.buttonMode == buttonModeEnum.defenceMode)
                            {
                                this.transform.position = mRef.button3Pos;
                            }
                            break;

                        case vsColourEnum.redOne:
                            this.transform.position = mRef.button1Pos;
                            break;

                        case vsColourEnum.redTwo:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button4Pos;
                            }

                            else
                            {
                                this.transform.position = new Vector3(100, 100, 0);
                            }
                            break;
                    }
                    break;

                case 3:
                    switch (vsColour)
                    {
                        case vsColourEnum.greenOne:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button4Pos;
                            }
                            break;

                        case vsColourEnum.blueOne:
                            if (mRef.buttonMode == buttonModeEnum.defenceMode)
                            {
                                this.transform.position = mRef.button4Pos;
                            }
                            break;

                        case vsColourEnum.redOne:
                            this.transform.position = mRef.button2Pos;
                            break;

                        case vsColourEnum.redTwo:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button1Pos;
                            }

                            else
                            {
                                this.transform.position = new Vector3(100, 100, 0);
                            }
                            break;
                    }
                    break;

                case 4:
                    switch (vsColour)
                    {
                        case vsColourEnum.greenOne:
                            
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button2Pos;
                            }

                            else
                            {
                                this.transform.position = new Vector3(100, 100, 0);
                            }
                            break;

                        case vsColourEnum.greenTwo:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button1Pos;
                            }
                            break;

                        case vsColourEnum.blueOne:
                            if (mRef.buttonMode == buttonModeEnum.defenceMode)
                            {
                                this.transform.position = mRef.button1Pos;
                            }
                            break;

                        case vsColourEnum.redOne:
                            this.transform.position = mRef.button3Pos;
                            break;
                    }
                    break;

            }
        }

        if (mRef.reverseState == true)
        {
            switch (mRef.currentButton)
            {
                case 0:
                    this.transform.position = new Vector3(100, 100, 1);
                    break;

                case 1:
                    switch (vsColour)
                    {
                        case vsColourEnum.redOne:
                            this.transform.position = mRef.button2Pos;
                            break;

                        case vsColourEnum.redTwo:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button3Pos;
                            }

                            else
                            {
                                this.transform.position = new Vector3(100, 100, 0);
                            }
                            break;

                        case vsColourEnum.greenOne:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button4Pos;
                            }
                            break;

                        case vsColourEnum.blueOne:
                            if (mRef.buttonMode == buttonModeEnum.defenceMode)
                            {
                                this.transform.position = mRef.button4Pos;
                            }
                            break;
                    }
                    break;

                case 2:
                    switch (vsColour)
                    {
                        case vsColourEnum.redOne:
                            this.transform.position = mRef.button3Pos;
                            break;

                        case vsColourEnum.greenOne:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button1Pos;
                            }
                            break;

                        case vsColourEnum.blueOne:
                            if (mRef.buttonMode == buttonModeEnum.defenceMode)
                            {
                                this.transform.position = mRef.button1Pos;
                            }
                            break;

                        case vsColourEnum.greenTwo:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button4Pos;
                            }

                            else
                            {
                                this.transform.position = new Vector3(100, 100, 0);
                            }
                            break;
                    }
                    break;

                case 3:
                    switch (vsColour)
                    {
                        case vsColourEnum.redOne:
                            this.transform.position = mRef.button4Pos;
                            break;

                        case vsColourEnum.greenOne:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button2Pos;
                            }
                            break;

                        case vsColourEnum.blueOne:
                            if (mRef.buttonMode == buttonModeEnum.defenceMode)
                            {
                                this.transform.position = mRef.button2Pos;
                            }
                            break;

                        case vsColourEnum.greenTwo:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button1Pos;
                            }

                            else
                            {
                                this.transform.position = new Vector3(100, 100, 0);
                            }
                            break;
                    }
                    break;

                case 4:
                    switch (vsColour)
                    {
                        case vsColourEnum.redOne:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button2Pos;
                            }

                            else
                            {
                                this.transform.position = new Vector3(100, 100, 0);
                            }
                            break;

                        case vsColourEnum.redTwo:
                            this.transform.position = mRef.button1Pos;
                            break;

                        case vsColourEnum.greenOne:
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                this.transform.position = mRef.button3Pos;
                            }
                            break;

                        case vsColourEnum.blueOne:
                            if (mRef.buttonMode == buttonModeEnum.defenceMode)
                            {
                                this.transform.position = mRef.button3Pos;
                            }
                            break;
                    }
                    break;
            }
        }

    }

    void boxHide()
    {
        switch (mRef.reverseState)
        {
            case false:
                switch (mRef.playerNodeLock)
                {
                    case 1:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 2:
                                if (vsColour == vsColourEnum.greenTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 3:
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 4:
                                if (vsColour == vsColourEnum.greenTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;
                        }
                        break;

                    case 2:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.redTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 2:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 3:
                                if (vsColour == vsColourEnum.redTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 4:
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;
                        }
                        break;

                    case 3:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 2:
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.redTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 3:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 4:
                                if (vsColour == vsColourEnum.redTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;
                        }
                        break;

                    case 4:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 2:
                                if (vsColour == vsColourEnum.greenTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 3:
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.greenTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 4:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;
                        }
                        break;
                }
                break;

            case true:
                switch (mRef.playerNodeLock)
                {
                    case 1:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 2:
                                if (vsColour == vsColourEnum.redTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 3:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 4:
                                if (vsColour == vsColourEnum.redTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;
                        }
                        break;

                    case 2:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.greenTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 2:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 3:
                                if (vsColour == vsColourEnum.greenTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 4:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;
                        }
                        break;

                    case 3:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 2:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.greenTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 3:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 4:
                                if (vsColour == vsColourEnum.greenTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;
                        }
                        break;

                    case 4:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 2:
                                if (vsColour == vsColourEnum.redTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.greenOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 3:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                if (vsColour == vsColourEnum.redTwo)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 4:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;
                        }
                        break;
                }
                break;
        } 
    }

    void boxHideDef()
    {
        switch (mRef.reverseState)
        {
            case false:
                switch (mRef.playerNodeLock)
                {
                    case 1:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 2:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 3:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 4:
                                if (vsColour == vsColourEnum.blueOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;
                        }
                        break;

                    case 2:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                if (vsColour == vsColourEnum.blueOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 2:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 3:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 4:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;
                        }
                        break;

                    case 3:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 2:
                                if (vsColour == vsColourEnum.blueOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 3:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 4:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;
                        }
                        break;

                    case 4:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 2:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 3:
                                if (vsColour == vsColourEnum.blueOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 4:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;
                        }
                        break;
                }
                break;

            case true:
                switch (mRef.playerNodeLock)
                {
                    case 1:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 2:
                                if (vsColour == vsColourEnum.blueOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 3:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 4:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;
                        }
                        break;

                    case 2:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 2:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 3:
                                if (vsColour == vsColourEnum.blueOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 4:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;
                        }
                        break;

                    case 3:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 2:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 3:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 4:
                                if (vsColour == vsColourEnum.blueOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;
                        }
                        break;

                    case 4:
                        switch (mRef.comPrev)
                        {
                            case 1:
                                if (vsColour == vsColourEnum.blueOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 2:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;

                            case 3:
                                if (vsColour == vsColourEnum.redOne)
                                {
                                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                }
                                break;

                            case 4:
                                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                break;
                        }
                        break;
                }
                break;
        }
    }

    void doubleDef()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
}
