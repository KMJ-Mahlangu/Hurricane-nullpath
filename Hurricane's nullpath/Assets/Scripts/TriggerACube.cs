using UnityEngine;

public class TriggerCube : MonoBehaviour
{
    public string hintMessage;
    public string correctAnswer;
    public GameObject arrow;

    public GameObject mapPiecePrefab;
    public float spawnRadius = 5f;

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

        Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPos.y = transform.position.y;
        Instantiate(mapPiecePrefab, spawnPos, Quaternion.identity);
    }
}
