﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_class : MonoBehaviour
{
    public Sprite normal;
    public Sprite highlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        this.GetComponent<SpriteRenderer>().sprite = highlight;
    }

    private void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().sprite = normal;
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Scripted Battles", LoadSceneMode.Single);
    }
}
