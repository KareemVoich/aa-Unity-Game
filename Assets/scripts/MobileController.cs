using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobileController : MonoBehaviour {
	private Vector2 fingerDown;
	private Vector2 fingerUp;
	public bool detectSwipeOnlyAfterRelease = false;
	
	public float SWIPE_THRESHOLD = 20f;

	public Rigidbody rb;
	public float ForwardForce = 2000f;
	public float SideWaysForce = 500f;
	

	void Update()
	{
		rb.AddForce (0, 0, ForwardForce *Time.deltaTime);
		
		if (Input.GetKey ("right")) {
			rb.AddForce(SideWaysForce *Time.deltaTime ,0,0,ForceMode.VelocityChange);
		}
		
		if (Input.GetKey ("left")) {
			rb.AddForce(-SideWaysForce *Time.deltaTime ,0,0,ForceMode.VelocityChange);
		}
		
		if (rb.position.y < 0f) 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); 

		//	FindObjectOfType<GameManger>().EndGame();
		}

		
		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				fingerUp = touch.position;
				fingerDown = touch.position;
			}
			
			//Detects Swipe while finger is still moving
			if (touch.phase == TouchPhase.Moved)
			{
				if (!detectSwipeOnlyAfterRelease)
				{
					fingerDown = touch.position;
					checkSwipe();
				}
			}
			
			//Detects swipe after finger is released
			if (touch.phase == TouchPhase.Ended)
			{
				fingerDown = touch.position;
				checkSwipe();
			}
		}
	}
	
	void checkSwipe()
	{
		//Check if Vertical swipe
		if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
		{
			//Debug.Log("Vertical");
			if (fingerDown.y - fingerUp.y > 0)//up swipe
			{
				OnSwipeUp();
			}
			else if (fingerDown.y - fingerUp.y < 0)//Down swipe
			{
				OnSwipeDown();
			}
			fingerUp = fingerDown;
		}
		
		//Check if Horizontal swipe
		else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
		{
			//Debug.Log("Horizontal");
			if (fingerDown.x - fingerUp.x > 0)//Right swipe
			{
				OnSwipeRight();
			}
			else if (fingerDown.x - fingerUp.x < 0)//Left swipe
			{
				OnSwipeLeft();
			}
			fingerUp = fingerDown;
		}
		
		//No Movement at-all
		else
		{
			//Debug.Log("No Swipe!");
		}
	}
	
	float verticalMove()
	{
		return Mathf.Abs(fingerDown.y - fingerUp.y);
	}
	
	float horizontalValMove()
	{
		return Mathf.Abs(fingerDown.x - fingerUp.x);
	}
	
	//////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////
	void OnSwipeUp()
	{
		Debug.Log("Swipe UP");
	}
	
	void OnSwipeDown()
	{
		Debug.Log("Swipe Down");
	}
	
	void OnSwipeLeft()
	{
		rb.AddForce(-SideWaysForce *Time.deltaTime ,0,0,ForceMode.VelocityChange);
	}
	
	void OnSwipeRight()
	{
		rb.AddForce(SideWaysForce *Time.deltaTime ,0,0,ForceMode.VelocityChange);
	}

	public void PressRight()
	{

		rb.AddForce(SideWaysForce *Time.deltaTime ,0,0,ForceMode.VelocityChange);

	}
	public void PressLeft()
	{
		
		rb.AddForce(-SideWaysForce *Time.deltaTime ,0,0,ForceMode.VelocityChange);
		
	}
}