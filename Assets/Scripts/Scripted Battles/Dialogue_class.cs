using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_class : MonoBehaviour
{
    public CombatManagerV2_class1 mRef;

    public Sprite[] dialogueArrayTutorio;
    public Sprite[] dialogueArrayDuo;
    public Sprite[] dialogueArrayTrio;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3 (100, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (mRef.singleLock == false)
        {
            chapterNum();
        }
        if (mRef.singleLock == true)
        {
            this.transform.position = new Vector3(100, 100, 0);
        }
    }

    void chapterNum()
    {
        // TUTORIO-----------------------------------------------------------------------------------------------
        if (mRef.dialogueChapter == 0)
        {
            mRef.currentOpponent = currentOpponentEnum.Tutorio;
            mRef.dialogueLock = true;

            switch (mRef.dialogueNum)
            {
                case 1:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[0];
                    this.transform.position = mRef.comDialogue;
                    break;

                case 2:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[1];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 3:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[2];
                    this.transform.position = mRef.comDialogue;
                    break;

                case 4:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[3];
                    this.transform.position = mRef.comDialogue;
                    break;

                case 5:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[4];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 6:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[5];
                    this.transform.position = mRef.playerDialogue;
                    mRef.dialogueLock = false;
                    break;
            }
        }

        if (mRef.dialogueChapter == 1)
        {
            mRef.dialogueLock = true;

            switch (mRef.dialogueNum)
            {
                case 1:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[6];
                    this.transform.position = mRef.comDialogue;
                    break;

                case 2:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[7];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 3:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[8];
                    this.transform.position = mRef.playerDialogue;
                    mRef.dialogueLock = false;
                    break;
            }
        }

        if (mRef.dialogueChapter == 2)
        {
            mRef.dialogueLock = true;
            if (mRef.buttonMode == buttonModeEnum.attackMode)
            {
                mRef.defLock = false;
            }
            else
            {
                mRef.defLock = true;
            }
            

            switch (mRef.dialogueNum)
            {
                case 1:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[9];
                    this.transform.position = mRef.comDialogue;
                    break;

                case 2:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[10];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 3:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[11];
                    this.transform.position = mRef.playerDialogue;
                    mRef.dialogueLock = false;
                    break;
            }
        }

        if (mRef.dialogueChapter == 3)
        {
            mRef.dialogueLock = true;

            switch (mRef.dialogueNum)
            {
                case 1:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[12];
                    this.transform.position = mRef.comDialogue;
                    break;

                case 2:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[13];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 3:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[14];
                    this.transform.position = mRef.playerDialogue;
                    mRef.dialogueLock = false;
                    break;
            }
        }

        if (mRef.dialogueChapter == 4)
        {
            mRef.dialogueLock = true;
            if (mRef.buttonMode == buttonModeEnum.defenceMode)
            {
                mRef.defLock = false;
            }
            else
            {
                mRef.defLock = true;
            }

            switch (mRef.dialogueNum)
            {
                case 1:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[15];
                    this.transform.position = mRef.comDialogue;
                    break;

                case 2:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[16];
                    this.transform.position = mRef.comDialogue;
                    break;

                case 3:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[17];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 4:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[18];
                    this.transform.position = mRef.playerDialogue;
                    mRef.dialogueLock = false;
                    break;
            }
        }

        if (mRef.dialogueChapter == 5)
        {
            mRef.dialogueLock = true;
            mRef.defLock = false;
            switch (mRef.dialogueNum)
            {
                case 1:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[19];
                    this.transform.position = mRef.comDialogue;
                    break;

                case 2:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTutorio[20];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 3:
                    mRef.computerHealth = 5;
                    mRef.currentOpponent = currentOpponentEnum.Duo;
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayDuo[0];
                    this.transform.position = mRef.comDialogue;
                    mRef.dialogueChapter = 6;
                    mRef.dialogueNum = 0;
                    break;
            }
        }

        if (mRef.dialogueChapter == 6)
        {
            switch (mRef.dialogueNum)
            {
                case 1:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayDuo[1];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 2:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayDuo[2];
                    this.transform.position = mRef.comDialogue;
                    break;

                case 3:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayDuo[3];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 4:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayDuo[4];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 5:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayDuo[5];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 6:
                    mRef.dialogueLock = false;
                    mRef.dialogueChapter = 7;
                    this.transform.position = new Vector3(100, 100, 0);
                    break;
            }
        }

        if (mRef.dialogueChapter == 7)
        {
            mRef.dialogueNum = 1;
        }

        if (mRef.dialogueChapter == 8)
        {
            switch (mRef.dialogueNum)
            {
                case 1:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayDuo[6];
                    this.transform.position = mRef.comDialogue;
                    break;

                case 2:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayDuo[7];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 3:
                    mRef.computerHealth = 5;
                    mRef.currentOpponent = currentOpponentEnum.Trio;
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[0];
                    this.transform.position = mRef.comDialogue;
                    mRef.dialogueChapter = 9;
                    mRef.dialogueNum = 0;
                    break;
            }
        }

        if (mRef.dialogueChapter == 9)
        {
            switch (mRef.dialogueNum)
            {
                case 1:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[1];
                    this.transform.position = mRef.comDialogue;
                    break;
                case 2:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[2];
                    this.transform.position = mRef.playerDialogue;
                    break;
                case 3:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[3];
                    this.transform.position = mRef.comDialogue;
                    break;
                case 4:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[4];
                    this.transform.position = mRef.playerDialogue;
                    break;
                case 5:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[5];
                    this.transform.position = mRef.playerDialogue;
                    break;
                case 6:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[6];
                    this.transform.position = mRef.playerDialogue;
                    break;
                case 7:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[7];
                    this.transform.position = mRef.comDialogue;
                    break;
                case 8:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[8];
                    this.transform.position = mRef.playerDialogue;
                    break;
                case 9:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[9];
                    this.transform.position = mRef.comDialogue;
                    break;
                case 10:
                    mRef.dialogueLock = false;
                    this.transform.position = new Vector3(100, 100, 0);
                    mRef.dialogueChapter = 10;
                    mRef.dialogueNum = 0;
                    break;
            }
        }

        if (mRef.dialogueChapter == 10)
        {
            mRef.dialogueNum = 1;
        }

        if (mRef.dialogueChapter == 11)
        {
            switch (mRef.dialogueNum)
            {
                case 1:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[10];
                    this.transform.position = mRef.comDialogue;
                    break;

                case 2:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[11];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 3:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[12];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 4:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[13];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 5:
                    this.GetComponent<SpriteRenderer>().sprite = dialogueArrayTrio[14];
                    this.transform.position = mRef.playerDialogue;
                    break;

                case 6:
                    this.transform.position = new Vector3(100, 100, 0);
                    mRef.playerWin = true;
                    break;
            }
        }
    }
}
