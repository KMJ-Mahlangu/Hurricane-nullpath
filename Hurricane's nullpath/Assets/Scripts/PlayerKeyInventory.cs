using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerKeyInventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keysText;
    private List<string> keysCollected = new List<string>();

    public void AddKey(string keyName)
    {
        if (!keysCollected.Contains(keyName))
        {
            keysCollected.Add(keyName);
            UpdateKeysUI();
            Debug.Log($"Collected key: {keyName}");
        }
    }

    public bool HasKey(string keyName)
    {
        return keysCollected.Contains(keyName);
    }

    public void UseKey(string keyName)
    {
        if (keysCollected.Contains(keyName))
        {
            keysCollected.Remove(keyName);
            UpdateKeysUI();
            Debug.Log($"Used key: {keyName}");
        }
    }

    private void UpdateKeysUI()
    {
        if (keysText != null)
            keysText.text = keysCollected.Count > 0 ? "Keys: " + string.Join(", ", keysCollected) : "Keys: None";
    }
}
