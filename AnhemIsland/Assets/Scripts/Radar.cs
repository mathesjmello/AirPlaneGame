using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {
    public Texture2D radarscreen;
    public GameObject pointer;
	// Use this for initialization
	void Start () {
        ClearScreen();
        InvokeRepeating("ClearScreen", 0, 2);
    }
	
    void ClearScreen()
    {
        Color currentpixel;
        for (int i = 0; i < radarscreen.height; i++)
        {
            for (int j = 0; j < radarscreen.width; j++)
            {
                if (new Vector2(i- radarscreen.width/2, j - radarscreen.width/2).magnitude > radarscreen.width/2)
                {
                    radarscreen.SetPixel(i, j, Color.clear);
                }
                else
                {
                    currentpixel = radarscreen.GetPixel(i, j);
                    radarscreen.SetPixel(i, j, Color.Lerp(currentpixel, Color.black, 0.5f));
                }
            }

        }
        radarscreen.Apply();
    }
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        transform.Rotate(0, 180 * Time.fixedDeltaTime, 0);
        pointer.transform.rotation = Quaternion.Euler(0, 0,-transform.rotation.eulerAngles.y-90);
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 newpos=((other.transform.position-transform.position)/2000)* radarscreen.width;
        print(newpos+" "+ other.gameObject.name);

        if (new Vector2((int)newpos.x, (int)newpos.z).magnitude > radarscreen.width/2)
        {
            return;
        }
        if (other.CompareTag("Enemy"))
        {
            radarscreen.SetPixel((int)newpos.x + radarscreen.height / 2, (int)newpos.z + radarscreen.width / 2, Color.red);
        }else
        {
            radarscreen.SetPixel((int)newpos.x + radarscreen.height / 2, (int)newpos.z + radarscreen.width / 2, Color.green);
        }
            radarscreen.Apply();
    }
}
