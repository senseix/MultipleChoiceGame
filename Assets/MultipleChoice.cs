using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MultipleChoice : MonoBehaviour {

	public UnityEngine.UI.Text[] answerButtonTexts;

	private ArrayList availableAnswers = new ArrayList();


	// Use this for initialization
	void Start () 
	{
		NextProblem ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	private void NextProblem()
	{
		ThinksyPlugin.NextProblem ();
		UpdateDisplay ();
	}

	private void UpdateDisplay()
	{
		UpdateAnswers ();
		UpdateButtons ();
	}

	private void UpdateAnswers()
	{
		availableAnswers.Clear ();
		ProblemPart[] wrongAnswers = ThinksyPlugin.GetMostRecentProblemDistractors(answerButtonTexts.Length-1);
		foreach (ProblemPart wrongAnswer in wrongAnswers)
		{ //add the number of buttons minus one wrong answers
			availableAnswers.Add(wrongAnswer);
		}
		availableAnswers.Add (ThinksyPlugin.GetCurrentCorrectAnswerPart());
		//add the one right answer
		
		Shuffle (availableAnswers);
	}

	private void Shuffle (ArrayList shuffleMe)
	{
		System.Random random = new System.Random();
		int currentIndex = shuffleMe.Count;
		while (currentIndex > 1)
		{
			currentIndex--;
			int swapIndex = random.Next(currentIndex+1);
			object swapTemp =  shuffleMe[swapIndex];
			shuffleMe[swapIndex] = shuffleMe[currentIndex];
			shuffleMe[currentIndex] = swapTemp;
		}
	}

	private void UpdateButtons ()
	{
		char[] letters = new char[]{'A', 'B', 'C', 'D', 'E'};
		for (int i = 0; i < answerButtonTexts.Length; i++)
		{ //set button text
			ProblemPart part = (ProblemPart)availableAnswers[i];
			answerButtonTexts[i].text = "(" + letters[i] + ") " + part.GetString();
		}
	}

	private void SubmitAnswers()
	{
		if (ThinksyPlugin.SubmitMostRecentProblemAnswer())
			AudioManager.audioManager.PlaySuccess();
		else
			AudioManager.audioManager.PlayFailure();
		NextProblem();
	}

	public void ButtonClick(int choiceIndex)
	{
		ThinksyPlugin.AddGivenAnswerPartToMostRecentProblem ((ProblemPart)availableAnswers [choiceIndex]);
		if (ThinksyPlugin.AllAnswerPartsGiven())
		{
			SubmitAnswers();
		}
		else
		{
			UpdateDisplay ();
		}
	}
}
