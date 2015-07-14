using UnityEngine;
using System.Collections;

public class CorrectLight : MonoBehaviour {

	public static ArrayList correctLights = new ArrayList();
	public Animator setCorrectLight;

	void Start()
	{
		correctLights.Add (setCorrectLight);
	}

	public static void LightShow()
	{

		foreach(Animator correctLight in CorrectLight.correctLights)
			correctLight.Play("lightOn");
	}

}
