using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplanePhisics : MonoBehaviour {
    public Rigidbody rdb;
    public GameObject propeller;
    public GameObject profundor;
    public GameObject aileronR, aileronL;
    public AudioSource motorsound;
    Vector3 control;
    public float lift = 100;
    public float motorPower = 10000;
    public float trotle = 0.1f;
    public float aerodinamic = 0.001f;

    public int hull = 100;


    public GameObject explosion;
    public ParticleSystem smoke;
    ParticleSystem.EmissionModule emitter;

    public WheelCollider[] rodas;
    // Use this for initialization
    void Start () {
        rdb = GetComponent<Rigidbody>();
        motorsound = GetComponent<AudioSource>();
        foreach(WheelCollider roda in rodas)
        {
            roda.motorTorque = 0.00001f;
        }
    }
    void Update () {
        InputControl();
        if (hull > 0)
        {
            propeller.transform.Rotate(0, 0, 85 * trotle);
            profundor.transform.localRotation = Quaternion.Euler(new Vector3(control.x * -15, 0, 0));
            aileronL.transform.localRotation = Quaternion.Euler(new Vector3(control.z * -15, 0, 0));
            aileronR.transform.localRotation = Quaternion.Euler(new Vector3(control.z * 15, 0, 0));
        }
        
        
    }
    void InputControl()
    {
      
        if (Input.GetButton("Fire3"))
        {
            trotle += Time.deltaTime;
        }
        if (Input.GetButton("Fire1"))
        {
            trotle -= Time.deltaTime;
        }
        trotle = Mathf.Clamp01(trotle);

        control = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal") * 2);

        if (control.x > 0)
        {
            foreach (WheelCollider roda in rodas)
            {
                roda.brakeTorque = 3000;
            }
        }else
        {
            foreach (WheelCollider roda in rodas)
            {
                roda.brakeTorque = 00;
            }
        }
    }
    void FixedUpdate()
    {
        motorsound.pitch = trotle * 2 + rdb.velocity.magnitude * 0.05f;
        rdb.drag = 0;
        if (hull > 0)
        {
            rdb.AddForce(transform.forward * motorPower * trotle);
            rdb.drag = rdb.velocity.magnitude * aerodinamic;
        }
        rdb.AddForce(transform.up * lift * rdb.velocity.magnitude);
        rdb.AddRelativeTorque(control*1000);

       
    }

    private void OnParticleCollision(GameObject other)
    {
        if (hull < 10)
        {
            smoke.Play();
        }
        hull--;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 10)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
