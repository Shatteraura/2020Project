using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defeat_class : MonoBehaviour
{
    Vector3 defPos = new Vector3(0, 1.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(100, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void defeatDisplay()
    {
        this.transform.position = defPos;
    }
}
