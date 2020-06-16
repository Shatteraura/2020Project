using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickGuide_class1 : MonoBehaviour
{
    public bool visible = false;
    public Vector3 hiddenPos = new Vector3(100, 100, 0);
    public Vector3 onScreen = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        cycleFunction();
    }

    void cycleFunction()
    {
        if (visible == false)
        {
            this.transform.position = hiddenPos;

            if (Input.GetKeyDown(KeyCode.H))
            {
                visible = true;
            }
        }
        else
        {
            this.transform.position = onScreen;

            if (Input.GetKeyDown(KeyCode.H))
            {
                visible = false;
            }
        }
    }
}
