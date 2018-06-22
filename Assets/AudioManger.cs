using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManger : MonoBehaviour {


	public Sound[] sounds ;
	public static AudioManger instance;
	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}
		

		DontDestroyOnLoad (gameObject);
		foreach (Sound s in sounds) 
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.Clip ;

			s.source.volume = s.Volume ;
			s.source.pitch  = s.Pitch;
			s.source.loop   = s.loop;

		}
	}

	void Start ()
	{
		Play ("GameMusic");
	}
	
	public void Play (string Name)
	{
		Sound s = Array.Find (sounds, sound => sound.Name == Name);
		if (s == null) 
		{
			Debug.LogWarning("Sound : "+ Name + " Not Found !");
			return;

		}

		s.source.Play ();

	}
}
