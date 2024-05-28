using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer: MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void AnswerQuestion()
    {
        if (isCorrect)
        {
            GetComponent<Button>().image.color = Color.green;
            quizManager.Invoke("correct", 1f);
        }
        else
        {
            GetComponent<Button>().image.color = Color.red;
            quizManager.incorrect(); //TODO FIXME !!!!
        }
    }
}