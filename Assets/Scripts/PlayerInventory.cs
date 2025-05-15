using System.Collections.Generic; // HashSet için gerekli
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    private HashSet<string> collectedKeys = new HashSet<string>();// Toplanan anahtarları tutan liste

    private KeyUIManager keyUIManager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        keyUIManager = FindObjectOfType<KeyUIManager>();
    }

    public void AddKey(string keyColor)
    {
        if (!collectedKeys.Contains(keyColor))
        {
            collectedKeys.Add(keyColor);
            Debug.Log($"{keyColor} anahtarı envantere eklendi!");

            keyUIManager.ShowKeyUI(keyColor);
        }
    }

    // anahtar kontrolü
    public bool HasKey(string keyColor)
    {
        return collectedKeys.Contains(keyColor);
    }

    // UI'den anahtarı kaldırma (envanterde tutmaya devam eder)
    public void RemoveKeyFromUI(string keyColor)
    {
        if (collectedKeys.Contains(keyColor))
        {
            keyUIManager.HideKeyUI(keyColor);
        }
    }

    public void UseKey(string keyColor)
    {
        if (collectedKeys.Contains(keyColor))
        {
            collectedKeys.Remove(keyColor);
            Debug.Log($"{keyColor} anahtarı kullanıldı ve envanterden çıkarıldı");

            keyUIManager.HideKeyUI(keyColor);
        }
        else
        {
            Debug.Log($"{keyColor} anahtarı envanterde yok");
        }
    }
}
