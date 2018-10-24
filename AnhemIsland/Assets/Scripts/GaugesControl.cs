using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GaugesControl : MonoBehaviour {
    public AirplanePhisics player;
    public GameObject compass;
    public GameObject altimeterPointer0,altimeterPointer1,altimeterPointer2;
    public GameObject spedometerpointer;
    // Use this for initialization
    void Start () {
		
	}
	
    void Altimeter()
    {
        float altitude = player.transform.position.y * -0.1f;
        altimeterPointer0.transform.localRotation = Quaternion.Euler(0, 0, altitude * 360);
        float altitude2 = player.transform.position.y * -0.01f;
        altimeterPointer1.transform.localRotation = Quaternion.Euler(0, 0, altitude2 * 360);
        float altitude3 = player.transform.position.y * -0.001f;
        altimeterPointer2.transform.localRotation = Quaternion.Euler(0, 0, altitude3 * 360);
    }
    void Compass()
    {
        float airplanedegrees = player.transform.rotation.eulerAngles.y;
        compass.transform.localRotation = Quaternion.Euler(0, 0, airplanedegrees);
    }
    void Spedometer()
    {
        float speed = (player.rdb.velocity.magnitude* 1.9438445f) ;
        //print(speed);
        speed = Mathf.Clamp(speed, 20, 1000);
        spedometerpointer.transform.localRotation = Quaternion.Euler(0, 0, -speed * 1.55f);
    }

    void Update () {
        if (!player) return;
        Compass();
        Altimeter();
        Spedometer();
    }
}
