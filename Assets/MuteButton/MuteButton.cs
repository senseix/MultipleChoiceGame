using UnityEngine;
using System.Collections;

public class MuteButton : MonoBehaviour {
	
	public Sprite mutedSprite;
	public Sprite unmutedSprite;

	private bool muted = false;

	public void MuteButtonPress()
	{
		if (!muted)
		{
			GetComponent<UnityEngine.UI.Image>().sprite = mutedSprite;
			AudioListener.volume = 0;
		}
		else
		{
			GetComponent<UnityEngine.UI.Image>().sprite = unmutedSprite;
			AudioListener.volume = 1;
		}
		muted = !muted;
	}
}