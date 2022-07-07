using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickIndex : MonoBehaviour
{
    public static ClickIndex instance;
    public Color hoverColor;
    public Color hoverColor1;
    public int indexEn;

    private Renderer render;
    private Color startColor;
    // public GameObject[] Bullets;
    void Start()
    {
        instance = this;
        render = GetComponent<Renderer>();
        startColor = render.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() {
        // Debug.Log("Click");
        render.material.color = hoverColor;
        // Instantiate(Bullets[Random.Range(0, Bullets.Length)], transform.position, Quaternion.identity);
        
    }
    private void OnMouseEnter() {
        
    }
    void OnMouseExit()
    {  
    //    render.material.color = startColor;
    }
}
