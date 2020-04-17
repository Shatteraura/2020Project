using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum arrowEnum { left, right, up, down, cross }

public class LinkArrow_class : MonoBehaviour
{
    public arrowEnum arrowType;
    public CombatManager_class mRef;

    SpriteRenderer colourChange;

    // Start is called before the first frame update
    void Start()
    {
        colourChange = GetComponent<SpriteRenderer>();
        arrowVector();
    }

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

            case arrowEnum.cross:
                mRef.middle = this.transform.position;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        vsArrowPos();
    }

    //Governs the arrows position and colour
    void vsArrowPos()
    {
        if (mRef.reverseState == false)
        {

            switch (mRef.currentButton)
            {
                case 0:
                    this.transform.position = new Vector3(100, 100, 0);
                    colourChange.color = Color.white;
                    break;

                case 1:
                    switch (arrowType)
                    {
                        case arrowEnum.right:
                            this.transform.position = mRef.top;
                            colourChange.color = Color.green;
                            break;

                        case arrowEnum.cross:
                            this.transform.position = mRef.middle;
                            this.transform.rotation = new Quaternion(0, 0, 0, 0);
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                colourChange.color = Color.green;
                            }
                            else
                            {
                                colourChange.color = Color.grey;
                            }
                            break;

                        case arrowEnum.up:
                            this.transform.position = mRef.left;
                            colourChange.color = Color.red;
                            break;
                    }
                    break;

                case 2:
                    switch (arrowType)
                    {
                        case arrowEnum.right:
                            this.transform.position = mRef.top;
                            colourChange.color = Color.red;
                            break;

                        case arrowEnum.cross:
                            this.transform.position = mRef.middle;
                            this.transform.rotation = new Quaternion(90,0,0,0);
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                colourChange.color = Color.red;
                            }
                            else
                            {
                                colourChange.color = Color.grey;
                            }
                            break;

                        case arrowEnum.down:
                            this.transform.position = mRef.right;
                            colourChange.color = Color.green;
                            break;

                    }
                    break;

                case 3:
                    switch (arrowType)
                    {
                        case arrowEnum.left:
                            this.transform.position = mRef.bottom;
                            colourChange.color = Color.green;
                            break;

                        case arrowEnum.cross:
                            this.transform.position = mRef.middle;
                            this.transform.rotation = new Quaternion(0, 0, 0, 0);
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                colourChange.color = Color.red;
                            }
                            else
                            {
                                colourChange.color = Color.grey;
                            }
                            break;

                        case arrowEnum.down:
                            this.transform.position = mRef.right;
                            colourChange.color = Color.red;
                            break;

                    }
                    break;

                case 4:
                    switch (arrowType)
                    {
                        case arrowEnum.left:
                            this.transform.position = mRef.bottom;
                            colourChange.color = Color.red;
                            break;

                        case arrowEnum.cross:
                            this.transform.position = mRef.middle;
                            this.transform.rotation = new Quaternion(90, 0, 0, 0);
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                colourChange.color = Color.green;
                            }
                            else
                            {
                                colourChange.color = Color.grey;
                            }
                            break;

                        case arrowEnum.up:
                            this.transform.position = mRef.left;
                            colourChange.color = Color.green;
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
                    this.transform.position = new Vector3(100, 100, 0);
                    colourChange.color = Color.white;
                    break;

                case 1:
                    switch (arrowType)
                    {
                        case arrowEnum.left:
                            this.transform.position = mRef.top;
                            colourChange.color = Color.red;
                            break;

                        case arrowEnum.cross:
                            this.transform.position = mRef.middle;
                            this.transform.rotation = new Quaternion(90, 90, 0, 0);
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                colourChange.color = Color.red;
                            }
                            else
                            {
                                colourChange.color = Color.grey;
                            }
                            break;

                        case arrowEnum.down:
                            this.transform.position = mRef.left;
                            colourChange.color = Color.green;
                            break;
                    }
                    break;

                case 2:
                    switch (arrowType)
                    {
                        case arrowEnum.left:
                            this.transform.position = mRef.top;
                            colourChange.color = Color.green;
                            break;

                        case arrowEnum.cross:
                            this.transform.position = mRef.middle;
                            this.transform.rotation = new Quaternion(0, 90, 0, 0);
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                colourChange.color = Color.green;
                            }
                            else
                            {
                                colourChange.color = Color.grey;
                            }
                            break;

                        case arrowEnum.up:
                            this.transform.position = mRef.right;
                            colourChange.color = Color.red;
                            break;
                    }
                    break;

                case 3:
                    switch (arrowType)
                    {
                        case arrowEnum.right:
                            this.transform.position = mRef.bottom;
                            colourChange.color = Color.red;
                            break;

                        case arrowEnum.cross:
                            this.transform.position = mRef.middle;
                            this.transform.rotation = new Quaternion(90, 90, 0, 0);
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                colourChange.color = Color.green;
                            }
                            else
                            {
                                colourChange.color = Color.grey;
                            }
                            break;

                        case arrowEnum.up:
                            this.transform.position = mRef.right;
                            colourChange.color = Color.green;
                            break;
                    }
                    break;

                case 4:
                    switch (arrowType)
                    {
                        case arrowEnum.right:
                            this.transform.position = mRef.bottom;
                            colourChange.color = Color.green;
                            break;

                        case arrowEnum.cross:
                            this.transform.position = mRef.middle;
                            this.transform.rotation = new Quaternion(0, 90, 0, 0);
                            if (mRef.buttonMode == buttonModeEnum.attackMode)
                            {
                                colourChange.color = Color.red;
                            }
                            else
                            {
                                colourChange.color = Color.grey;
                            }
                            break;

                        case arrowEnum.down:
                            this.transform.position = mRef.left;
                            colourChange.color = Color.red;
                            break;
                    }
                    break;
            }
        }
    }
}
