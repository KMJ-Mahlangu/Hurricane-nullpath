using UnityEngine;

public class TriggerCube : MonoBehaviour
{
    public string hintMessage;
    public string correctAnswer;
    public GameObject arrow;
   // public MinimapArrowUI minimapArrow;

    public GameObject mapPiecePrefab;
    [Header("Spawning")]
    public float spawnRadius = 5f;
    public Transform[] spawnPoints;
    public int spawnIndex = 0;
   
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (other.CompareTag("Player"))
        {
            triggered = true;

            HintUI hintUI = FindObjectOfType<HintUI>();
            hintUI.ShowHint(hintMessage, correctAnswer, OnCorrectAnswer);
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

        if (spawnPoints != null && spawnIndex >= 0 && spawnIndex < spawnPoints.Length)
        {
            Vector3 spawnPos = spawnPoints[spawnIndex].position;
            Quaternion spawnRot = spawnPoints[spawnIndex].rotation;

            Instantiate(mapPiecePrefab, spawnPos, spawnRot);
            Debug.Log($"Map piece spawned at spawn point {spawnIndex + 1}");
        }
        else
        {
            Debug.LogWarning("Invalid spawn index or spawnPoints array not set!");
        }

        



        Time.timeScale = 1f;
    }
}
