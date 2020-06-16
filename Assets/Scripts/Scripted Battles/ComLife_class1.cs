using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComLife_class1 : MonoBehaviour
{
    public CombatManagerV2_class1 mRef;
    public int lifeNumCom;

    Vector3 hiddenPos = new Vector3(100, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        if (lifeNumCom == 1)
        {
            mRef.comLife1 = this.transform.position;
        }
        if (lifeNumCom == 2)
        {
            mRef.comLife2 = this.transform.position;
        }
        if (lifeNumCom == 3)
        {
            mRef.comLife3 = this.transform.position;
        }
        if (lifeNumCom == 4)
        {
            mRef.comLife4 = this.transform.position;
        }
        if (lifeNumCom == 5)
        {
            mRef.comLife5 = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        comLives();
    }

    void comLives()
    {
        if (mRef.computerHealth < lifeNumCom)
        {
            this.transform.position = hiddenPos;
        }
        else if (mRef.computerHealth >= lifeNumCom)
        {
            if (lifeNumCom == 1)
            {
                this.transform.position = mRef.comLife1;
            }
            if (lifeNumCom == 2)
            {
                this.transform.position = mRef.comLife2;
            }
            if (lifeNumCom == 3)
            {
                this.transform.position = mRef.comLife3;
            }
            if (lifeNumCom == 4)
            {
                this.transform.position = mRef.comLife4;
            }
            if (lifeNumCom == 5)
            {
                this.transform.position = mRef.comLife5;
            }
        }
    }
}
