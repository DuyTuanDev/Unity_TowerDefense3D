using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public static targetSpawn instance;
    public Color hoverColor;
    // public Color hoverColor1;

    public int indexEn;
    private Renderer render;
    private Color startColor;
    Color colorSs = Color.yellow;
    Color colorError = Color.red;
    public AudioSource audioSource;
    public AudioClip error;
    void Start()
    {
        instance = this;
        render = GetComponent<Renderer>();
        startColor = render.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.money < 100){
            GameManager.instance.btnBullets.text = "Ko đủ $";
            GameManager.instance.indexEn = -1;
        }
    }
    private void OnMouseDown() {
        if(GameManager.instance.money < 100 || GameManager.instance.indexEn == -1){
            audioSource.PlayOneShot(error);
            // GameManager.instance.btnBullets.text = "Ko đủ $";
            return;
        }
        
        GameManager.instance.SpawnBullets(transform.position);
        GameManager.instance.indexEn = -1;
        
        GameManager.instance.money -= 100;
    }
    
    private void OnMouseEnter() {
        if(GameManager.instance.money < 99){
            render.material.color = colorError;
        }
        else{
            render.material.color = colorSs;
        }
        
    }
    void OnMouseExit()
    {  
       render.material.color = startColor;
    }
}
