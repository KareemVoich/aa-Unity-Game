using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class inoutTouchController : MonoBehaviour, IPointerDownHandler,
IPointerUpHandler {
	public MobileController Script;
	bool pressed = false;


	public void OnPointerDown(PointerEventData eventData)
	{
		pressed = true;
	}
	
	public void OnPointerUp(PointerEventData eventData)
	{
		pressed = false;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (pressed && this.gameObject.name == "Right") {	
			Script.PressRight ();
		}

		if (pressed && this.gameObject.name == "Left") {	
			Script.PressLeft ();
		}
	}
}
