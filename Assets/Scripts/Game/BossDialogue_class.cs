using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDialogue_class : MonoBehaviour
{
    public CombatManagerV2_class mRef;

    public Sprite[] bossDialogue;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(100, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (mRef.singleLock == true)
        {
            this.transform.position = new Vector3(100, 100, 0);
        }

        if (mRef.dialogueLock == true)
        {
            dialogueManager();
        }
    }

    void dialogueManager()
    {
        switch (mRef.dialogueNum)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = bossDialogue[0];
                this.transform.position = mRef.comDialogue;
                break;

            case 2:
                this.GetComponent<SpriteRenderer>().sprite = bossDialogue[1];
                this.transform.position = mRef.comDialogue;
                break;

            case 3:
                this.GetComponent<SpriteRenderer>().sprite = bossDialogue[2];
                this.transform.position = mRef.playerDialogue;
                break;

            case 4:
                this.GetComponent<SpriteRenderer>().sprite = bossDialogue[3];
                this.transform.position = mRef.comDialogue;
                break;

            case 5:
                this.GetComponent<SpriteRenderer>().sprite = bossDialogue[4];
                this.transform.position = mRef.playerDialogue;
                break;

            case 6:
                this.GetComponent<SpriteRenderer>().sprite = bossDialogue[5];
                this.transform.position = mRef.comDialogue;
                break;

            case 7:
                this.GetComponent<SpriteRenderer>().sprite = bossDialogue[6];
                this.transform.position = mRef.playerDialogue;
                break;

            case 8:
                this.GetComponent<SpriteRenderer>().sprite = bossDialogue[7];
                this.transform.position = mRef.playerDialogue;
                break;

            case 9:
                this.GetComponent<SpriteRenderer>().sprite = bossDialogue[8];
                this.transform.position = mRef.playerDialogue;
                break;

            case 10:
                this.GetComponent<SpriteRenderer>().sprite = bossDialogue[9];
                this.transform.position = mRef.comDialogue;
                break;

            case 11:
                this.GetComponent<SpriteRenderer>().sprite = bossDialogue[10];
                this.transform.position = mRef.comDialogue;
                break;

            case 12:
                mRef.dialogueLock = false;
                this.transform.position = new Vector3(100, 100, 0);
                break;
        }
    }
}
