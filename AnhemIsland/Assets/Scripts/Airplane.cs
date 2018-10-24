using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour {
    public GameObject propeller;
    public GameObject profundor;
    public GameObject aileronR, aileronL;
    Vector3 control;

	// Use this for initialization
	void Start () {
		
	}
    void InputControl()
    {
        control = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal")*2);
    }
    void SurfaceControl()
    {
        propeller.transform.Rotate(0, 0, 85);
        profundor.transform.localRotation = Quaternion.Euler(new Vector3(control.x * -15, 0, 0));
        aileronL.transform.localRotation = Quaternion.Euler(new Vector3(control.z * -15, 0, 0));
        aileronR.transform.localRotation = Quaternion.Euler(new Vector3(control.z * 15, 0, 0));
    }
    void PhisicalControl()
    {
        transform.Rotate(control);
        transform.position += transform.forward * Time.deltaTime * 50;
    }
	void Update () {
        InputControl();
        SurfaceControl();
        PhisicalControl();
	}
}
