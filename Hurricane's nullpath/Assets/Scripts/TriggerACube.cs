using UnityEngine;

public class TriggerCube : MonoBehaviour
{
    public string hintMessage;
    public string correctAnswer;
    public GameObject arrow;

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
        if(arrow != null)
        {
            arrow.SetActive(false);
        }
        gameObject.SetActive(false); 
    }
}
