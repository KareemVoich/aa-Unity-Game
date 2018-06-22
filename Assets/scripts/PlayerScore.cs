using UnityEngine;
using UnityEngine.UI;
public class PlayerScore : MonoBehaviour {
	public Text RegularScore;
	
	
	// Use this for initialization
	void Start () {
		RegularScore.text = PlayerPrefs.GetInt ("RegularScore").ToString ();
	}


}
