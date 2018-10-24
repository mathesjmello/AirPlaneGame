using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour {
    public GameObject bomb;
    public ParticleSystem cannon;
    public ParticleSystem cannon2;
    public AudioSource cannonsound, cannonsound2;
    bool firetime = false;
	// Use this for initialization
	void Start () {
        InvokeRepeating("GunUpdate", 0, 0.1f);
	}
    void GunUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            if (firetime)
            {
                cannon.Emit(1);
                cannonsound.Play();
            }
            else
            {
                cannon2.Emit(1);
                cannonsound2.Play();
            }
            firetime = !firetime;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            bomb.transform.parent = null;
            bomb.GetComponent<Rigidbody>().isKinematic =
                false;
            bomb.GetComponent<Rigidbody>().velocity =
                GetComponent<Rigidbody>().velocity;
        }
	}
}
