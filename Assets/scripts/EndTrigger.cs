using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

	public GameManger gamemanger;

	void OnTriggerEnter()
	{
		gamemanger.CompleteLevel ();
	}

	void LoadNextLevel(){
	}
}
