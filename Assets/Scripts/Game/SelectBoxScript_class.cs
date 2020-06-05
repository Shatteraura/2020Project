using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBoxScript_class : MonoBehaviour
{
    public Vector3 buttonPos;
    public CombatManager_class mRef;

    public Color normalColor = new Color(1, 1, 0, 1);
    public Color defColor = new Color(0, 0, 0, 1);
    public Color breakColour = new Color(1, 0, 0, 1);

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().color = normalColor;
        buttonPos = new Vector3(100, 100, 1);
    }

    // Update is called once per frame
    void Update()
    {
        switch (mRef.singleLock)
        {
            case false:
                this.GetComponent<SpriteRenderer>().color = normalColor;
                this.transform.position = buttonPos;
                break;

            case true:
                reColour();
                break;
        } 
    }

    void reColour()
    {
        switch (mRef.reverseState)
        {
            case false:

                break;

            case true:

                break;
        }
    }
}
