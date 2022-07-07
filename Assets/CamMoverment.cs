using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamMoverment : MonoBehaviour
{
    //Camera Movement
    public float panSpeed = 30f;
    public float panBorder = 2f;

    private bool move = true;

    //Scrolling
    private float scrollSpeed = 2f;
    public float minY = 3f;
    public float maxY = 20f;

    public Slider zoomSlider;
    // public Camera cams;

    void Start() {
        // zoomSlider = GetComponent<Slider>();
    //    zoomSlider.value = zoomSlider.maxValue;
        zoomSlider.minValue = minY;
        zoomSlider.maxValue = maxY;
        zoomSlider.value = 7;
        
    }
    // public Transform cams;
    public float speed;
    public Joystick Joystick;
    void MoveJs(){
        float x = Joystick.Horizontal * speed;
        float y = Joystick.Vertical * speed;
        if(y > 3f){
            if (transform.position.z >= 12f) {
               return;
            }
            transform.Translate(Vector3.forward * (panSpeed - 10f) * Time.deltaTime, Space.World);
        }
        else if(y < -3f){
            if (transform.position.z <= -24f) {
                return;
            }
            transform.Translate(Vector3.back * (panSpeed - 10f) * Time.deltaTime, Space.World);
        }
        else if(x > 3f){
            if (transform.position.x >= 22f) {
                return;
            }
            transform.Translate(Vector3.right * (panSpeed - 10f) * Time.deltaTime, Space.World);
        }
        else if(x < -3f){
            if (transform.position.x <= -22f) {
                return;
            }
            transform.Translate(Vector3.left * (panSpeed - 10f) * Time.deltaTime, Space.World);
        }
    }
	void Update () {
        MoveJs();
        if (Input.GetKeyDown(KeyCode.Escape))
            move = !move;
        if (!move)
            return;

        if (Input.GetKey("w"))
        {
            if (transform.position.z >= 12f) {
               return;
            }
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s"))// || Input.mousePosition.y <= panBorder)
        {
            Debug.Log("Move Backward");
            if (transform.position.z <= -24f) {
               return;
            }
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d"))//|| Input.mousePosition.x >= Screen.width - panBorder)
        {
            if (transform.position.x >= 22f) {
               return;
            }
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a"))// || Input.mousePosition.x <= panBorder)
        {
            if (transform.position.x <= -22f) {
               return;
            }
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(zoomSlider.value, minY, maxY);

        transform.position = pos;

        // cams.fieldOfView = zoomSlider.value;
    }

}
