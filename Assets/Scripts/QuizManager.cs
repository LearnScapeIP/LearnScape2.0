using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManager: MonoBehaviour
{
    public List<QuAn> QuAnList;
    public GameObject[] options;
    public int currentQuestion;

    public TMPro.TextMeshProUGUI questionText;
    public string finalScene;

    private void Start()
    {
        SetQuestion(0);
        Debug.Log(QuAnList.Count);

    }

    public void correct()
    {
        Debug.Log("Correct!");
        if (currentQuestion < QuAnList.Count - 1)
        {
            currentQuestion++;
            SetQuestion(currentQuestion);
        }
        else
        {
            Debug.Log("End of the Room");
            SceneManager.LoadScene(finalScene);
        }
    }


    public void incorrect()
    {
        Debug.Log("Incorrect!");
    }

    void SetAnswers(int questionIndex)
    {
        questionText.text = QuAnList[questionIndex].Question;
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = QuAnList[questionIndex].Answers[i];
            options[i].GetComponent<Button>().image.color = Color.white;
            if (QuAnList[questionIndex].CorrectAnswer == i)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }

    void SetPhotoBackground(int questionIndex)
    {
        {
            GameObject background = GameObject.Find("Background");
            //background.sprite = QuAnList[questionIndex].Images[QuAnList[questionIndex].ImageIndex];
            background.GetComponent<Image>().sprite = QuAnList[questionIndex].Image;
        }
    }

    void SetQuestion(int questionIndex)
    {
        currentQuestion = questionIndex;
        questionText.text = QuAnList[currentQuestion].Question;
        SetPhotoBackground(currentQuestion);
        SetAnswers(currentQuestion);
    }

}