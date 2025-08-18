using UnityEngine;

public class PlayerKeyInventory : MonoBehaviour
{
    [Header("Key Settings")]
    [SerializeField] private int keysRequired = 3;
    private int keysCollected = 0;

    [Header("UI Feedback")]
    [SerializeField] private UnityEngine.UI.Text keysText;

    private void Start()
    {
        UpdateKeysUI();
    }

    public void AddKey()
    {
        keysCollected++;
        UpdateKeysUI();
        Debug.Log($"Key collected! ({keysCollected}/{keysRequired})");
    }

    public bool HasAllKeys()
    {
        return keysCollected >= keysRequired;
    }

    private void UpdateKeysUI()
    {
        if (keysText != null)
        {
            keysText.text = $"Keys: {keysCollected}/{keysRequired}";
        }
    }
}