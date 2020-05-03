using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLock_class : MonoBehaviour
{
    public CombatManager_class mRef;

    public Sprite[] lockSprites;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<SpriteRenderer>().sprite = lockSprites[mRef.comNodeLock];
    }
}
