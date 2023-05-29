using UnityEngine;

[CreateAssetMenu(fileName = "QnA", menuName = "ScriptableObjects/QnA", order = 1)]
public class QuizManager2 : ScriptableObject
{

[System.Serializable]
    public class QuestionAndAnswer2
    {
        public string Question;
        public string[] Answer;
        public int CorrectAnswer;
    }

    [System.Serializable]
    public class QnAList2
    {
        public QuestionAndAnswer2[] QnA2;
    }

    public QnAList2 myQnAList2 = new QnAList2();

}