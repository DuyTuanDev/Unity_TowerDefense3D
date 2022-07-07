using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public static SpawnEnemy instance;
    // private float spawnDelay = 2;
    // private float spawnInterval = 1.5f;
    public GameObject[] enemies;
    public GameObject enemy;
    public bool nextLv = false;
    public int maxEnemy = 1;
    public int countEnemy = 0;
    void Start()
    {
        instance = this;
        // InvokeRepeating("SpawnEnemys", spawnDelay, spawnInterval);
        StartCoroutine(WaitingNextLv());
    }
    public int lever = 1;
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // if(enemies.Length == 0){
        //     return;
        // }
        // SpawnEnemys();
        
        if(enemies.Length <= 0 && nextLv){
            lever++;
            maxEnemy += 1; 
            countEnemy = 0;
            GameManager.instance.currentLv = lever; 
            if(lever % 5 == 0 && nextLv){
                GameManager.instance.speedEn += 1.75f;
            }
            if(lever % 2 == 0 && nextLv){
                maxEnemy += 1;
            }
            StartCoroutine(WaitingNextLv());
            nextLv = false;
        }
        
    }
    IEnumerator TimeStartGame(){
        yield return new WaitForSeconds(5f);
        StartCoroutine(SpawnEnemys());
    }
    IEnumerator SpawnEnemys(){
        while(countEnemy < maxEnemy){
            yield return new WaitForSeconds(1f);
            Instantiate(enemy, transform.position, enemy.transform.rotation);
            countEnemy++;
            
        }
        nextLv = true;
    }
    IEnumerator WaitingNextLv(){
        yield return new WaitForSeconds(5f);
        
        StartCoroutine(SpawnEnemys());
    }

    void SpawnObjects ()
    {
        // if()
        // Set random spawn location and random object index
        // Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        // int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        // if (!playerControllerScript.gameOver)
        // {
        
        // }

    }
    
}
