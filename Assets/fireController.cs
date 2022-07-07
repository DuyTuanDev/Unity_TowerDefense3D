using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireController : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float turretRange = 15f;
    private float fireCountdown = 0f;
    public float fireRate = 1f;
    public string enemyTag = "Enemy";
    public GameObject[] enemies;
    public Transform target;
    private Enemy targetEnemy;
    public Transform partToRotate;
    private int countShort;
    public ParticleSystem dan;
    public AudioSource audioSource;
    public AudioClip ban;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        countShort = 0;
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }
    void Update()
    {
        if (target == null) {
            dan.Pause();
            return;
        }
        LockOnTarget();
        // StartCoroutine(timedoi());
        // if(gameObject.transform.position == target.position){
        //     return;
        // }
        if (fireCountdown <= 0f) {
                ShootEnemy();
                fireCountdown = 0.5f / fireRate;
            }
        fireCountdown -= Time.deltaTime;
    }  
    void LockOnTarget() {   
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * 15f).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
    }
    void UpdateTarget() {
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance < shortestDistance) {
                shortestDistance = enemyDistance;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= turretRange)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else {
            target = null;
        }
    }
    void ShootEnemy(){
        if(countShort == 0){
            countShort++;
        }
        else{
            dan.Play();
            audioSource.PlayOneShot(ban);
            GameObject bulletFire = (GameObject) Instantiate(bullet, firePoint.position, firePoint.rotation);
            countShort = 1;
        }
        
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
