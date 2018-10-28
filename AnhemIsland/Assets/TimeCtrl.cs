using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeCtrl : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		StopTime();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StopTime()
	{
		Time.timeScale = 0;
	}

	public void BackTime()
	{
		Time.timeScale = 1;
	}

	public void NextFase()
	{
		SceneManager.LoadScene("fase3");
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Reset()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
