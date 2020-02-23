using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum arrowEnum { east, west, north, south, NE, SE, SW, NW }

public class LinkArrow_class : MonoBehaviour
{
    public arrowEnum arrowType;
    public CombatManager_class mRef;

    SpriteRenderer colourChange;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(100, 100, 1);
        colourChange = GetComponent<SpriteRenderer>();
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
                    this.transform.position = new Vector3(100, 100, 1);
                    colourChange.color = Color.white;
                    break;

                case 1:
                    switch (arrowType)
                    {
                        case arrowEnum.east:
                            this.transform.position = new Vector3(-6, -1.5f, 1);
                            colourChange.color = Color.green;
                            break;

                        case arrowEnum.SE:
                            this.transform.position = new Vector3(-6, -3, 1);
                            colourChange.color = Color.green;
                            break;

                        case arrowEnum.north:
                            this.transform.position = new Vector3(-7.5f, -3, 1);
                            colourChange.color = Color.red;
                            break;
                    }
                    break;

                case 2:
                    switch (arrowType)
                    {
                        case arrowEnum.south:
                            this.transform.position = new Vector3(-4.5f, -3, 1);
                            colourChange.color = Color.green;
                            break;

                        case arrowEnum.NE:
                            this.transform.position = new Vector3(-6, -3, 1);
                            colourChange.color = Color.red;
                            break;

                        case arrowEnum.east:
                            this.transform.position = new Vector3(-6, -1.5f, 1);
                            colourChange.color = Color.red;
                            break;
                    }
                    break;

                case 3:
                    switch (arrowType)
                    {
                        case arrowEnum.west:
                            this.transform.position = new Vector3(-6f, -4.5f, 1);
                            colourChange.color = Color.green;
                            break;

                        case arrowEnum.SE:
                            this.transform.position = new Vector3(-6, -3, 1);
                            colourChange.color = Color.red;
                            break;

                        case arrowEnum.south:
                            this.transform.position = new Vector3(-4.5f, -3, 1);
                            colourChange.color = Color.red;
                            break;
                    }
                    break;

                case 4:
                    switch (arrowType)
                    {
                        case arrowEnum.north:
                            this.transform.position = new Vector3(-7.5f, -3, 1);
                            colourChange.color = Color.green;
                            break;

                        case arrowEnum.NE:
                            this.transform.position = new Vector3(-6, -3, 1);
                            colourChange.color = Color.green;
                            break;

                        case arrowEnum.west:
                            this.transform.position = new Vector3(-6, -4.5f, 1);
                            colourChange.color = Color.red;
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
                    colourChange.color = Color.white;
                    break;

                case 1:
                    switch (arrowType)
                    {
                        case arrowEnum.west:
                            this.transform.position = new Vector3(-6, -1.5f, 1);
                            colourChange.color = Color.red;
                            break;

                        case arrowEnum.NW:
                            this.transform.position = new Vector3(-6, -3, 1);
                            colourChange.color = Color.red;
                            break;

                        case arrowEnum.south:
                            this.transform.position = new Vector3(-7.5f, -3, 1);
                            colourChange.color = Color.green;
                            break;
                    }
                    break;

                case 2:
                    switch (arrowType)
                    {
                        case arrowEnum.north:
                            this.transform.position = new Vector3(-4.5f, -3, 1);
                            colourChange.color = Color.red;
                            break;

                        case arrowEnum.SW:
                            this.transform.position = new Vector3(-6, -3, 1);
                            colourChange.color = Color.green;
                            break;

                        case arrowEnum.west:
                            this.transform.position = new Vector3(-6, -1.5f, 1);
                            colourChange.color = Color.green;
                            break;
                    }
                    break;

                case 3:
                    switch (arrowType)
                    {
                        case arrowEnum.east:
                            this.transform.position = new Vector3(-6f, -4.5f, 1);
                            colourChange.color = Color.red;
                            break;

                        case arrowEnum.NW:
                            this.transform.position = new Vector3(-6, -3, 1);
                            colourChange.color = Color.green;
                            break;

                        case arrowEnum.north:
                            this.transform.position = new Vector3(-4.5f, -3, 1);
                            colourChange.color = Color.green;
                            break;
                    }
                    break;

                case 4:
                    switch (arrowType)
                    {
                        case arrowEnum.south:
                            this.transform.position = new Vector3(-7.5f, -3, 1);
                            colourChange.color = Color.red;
                            break;

                        case arrowEnum.SW:
                            this.transform.position = new Vector3(-6, -3, 1);
                            colourChange.color = Color.red;
                            break;

                        case arrowEnum.east:
                            this.transform.position = new Vector3(-6, -4.5f, 1);
                            colourChange.color = Color.green;
                            break;
                    }
                    break;
            }
        }
    }
}
