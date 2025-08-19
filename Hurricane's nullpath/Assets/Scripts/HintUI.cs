using UnityEngine;
using TMPro;

public class HintUI : MonoBehaviour
{
    [Header("UI References")]
    public GameObject panel;
    public TextMeshProUGUI hintText;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void ShowHint(string hint)
    {
        panel.SetActive(true);
        hintText.text = hint;
    }

    public void HideHint()
    {
        panel.SetActive(false);
    }
}
