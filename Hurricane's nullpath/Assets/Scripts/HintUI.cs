using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HintUI : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI hintText;
    public TMP_InputField answerInput;
    public Button submitButton;

    public Text feedbackText;

    private string correctAnswer;
    private System.Action onCorrectAnswer;

    private void Start()
    {
        panel.SetActive(false);
        feedbackText.text = "";
        submitButton.onClick.AddListener(CheckAnswer);
    }

    public void ShowHint(string hint, string answer, System.Action onCorrect)
    {
        panel.SetActive(true);
        hintText.text = hint;
        correctAnswer = answer.ToLower().Trim(); 
        onCorrectAnswer = onCorrect;
        answerInput.text = "";
        feedbackText.text = "";
    }

    void CheckAnswer()
    {
        string userAnswer = answerInput.text.ToLower().Trim();
        if (userAnswer == correctAnswer)
        {
            panel.SetActive(false);
            onCorrectAnswer?.Invoke();
            feedbackText.text = "Correct";
        }
        else
        {
            feedbackText.text = "Wrong answer , try Again";
        }
    }
}
