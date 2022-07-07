using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnemyMove instance;
    private Vector3 vt3;
    Rigidbody m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        vt3 = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vt3 * GameManager.instance.speedEn * Time.deltaTime);
    }
    public int countDiem = 0;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Diem"){
            countDiem++;
            RotateEn();
        }
    }
    public void RotateEn(){
        switch (countDiem)
        {
            case 1:case 2:case 4: case 5:
                transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);
                break;
            case 3: case 6: case 7: case 8:
                transform.Rotate(0.0f, -90.0f, 0.0f, Space.World);
                break;
            case 9: 
                    GameManager.instance.hpPlayer -= 1;
                    Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
