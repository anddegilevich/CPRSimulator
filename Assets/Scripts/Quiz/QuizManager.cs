using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public Question[] Questions;
    private static List<Question> UnansweredQuestions;
    private Question CurrentQuestion;
    public TMP_Text QuestionText;
    public TMP_Text Answer1Text;
    public TMP_Text Answer2Text;
    public TMP_Text Answer3Text;
    public TMP_Text Answer4Text;
    public TMP_Text QuestionNumber;
    public Animator Animator;
    public GameObject Test;

    public GameObject Results;
    public TMP_Text Result;
    private int CorrectAnswers = 0;
    private int IncorrectAnswers = 0;

    [SerializeField]
    private float Delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        if (UnansweredQuestions == null || UnansweredQuestions.Count == 0)
        {
            UnansweredQuestions = Questions.ToList<Question>();
        }
        SetCurrentQuestion();
    }

    void SetCurrentQuestion()
    {
        if (UnansweredQuestions.Count == 0)
        {
            Test.SetActive(false);
            Results.SetActive(true);
            ShowResults();
            return;
        }
        Animator.SetInteger("TrueAnswer", 0);
        Animator.SetInteger("SelectedButton", 0);
        int CurrentQuestionIndex = Random.Range(0, UnansweredQuestions.Count);
        CurrentQuestion = UnansweredQuestions[CurrentQuestionIndex];

        QuestionText.text = CurrentQuestion.QuestionText;
        Answer1Text.text = CurrentQuestion.Answer1;
        Answer2Text.text = CurrentQuestion.Answer2;
        Answer3Text.text = CurrentQuestion.Answer3;
        Answer4Text.text = CurrentQuestion.Answer4;
        QuestionNumber.text = (1 + CorrectAnswers + IncorrectAnswers).ToString() + "/5";
    }

    void ShowResults()
    {
        Result.text = "Количество правильных ответов: " + CorrectAnswers.ToString() + "/" + (CorrectAnswers+IncorrectAnswers).ToString();
    }

    public void UserSelect(int ButtonIndex)
    {
        Animator.SetInteger("SelectedButton", ButtonIndex);
        Animator.SetInteger("TrueAnswer", CurrentQuestion.AnswerIndex);
        if (CurrentQuestion.AnswerIndex == ButtonIndex)
        {
            CorrectAnswers++;
        }
        else 
        {
            IncorrectAnswers++;
        }
        StartCoroutine(NextQuestion());
    }

    IEnumerator NextQuestion()
    {
        UnansweredQuestions.Remove(CurrentQuestion);
        yield return new WaitForSeconds(Delay);
        SetCurrentQuestion();
    }
}
