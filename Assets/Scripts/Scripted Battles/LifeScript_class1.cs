using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript_class1 : MonoBehaviour
{
    public CombatManagerV2_class1 combatManagerRef;
    public int lifeNumPlayer;

    Vector3 hiddenPos = new Vector3(100, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerLives();
    }


    //Governs Hiding The Lives When They Are Lost
    void playerLives()
    {
        if (combatManagerRef.playerHealth < lifeNumPlayer)
        {
            this.transform.position = hiddenPos;
        }

    }
}
