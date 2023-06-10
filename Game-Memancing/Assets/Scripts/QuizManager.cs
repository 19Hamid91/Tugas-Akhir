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
    public Text Ucapan;
    public GameObject QuizPanel;
    public GameObject ResultPanel;

    public GameObject BtnRetry;
    public GameObject BtnNext;

    public GameObject benar;
    public GameObject salah;

    public Text QuestionCounter;

    int totalQuestion = 0;
    int answeredQuestion = 0;
    int score = 0;
    int minIndex;
    int maxIndex;
    // Start is called before the first frame update
    void Start()
    {
        if (Data.Tempat == "GamePlayJawa")
        {
            QnA.RemoveRange(15, 30);
            Debug.Log("Jawa");
        }
        else if(Data.Tempat == "GamePlayKalimantan")
        {
            QnA.RemoveRange(30, 15);
            QnA.RemoveRange(0, 15);
            Debug.Log("Kalimantan");
        }
        else if(Data.Tempat == "GamePlaySumatra")
        {
            QnA.RemoveRange(0, 30);
            Debug.Log("Sumatra");
        }

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
        benar.SetActive(false);
        salah.SetActive(false);
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
        // benar.SetActive(true);
        score++;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(feedbackBenar());
        // generateQuestion();
    }
    public void incorrect()
    {
        // salah.SetActive(true);
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(feedbackSalah());
        // generateQuestion();
        // Data.IncorrectAnswer +=1;
    }
    public void QuizResult()
    {
        QuizPanel.SetActive(false);
        ResultPanel.SetActive(true);
        ScoreTxt.text = score+"/"+totalQuestion;
        

        if (score <= ((totalQuestion/2)))
        {
            Ucapan.text = "Jawabanmu Masih Kurang Tepat";
            BtnRetry.SetActive(true);
            BtnNext.SetActive(false);
        }
        else
        {
            if (Data.Tempat == "GamePlayJawa")
            {
                Data.JawaLevel++;
            }
            else if (Data.Tempat == "GamePlaySumatra")
            {
                Data.SumatraLevel++;
            }
            else if (Data.Tempat == "GamePlayKalimantan")
            {
                Data.KalimantanLevel++;
            }
            Data.noProgress = true;
            BtnRetry.SetActive(false);
            BtnNext.SetActive(true);

            if (Data.Level == 3)
            {
                Ucapan.text = "Selamat Tempat Mancing Baru Telah Terbuka";
            }
            else
            {
                Ucapan.text = "Selamat Level Baru Telah Terbuka";
            }
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
            benar.SetActive(false);
            salah.SetActive(false);
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            answeredQuestion++;
            QuestionCounter.text = answeredQuestion+"/"+totalQuestion;

            SetAnswer();
        }
        else
        {
            benar.SetActive(false);
            salah.SetActive(false);
            Debug.Log("Pertanyaan Habis");
            QuizResult();
        }
    }

    IEnumerator feedbackBenar()
    {
        benar.SetActive(true);
        yield return new WaitForSeconds(1);
        generateQuestion();
    }
    IEnumerator feedbackSalah()
    {
        salah.SetActive(true);
        yield return new WaitForSeconds(1);
        generateQuestion();
    }
}
