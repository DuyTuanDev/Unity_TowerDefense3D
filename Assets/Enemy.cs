using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem mau;
    public Image imgHp;
    public float currentHp;
    public GameObject die;
    public AudioSource audioSource;
    public AudioClip tien;
    void Start()
    {
        imgHp.fillAmount = 1;
        currentHp = 1;
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        mau.gameObject.transform.position = gameObject.transform.position;
        imgHp.fillAmount = currentHp;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Bullets"){
            currentHp -= 0.1f;
            mau.Play();
            if(currentHp <= 0f){
                MakeDie();
            }
            Destroy(other.gameObject);
        }
    }

    
    private void MakeDie()
    {
        
        GameManager.instance.money += 50;
        GameManager.instance.currentMoney += 50;
        audioSource.PlayOneShot(tien);
        Instantiate(die, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
