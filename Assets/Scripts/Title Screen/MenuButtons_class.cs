using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TState { gameButton, exitButton, noButton }

public class MenuButtons_class : MonoBehaviour
{
    TState tState;

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
        if (tState == TState.gameButton)
        {
            if (Input.GetMouseButtonDown(0))
            {

            }
        }

        if (tState == TState.exitButton)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Application.Quit();
            }
        }
    }
}
