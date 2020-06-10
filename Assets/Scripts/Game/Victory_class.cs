using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory_class : MonoBehaviour
{
    Vector3 winPos = new Vector3(0, 2, 0);

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(100, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void victoryDisplay()
    {
        this.transform.position = winPos;
    }
}
