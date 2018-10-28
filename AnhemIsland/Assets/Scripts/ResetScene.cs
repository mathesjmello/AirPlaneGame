using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		StartCoroutine(Example());
	}

	IEnumerator Example()
	{
		Debug.LogError("wtf");
		Debug.Log(this.gameObject.name);
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
