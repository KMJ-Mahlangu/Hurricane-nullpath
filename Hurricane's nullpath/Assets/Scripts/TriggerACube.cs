using UnityEngine;

public class TriggerCube : MonoBehaviour
{
    public string hintMessage;
    public GameObject arrow;
    public GameObject uiPanel;
    public Transform character;
    public float triggerDistance = 3f;

    private bool panelOpen = false;
    public static bool isPaused = false; 

    void Update()
    {
        float distance = Vector3.Distance(transform.position, character.position);

        if (!panelOpen && distance <= triggerDistance)
        {
            OpenPanel();
        }
        else if (panelOpen && distance > triggerDistance)
        {
            ClosePanel();
        }
    }

    void OpenPanel()
    {
        panelOpen = true;
        isPaused = true;

        if (uiPanel != null)
            uiPanel.SetActive(true);

        HintUI hintUI = FindObjectOfType<HintUI>();
        if (hintUI != null)
            hintUI.ShowHint(hintMessage);

        if (arrow != null)
            arrow.SetActive(false);

       // Time.timeScale = 0f;
       
    }

    void ClosePanel()
    {
        panelOpen = false;
        isPaused = false;

        if (uiPanel != null)
            uiPanel.SetActive(false);

        Time.timeScale = 1f;
       
    }
}
