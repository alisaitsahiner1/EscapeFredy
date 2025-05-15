using UnityEngine;
using TMPro;
public class EnemyLevel : MonoBehaviour
{
    public int currentLevel = 10;
    public TextMeshPro levelText;

    void Start()
    {
        currentLevel = Random.Range(5, 15);

        if (levelText != null)
        {
            levelText.text = "Level " + currentLevel.ToString();
        }
    }
}
