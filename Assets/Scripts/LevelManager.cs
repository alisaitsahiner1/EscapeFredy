using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int currentLevel = 1;
    public TextMeshProUGUI levelText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateLevelUI();
    }

    public void LevelUp()
    {
        currentLevel++;
        UpdateLevelUI();
    }

    private void UpdateLevelUI()
    {
        if (levelText != null)
        {
            levelText.text = "Level " + currentLevel;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelUp();
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (levelText != null)
        {
            levelText.gameObject.SetActive(true);
        }
        else
        {
            levelText = FindObjectOfType<TextMeshProUGUI>();
            if (levelText != null)
            {
                levelText.gameObject.SetActive(true);
                UpdateLevelUI();
            }
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
