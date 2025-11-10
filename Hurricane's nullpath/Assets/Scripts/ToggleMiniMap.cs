using UnityEngine;

public class MinimapToggle : MonoBehaviour
{
    [Header("Parent Settings")]
    public RectTransform minimapParent; // The background with mask & border
    public Vector2 miniParentSize = new Vector2(200, 200);
    public Vector2 fullParentSize = new Vector2(900, 900);
    public Vector2 miniParentPosition = new Vector2(-110, -110);
    public Vector2 fullParentPosition = new Vector2(0, 0);

    [Header("Minimap Texture Settings")]
    public RectTransform minimapImage; // The RawImage inside
    public Vector2 miniImageSize = new Vector2(180, 180);
    public Vector2 fullImageSize = new Vector2(880, 880);
    public Vector2 miniImagePosition = new Vector2(0, 0);
    public Vector2 fullImagePosition = new Vector2(0, 0);

    [Header("Camera Settings")]
    public Camera minimapCamera;
    public float miniZoom = 30f;
    public float fullZoom = 100f;

    private bool isExpanded = false;

    void Start()
    {
        ApplyMiniMapState();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            ToggleMap();
    }

    void ToggleMap()
    {
        isExpanded = !isExpanded;
        if (isExpanded)
            ApplyFullMapState();
        else
            ApplyMiniMapState();
    }

    void ApplyMiniMapState()
    {
        minimapParent.sizeDelta = miniParentSize;
        minimapParent.anchoredPosition = miniParentPosition;

        minimapImage.sizeDelta = miniImageSize;
        minimapImage.anchoredPosition = miniImagePosition;

        if (minimapCamera)
            minimapCamera.orthographicSize = miniZoom;
    }

    void ApplyFullMapState()
    {
        minimapParent.sizeDelta = fullParentSize;
        minimapParent.anchoredPosition = fullParentPosition;

        minimapImage.sizeDelta = fullImageSize;
        minimapImage.anchoredPosition = fullImagePosition;

        if (minimapCamera)
            minimapCamera.orthographicSize = fullZoom;
    }
}
