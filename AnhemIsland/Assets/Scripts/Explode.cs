﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    float timetrigger =2;
    public GameObject explosion;
    public GameObject Painel;
    public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.parent == null && 
            timetrigger>0)
        {
            timetrigger -= Time.deltaTime;
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if (timetrigger > 0)
        {
            return;
        }
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 50, Vector3.up, 1);
        foreach(RaycastHit hit in hits)
        {
            if (!hit.collider.gameObject == Player)
            {
                hit.rigidbody.AddExplosionForce(10000, transform.position, 50);

                Destroy(hit.collider.gameObject, Random.Range(3, 10));
            }
            
        }
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<AudioSource>().Play();
        
        Destroy(gameObject,2);
        Instantiate(explosion, transform.position, Quaternion.LookRotation(Vector3.up));
        StartCoroutine(Nothing());
    }

    IEnumerator Nothing()
    {
        yield return new WaitForSeconds (5);
        Instantiate(Painel);
        Painel.SetActive(true);
    }
}
