using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLock_class : MonoBehaviour
{
    public CombatManagerV2_class mRef;

    public Sprite[] lockSprites;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = lockSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (mRef.singleLock == true)
        {
            this.GetComponent<SpriteRenderer>().sprite = lockSprites[mRef.comPrev];
        }
    }
}
