using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {
	public Transform Player;
	public Text ScoreText;
	public Text HighScore;

	public static int PlayerHighScore;
	public string score ;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		ScoreText.text = Player.position.z.ToString("0"); 

		score = Player.position.z.ToString("0"); 
		int RegularScore  = int.Parse (score);
		PlayerPrefs.SetInt ("RegularScore", RegularScore);

		PlayerHighScore = PlayerPrefs.GetInt ("PlayerHighScore");
		if (RegularScore > PlayerHighScore) {
			PlayerHighScore = RegularScore;
			PlayerPrefs.SetInt ("PlayerHighScore", PlayerHighScore);

		}
		
	}
}
