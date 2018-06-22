﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	public void Quit(){
		Application.Quit();
	}

	public void PlayAgain(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1); 
	}
}


