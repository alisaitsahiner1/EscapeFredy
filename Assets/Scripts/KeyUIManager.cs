using UnityEngine;
using UnityEngine.UI;

public class KeyUIManager : MonoBehaviour
{
    public Image yellowKeyUI;
    public Image redKeyUI;
    public Image blueKeyUI;

    void Start()
    {
        // başlangıçta tüm UI'leri gizle
        if (yellowKeyUI != null) yellowKeyUI.enabled = false;
        if (redKeyUI != null) redKeyUI.enabled = false;
        if (blueKeyUI != null) blueKeyUI.enabled = false;
    }

    public void ShowKeyUI(string keyColor)
    {
        switch (keyColor)
        {
            case "Yellow":
                if (yellowKeyUI != null) yellowKeyUI.enabled = true;
                break;
            case "Red":
                if (redKeyUI != null) redKeyUI.enabled = true;
                break;
            case "Blue":
                if (blueKeyUI != null) blueKeyUI.enabled = true;
                break;
            default:
                break;
        }
    }

    public void HideKeyUI(string keyColor)
    {
        switch (keyColor)
        {
            case "Yellow":
                if (yellowKeyUI != null) yellowKeyUI.enabled = false;
                break;
            case "Red":
                if (redKeyUI != null) redKeyUI.enabled = false;
                break;
            case "Blue":
                if (blueKeyUI != null) blueKeyUI.enabled = false;
                break;
            default:
                break;
        }
    }
}
