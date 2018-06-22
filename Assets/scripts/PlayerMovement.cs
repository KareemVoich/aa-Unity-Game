using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;
	public float ForwardForce = 2000f;
	public float SideWaysForce = 500f;

	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce (0, 0, ForwardForce *Time.deltaTime);

		if (Input.GetKey ("right")) {
			rb.AddForce(SideWaysForce *Time.deltaTime ,0,0,ForceMode.VelocityChange);
		}

		if (Input.GetKey ("left")) {
			rb.AddForce(-SideWaysForce *Time.deltaTime ,0,0,ForceMode.VelocityChange);
		}

		if (rb.position.y < -1f) 
		{

			FindObjectOfType<GameManger>().EndGame();
		}
	}
}
