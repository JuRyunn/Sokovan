using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    private Renderer myRenderer;
    public Color touchColor;
    private Color originalColor;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        originalColor = myRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            myRenderer.material.color = touchColor;         
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "EndPoint")
        {
            myRenderer.material.color = originalColor;
        }
    }
}
