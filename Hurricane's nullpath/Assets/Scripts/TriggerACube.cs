using UnityEngine;

public class TriggerCube : MonoBehaviour
{
    public string hintMessage;
    //public string answer;
    public GameObject arrow;
  

  
   
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (other.CompareTag("Player"))
        {
            triggered = true;

            HintUI hintUI = FindObjectOfType<HintUI>();
            hintUI.ShowHint(hintMessage/*,answer, OnCorrectAnswer*/);
           Time.timeScale = 0f;
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

        



       Time.timeScale = 1f;
    }
}
