using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;
    public Text countEnemy;
    public Text textMoney;
    public Text textHp;
    public Text textLv;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        countEnemy.text = "Enemy: " + SpawnEnemy.instance.enemies.Length;
        textMoney.text = "Có: " + GameManager.instance.money + "$";
        textHp.text = "Hp: " + GameManager.instance.hpPlayer;
        textLv.text = "Lv: " + SpawnEnemy.instance.lever;
    }
}
