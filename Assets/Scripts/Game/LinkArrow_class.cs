using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum arrowEnum { none, left, right, up, down }

public class LinkArrow_class : MonoBehaviour
{
    public arrowEnum arrowType;
    public CombatManagerV2_class mRef;
    public Color keepArrowColor;
    public Vector3 changePos;

    // Start is called before the first frame update
    void Start()
    {
        arrowVector();
    }

    //Sets global position variables for the arrows
    void arrowVector()
    {
        switch (arrowType)
        {
            case arrowEnum.left:
                mRef.bottom = this.transform.position;
                break;

            case arrowEnum.right:
                mRef.top = this.transform.position;
                break;

            case arrowEnum.up:
                mRef.left = this.transform.position;
                break;

            case arrowEnum.down:
                mRef.right = this.transform.position;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        buttonCheck();
        turnArrows();
        colourManager();
        positionManager();
    }


    void colourManager()
    {
        if (mRef.arrowRecolour == arrowRecolourEnum.red)
        {
            keepArrowColor = Color.red;
        }
        if (mRef.arrowRecolour == arrowRecolourEnum.blue)
        {
            keepArrowColor = Color.blue;
        }
        if (mRef.arrowRecolour == arrowRecolourEnum.green)
        {
            keepArrowColor = Color.green;
        }
        if (mRef.arrowRecolour == arrowRecolourEnum.grey)
        {
            keepArrowColor = Color.grey;
        }
    }

    void positionManager()
    {
        if (mRef.arrowChangePos == arrowChangePosEnum.none)
        {
            changePos = new Vector3(100, 100, 0);
        }

        if (mRef.arrowChangePos == arrowChangePosEnum.right)
        {
            changePos = mRef.right;
        }
        if (mRef.arrowChangePos == arrowChangePosEnum.left)
        {
            changePos = mRef.left;
        }
        if (mRef.arrowChangePos == arrowChangePosEnum.top)
        {
            changePos = mRef.top;
        }
        if (mRef.arrowChangePos == arrowChangePosEnum.bottom)
        {
            changePos = mRef.bottom;
        }
    }

    void buttonCheck()
    {
        if (mRef.singleLock == false)
        {
            if (mRef.currentButton == 0)
            {
                hideArrows();
            }

            if (mRef.currentButton == 1)
            {
                highOver();
            }
            if (mRef.currentButton == 2)
            {
                lowOver();
            }
            if (mRef.currentButton == 3)
            {
                sideOver();
            }
            if (mRef.currentButton == 4)
            {
                midOver();
            }
        }
    }

    //Governs displaying the arrows when mousing over the buttons
    void highOver()
    {
        if (mRef.buttonMode == buttonModeEnum.attackMode)
        {
            highAtt();
        }
        else
        {
            highDef();
        }
    }

    void highAtt()
    {
        if (mRef.reverseState == false)
        {
            if (arrowType == arrowEnum.right)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                this.transform.position = mRef.top;
            }
            if (arrowType == arrowEnum.up)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.left;
            }
        }
        else
        {
            if (arrowType == arrowEnum.left)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.top;
            }
            if (arrowType == arrowEnum.down)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                this.transform.position = mRef.left;
            }
        }
    }

    void highDef()
    {
        if (mRef.reverseState == false)
        {
            if (arrowType == arrowEnum.left)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                this.transform.position = mRef.top;
            }
            if (arrowType == arrowEnum.up)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.left;
            }
        }
        else
        {
            if (arrowType == arrowEnum.left)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.top;
            }
            if (arrowType == arrowEnum.up)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                this.transform.position = mRef.left;
            }
        }
    }


    // LOW ----------------------
    void lowOver()
    {
        if (mRef.buttonMode == buttonModeEnum.attackMode)
        {
            lowAtt();
        }
        else
        {
            lowDef();
        }
    }

    void lowAtt()
    {
        if (mRef.reverseState == false)
        {
            if (arrowType == arrowEnum.right)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.top;
            }
            if (arrowType == arrowEnum.down)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                this.transform.position = mRef.right;
            }
        }
        else
        {
            if (arrowType == arrowEnum.left)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                this.transform.position = mRef.top;
            }
            if (arrowType == arrowEnum.up)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.right;
            }
        }
    }

    void lowDef()
    {
        if (mRef.reverseState == false)
        {
            if (arrowType == arrowEnum.right)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.top;
            }
            if (arrowType == arrowEnum.up)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                this.transform.position = mRef.right;
            }
        }
        else
        {
            if (arrowType == arrowEnum.right)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                this.transform.position = mRef.top;
            }
            if (arrowType == arrowEnum.up)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.right;
            }
        }
    }


    //SIDE -----------------------------------------------
    void sideOver()
    {
        if (mRef.buttonMode == buttonModeEnum.attackMode)
        {
            sideAtt();
        }
        else
        {
            sideDef();
        }

    }

    void sideAtt()
    {
        if (mRef.reverseState == false)
        {
            if (arrowType == arrowEnum.down)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.right;
            }
            if (arrowType == arrowEnum.left)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                this.transform.position = mRef.bottom;
            }
        }
        else
        {
            if (arrowType == arrowEnum.up)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                this.transform.position = mRef.right;
            }
            if (arrowType == arrowEnum.left)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.bottom;
            }
        }
    }

    void sideDef()
    {
        if (mRef.reverseState == false)
        {
            if (arrowType == arrowEnum.down)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.right;
            }
            if (arrowType == arrowEnum.right)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                this.transform.position = mRef.bottom;
            }
        }
        else
        {
            if (arrowType == arrowEnum.down)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                this.transform.position = mRef.right;
            }
            if (arrowType == arrowEnum.right)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.bottom;
            }
        }
    }



    //MID -----------------------------------------------
    void midOver()
    {
        if (mRef.buttonMode == buttonModeEnum.attackMode)
        {
            midAtt();
        }
        else
        {
            midDef();
        }

    }

    void midAtt()
    {
        if (mRef.reverseState == false)
        {
            if (arrowType == arrowEnum.left)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.bottom;
            }
            if (arrowType == arrowEnum.up)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                this.transform.position = mRef.left;
            }
        }
        else
        {
            if (arrowType == arrowEnum.right)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                this.transform.position = mRef.bottom;
            }
            if (arrowType == arrowEnum.down)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.left;
            }
        }
    }

    void midDef()
    {
        if (mRef.reverseState == false)
        {
            if (arrowType == arrowEnum.left)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.bottom;
            }
            if (arrowType == arrowEnum.down)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                this.transform.position = mRef.left;
            }
        }
        else
        {
            if (arrowType == arrowEnum.left)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                this.transform.position = mRef.bottom;
            }
            if (arrowType == arrowEnum.down)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                this.transform.position = mRef.left;
            }
        }
    }

    void hideArrows()
    {
        this.transform.position = new Vector3(100, 100, 0);
    }

    void turnArrows()
    {
       if (mRef.singleLock == true)
        {
            if ((int)arrowType != (int)mRef.arrowKeep)
            {
                this.transform.position = new Vector3(100, 100, 0);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = keepArrowColor;
                this.transform.position = changePos;
            }
        }
    }
}
