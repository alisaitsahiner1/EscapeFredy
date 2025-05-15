using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyColor;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{keyColor} anahtarı toplandı!");
            other.GetComponent<PlayerInventory>().AddKey(keyColor); // anahtarı envantere ekle
            Destroy(gameObject);
        }
    }
}
