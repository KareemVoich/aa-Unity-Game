using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManger : MonoBehaviour {
	bool gameHasEnded = false ;
	public float restartDelay = 1f;
	public GameObject CompleteLevelUi;

	public void CompleteLevel()
	{
		Debug.Log ("Laevel Complete ! ");
//		CompleteLevelUi.SetActive (true);
	}

	public void EndGame()
	{
		if (gameHasEnded == false) {
			gameHasEnded = true;
			Debug.Log ("Game Over");
			Invoke("Restart",restartDelay);
		}
	}

	void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

}
