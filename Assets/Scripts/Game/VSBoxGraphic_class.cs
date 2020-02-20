using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSBoxGraphic_class : MonoBehaviour
{
    public int vsBoxNumber;
    public CombatManager_class mRef;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(100, 100, 1);
    }

    // Update is called once per frame
    void Update()
    {
        vsBoxPositions();
    }

    //Logic for highlighting the buttons to show what beats what, 1 and 2 are green 3 and 4 are red
    void vsBoxPositions()
    {

        if (mRef.currentButton == 0)
        {
            this.transform.position = new Vector3(100, 100, 1);
        }


        if (mRef.reverseState == false)
        {
            if (mRef.currentButton == 1)
            {
                if (vsBoxNumber == 1)
                {
                    this.transform.position = mRef.button2Pos;
                }

                if (vsBoxNumber == 2)
                {
                    this.transform.position = mRef.button3Pos;
                }

                if (vsBoxNumber == 3)
                {
                    this.transform.position = mRef.button4Pos;
                }
            }

            if (mRef.currentButton == 2)
            {
                if (vsBoxNumber == 1)
                {
                    this.transform.position = mRef.button3Pos;
                }

                if (vsBoxNumber == 3)
                {
                    this.transform.position = mRef.button1Pos;
                }

                if (vsBoxNumber == 4)
                {
                    this.transform.position = mRef.button4Pos;
                }
            }

            if (mRef.currentButton == 3)
            {
                if (vsBoxNumber == 1)
                {
                    this.transform.position = mRef.button4Pos;
                }

                if (vsBoxNumber == 3)
                {
                    this.transform.position = mRef.button1Pos;
                }

                if (vsBoxNumber == 4)
                {
                    this.transform.position = mRef.button2Pos;
                }
            }

            if (mRef.currentButton == 4)
            {
                if (vsBoxNumber == 1)
                {
                    this.transform.position = mRef.button1Pos;
                }

                if (vsBoxNumber == 2)
                {
                    this.transform.position = mRef.button2Pos;
                }

                if (vsBoxNumber == 3)
                {
                    this.transform.position = mRef.button3Pos;
                }
            }
        }

        if (mRef.reverseState == true)
        {
            if (mRef.currentButton == 1)
            {
                if (vsBoxNumber == 3)
                {
                    this.transform.position = mRef.button2Pos;
                }

                if (vsBoxNumber == 4)
                {
                    this.transform.position = mRef.button3Pos;
                }

                if (vsBoxNumber == 1)
                {
                    this.transform.position = mRef.button4Pos;
                }
            }

            if (mRef.currentButton == 2)
            {
                if (vsBoxNumber == 3)
                {
                    this.transform.position = mRef.button3Pos;
                }

                if (vsBoxNumber == 1)
                {
                    this.transform.position = mRef.button1Pos;
                }

                if (vsBoxNumber == 2)
                {
                    this.transform.position = mRef.button4Pos;
                }
            }

            if (mRef.currentButton == 3)
            {
                if (vsBoxNumber == 3)
                {
                    this.transform.position = mRef.button4Pos;
                }

                if (vsBoxNumber == 1)
                {
                    this.transform.position = mRef.button1Pos;
                }

                if (vsBoxNumber == 2)
                {
                    this.transform.position = mRef.button2Pos;
                }
            }

            if (mRef.currentButton == 4)
            {
                if (vsBoxNumber == 3)
                {
                    this.transform.position = mRef.button1Pos;
                }

                if (vsBoxNumber == 4)
                {
                    this.transform.position = mRef.button2Pos;
                }

                if (vsBoxNumber == 1)
                {
                    this.transform.position = mRef.button3Pos;
                }
            }
        }
    }
}
