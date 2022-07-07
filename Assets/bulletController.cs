using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float speed = 100f;
    Rigidbody myBody;
    // public Transform trans;
    
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        myBody.AddForce(transform.forward * speed);
        Destroy(gameObject, 1f);
    }
    void Update()
    {

    }

}
