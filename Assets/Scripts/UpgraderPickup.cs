using UnityEngine;

public class UpgraderPickup : MonoBehaviour
{
    public int levelIncreaseAmount = 6;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterLevel characterLevel = other.GetComponent<CharacterLevel>();
            if (characterLevel != null)
            {
                characterLevel.IncreaseLevel(levelIncreaseAmount);
            }
            
            Destroy(gameObject);
        }
    }
}
