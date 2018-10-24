using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretIA : MonoBehaviour {
    public GameObject tgt;
    public Transform vaxis,haxis;
    GameObject virtualAim;
    public ParticleSystem fire;
    public float gunAimPreview;
    Rigidbody playerrdb;
	// Use this for initialization
	void Start () {
        virtualAim = new GameObject("vAim");
        virtualAim.transform.SetParent(transform,false);
    }
	void Update () {
        if (tgt!=null){
            float dist = Vector3.Distance(transform.position, tgt.transform.position);
            virtualAim.transform.LookAt(tgt.transform.position + playerrdb.velocity * (dist * gunAimPreview));
        }

        vaxis.localRotation = Quaternion.Euler(0, virtualAim.transform.localEulerAngles.y, 0);
        haxis.localRotation = Quaternion.Euler(virtualAim.transform.localEulerAngles.x, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tgt = other.gameObject;
            playerrdb = tgt.GetComponent<Rigidbody>();
            fire.Play();
        }
    }
}
