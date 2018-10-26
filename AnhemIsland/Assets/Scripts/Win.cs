using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
	private CapsuleCollider _collider;
	public GameObject Balao1, Balao2, Balao3,Balao4;
	public GameObject Painel;
	// Use this for initialization
	void Start ()
	{
		_collider = gameObject.GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Balao1.activeSelf && !Balao2.activeSelf && !Balao3.activeSelf && !Balao4.activeSelf)
		{
			_collider.enabled=true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Painel.SetActive(true);
			StartCoroutine(NextLvl());
		}
	}

	IEnumerator NextLvl()
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene("fase2");
	}
}
