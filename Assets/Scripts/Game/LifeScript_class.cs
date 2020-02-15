using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript_class : MonoBehaviour
{

    public GameObject combatManagerRef;
    public int lifeNumPlayer;
    public int lifeNumCom;

    Vector3 hiddenPos = new Vector3(100, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerLives();
        comLives();
    }


    //Governs Hiding The Lives When They Are Lost
    void playerLives()
    {
        if (combatManagerRef.GetComponent<CombatManager_class>().playerHealth < lifeNumPlayer)
        {
            this.transform.position = hiddenPos;
        }

    }

    void comLives()
    {
        if (combatManagerRef.GetComponent<CombatManager_class>().computerHealth < lifeNumCom)
        {
            this.transform.position = hiddenPos;
        }
    }
}
