//using UnityEngine;
//using System.Collections;
//
//public class AnswerScript : MonoBehaviour {
//
//	public senseix.PromptDisplay targetQuestion;
//
//	private ulong answerSoFar = 0; //keeps the player's input so far.
//
//	// Use this for initialization
//	void Start () 
//	{
//	
//	}
//	
//	// Update is called once per frame
//	void Update () 
//	{
//	
//	}
//
//	//returns a string representing the player's input
//	public string GetAnswerString()
//	{
//		string answerString;
//		if (answerSoFar == 0)
//			answerString = "";
//		else 
//		{
//			answerString = answerSoFar.ToString();
//		}
//		return answerString;
//	}
//
//	public ulong GetAnswerValue()
//	{
//		return answerSoFar;
//	}
//
//	//on the click of the submit button, submits the player's answer so far to the question for handling
//	public void Submit()
//	{
//		targetQuestion.SubmitAnswer (answerSoFar);
//		answerSoFar = 0; //reset input to nothing
//	}
//
//	//adds a number in the next digit space representing the number the player clicked.
//	//so far, only numbers up to 18 digits are supported
//	public void AnswerButtonClick(int buttonValue)
//	{
//		if (answerSoFar.ToString ().Length > 18)
//			return;
//		answerSoFar = answerSoFar * 10;
//		answerSoFar += (uint)buttonValue;
//	}
//
//	//removed the number in the frontmost digit space
//	public void BackspaceButtonClick()
//	{
//		answerSoFar = answerSoFar / 10;
//	}
//
//}
