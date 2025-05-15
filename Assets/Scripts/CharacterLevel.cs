using UnityEngine;
using TMPro;

public class CharacterLevel : MonoBehaviour
{
    public int currentLevel = 1;
    public TextMeshPro levelText;

    void Start()
    {
        UpdateLevelText();
    }

    public void IncreaseLevel(int amount)
    {
        currentLevel += amount;
        UpdateLevelText(); 
    }

    void UpdateLevelText()
    {
        levelText.text = "Level " + currentLevel;
    }
}
