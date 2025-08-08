using UnityEngine;

public class TriggerCube : MonoBehaviour
{
    public string hintMessage;
    public string correctAnswer;

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (other.CompareTag("Player"))
        {
            triggered = true;

            HintUI hintUI = FindObjectOfType<HintUI>();
            hintUI.ShowHint(hintMessage, correctAnswer, OnCorrectAnswer);
        }
    }

    void OnCorrectAnswer()
    {
        
        Debug.Log("Correct answer! Proceed");
        gameObject.SetActive(false); 
    }
}
