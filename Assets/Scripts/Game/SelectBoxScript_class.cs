using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBoxScript_class : MonoBehaviour
{
    public Vector3 buttonPos;

    // Start is called before the first frame update
    void Start()
    {
        buttonPos = new Vector3(100, 100, 1);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = buttonPos;
    }
}
