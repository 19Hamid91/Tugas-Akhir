using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;
    public Text ScoreTxt;
    public GameObject QuizPanel;
    public GameObject ResultPanel;

    public GameObject BtnRetry;
    public GameObject BtnNext;

    public Text QuestionCounter;

    int totalQuestion = 0;
    int answeredQuestion = 0;
    int score = 0;
    int minIndex;
    int maxIndex;
    // Start is called before the first frame update
    void Start()
    {
        if (Data.Level == 1)
        {
            QnA.RemoveRange(5, 10);
        }
        else if(Data.Level == 2)
        {
            QnA.RemoveRange(10, 5);
        }
        score = 0;
        QuizPanel.SetActive(true);
        ResultPanel.SetActive(false);
        totalQuestion = QnA.Count;
        generateQuestion();
    }

    private void Update()
    {
        if (Data.timeIsUp)
        {
            QuizResult();
            Debug.Log("Waktu Habis!");
        }
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void correct()
    {
        score++;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    public void incorrect()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        // Data.IncorrectAnswer +=1;
    }
    public void QuizResult()
    {
        QuizPanel.SetActive(false);
        ResultPanel.SetActive(true);
        ScoreTxt.text = score+"/"+totalQuestion;

        if (score <= ((totalQuestion/2)))
        {
            BtnRetry.SetActive(true);
            BtnNext.SetActive(false);
        }
        else
        {
            BtnRetry.SetActive(false);
            BtnNext.SetActive(true);
        }

    }
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answer[i];

            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            answeredQuestion++;
            QuestionCounter.text = answeredQuestion+"/"+totalQuestion;

            SetAnswer();
        }
        else
        {
            Debug.Log("Pertanyaan Habis");
            QuizResult();
        }
    }
}
