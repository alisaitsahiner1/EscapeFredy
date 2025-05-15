using UnityEngine;

public class SwingingDoor : MonoBehaviour
{
    public string doorColor;
    private Rigidbody doorRigidbody;
    private bool isUnlocked = false;

    void Start()
    {
        doorRigidbody = GetComponent<Rigidbody>();

        if (doorRigidbody == null)
        {
            return;
        }

        LockZRotation();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isUnlocked)
            {
                return;
            }

            if (PlayerInventory.instance != null && PlayerInventory.instance.HasKey(doorColor))
            {
                Debug.Log($"{doorColor} anahtarı bulundu. Kapı açılıyor!");

                PlayerInventory.instance.RemoveKeyFromUI(doorColor);

                isUnlocked = true;
                UnlockZRotation();
            }
            else
            {
                Debug.Log($"Bu kapıyı açmak için {doorColor} anahtarına ihtiyacınız var!");
            }
        }
    }

    private void LockZRotation()
    {
        doorRigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
    }

    private void UnlockZRotation()
    {
        doorRigidbody.constraints = RigidbodyConstraints.None;
    }
}
