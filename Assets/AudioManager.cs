using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioManager audioManager;

	public AudioSource successSound;
	public AudioSource failureSound;

	// Use this for initialization
	void Start () 
	{
		audioManager = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void PlaySuccess()
	{
		successSound.Play ();
	}

	public void PlayFailure()
	{
		failureSound.Play ();
	}
}
