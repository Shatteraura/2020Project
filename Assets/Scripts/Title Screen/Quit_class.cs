using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_class : MonoBehaviour
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
        Application.Quit(); 
    }
}
