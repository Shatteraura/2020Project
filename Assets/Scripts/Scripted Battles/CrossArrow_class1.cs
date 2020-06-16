using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossArrow_class1 : MonoBehaviour
{
    public CombatManagerV2_class1 mRef;

    public crossEnum crossSprite;

    public Sprite[] arrowDir;

    public Color crossColor;

    public Color keepArrowColor;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = arrowDir[0];
        mRef.middle = this.transform.position;
        crossColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        buttonHover();
        colourManager();
        if (mRef.singleLock == false)
        {
            this.GetComponent<SpriteRenderer>().color = crossColor;
        }

        if (mRef.singleLock == true && mRef.arrowKeep == arrowKeepEnum.cross)
        {
            crossColor = keepArrowColor;
            this.GetComponent<SpriteRenderer>().color = crossColor;
        }
    }

    void buttonHover()
    {
        this.GetComponent<SpriteRenderer>().sprite = arrowDir [(int)crossSprite];
    }

    void colourManager()
    {
        if (mRef.arrowRecolour == arrowRecolourEnum.red)
        {
            keepArrowColor = Color.red;
        }
        if (mRef.arrowRecolour == arrowRecolourEnum.green)
        {
            keepArrowColor = Color.green;
        }
        if (mRef.arrowRecolour == arrowRecolourEnum.grey)
        {
            keepArrowColor = Color.grey;
        }
    }
}
