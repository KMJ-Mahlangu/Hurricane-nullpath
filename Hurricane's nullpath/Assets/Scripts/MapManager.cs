using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    [Header("Map Collection")]
    public int totalPieces = 4;
    private int collectedPieces = 0;

    [Header("UI")]
    public Text piecesText;         
    public GameObject fullMapPanel;
    public GameObject fullMapButton;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if(fullMapButton != null)
        {
            fullMapButton.SetActive(false);
        }
    }

    public void CollectPiece()
    {
        collectedPieces++;
        UpdatePiecesUI();

        if (collectedPieces >= totalPieces)
        {
            if(fullMapButton != null)
            {
                fullMapButton.SetActive(true);
            }
            ShowFullMap();
        }
    }

    private void UpdatePiecesUI()
    {
        if (piecesText != null)
        {
            piecesText.text = $" MapPieces: {collectedPieces}/{totalPieces}";
        }
    }

    private void ShowFullMap()
    {
        if (fullMapPanel != null)
        {
            fullMapPanel.SetActive(true);
            Time.timeScale = 0f; 
        }
    }

    public void OpenFullMapManually()
    {
        if(collectedPieces >= totalPieces)
        {
            ShowFullMap();
        }
    }

    public void CloseFullMap()
    {
        if (fullMapPanel != null)
        {
            fullMapPanel.SetActive(false);
            Time.timeScale = 1f; 
        }
    }
}
