using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour {
	public PlayerMovement movement;		// A reference to our PlayerMovement script
	public Transform ObsObj;
	public float ZDistance= 103f ;
	public float ZDistance1= 103f ;

	public float RandNum;
	public float RandNum2;
	public float RandNum3;
	public float RandNum4;

	void Start()
	{
		InvokeRepeating("Spawn", .1f,.1f);
		//Spawn ();

	}


	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Obstacle")
		{
			// movement.enabled = false;
			FindObjectOfType<AudioManger>().Play("PlayerHit");
			Invoke( "EndLevel", 0.5f );


		//	FindObjectOfType<GameManger>().EndGame();
		}
	}

	void EndLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); 
	}

	void Spawn()
	{   
	
		RandNum = Random.Range(0,-6.47f);
		RandNum2 = Random.Range(6.33f,1);
		RandNum3 = Random.Range(-3,-6.47f);
		RandNum4 = Random.Range(3,6.33f);
		
		ZDistance = ZDistance +4f;
		Instantiate(ObsObj,new Vector3(RandNum,1f,ZDistance),ObsObj.rotation);
		Instantiate(ObsObj,new Vector3(RandNum2,1f,ZDistance+2),ObsObj.rotation);
		//Instantiate(ObsObj,new Vector3(RandNum3,1f,ZDistance+3),ObsObj.rotation);
		//Instantiate(ObsObj,new Vector3(RandNum4,1f,ZDistance+7),ObsObj.rotation);
		ZDistance += 8f;
	}

}
