using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        quizManager.Disabler.SetActive(true);
        if (isCorrect)
        {
            Debug.Log("Correct");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Wrong");
            quizManager.incorrect();
        }
    }
}
