using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComLife_class : MonoBehaviour
{
    public GameObject combatManagerRef;
    public int lifeNumCom;

    Vector3 hiddenPos = new Vector3(100, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        comLives();
    }

    void comLives()
    {
        if (combatManagerRef.GetComponent<CombatManager_class>().computerHealth < lifeNumCom)
        {
            this.transform.position = hiddenPos;
        }
    }
}
