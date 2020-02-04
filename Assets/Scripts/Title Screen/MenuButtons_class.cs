using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum TStateEnum { gameButton, exitButton, noButton }

public class MenuButtons_class : MonoBehaviour
{
    TStateEnum tState;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        buttonPress();
    }

    void buttonPress()
    {
        if (tState == TStateEnum.gameButton)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Game", LoadSceneMode.Single);
            }
        }

        if (tState == TStateEnum.exitButton)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Application.Quit();
            }
        }
    }
}
