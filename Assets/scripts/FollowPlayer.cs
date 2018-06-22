using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform Player;
	private Vector3 offset;	

	void Start () {
		offset = transform.position - Player.transform.position;	
	}

	void Update () {
		transform.position = Player.position + offset;
	}
}
