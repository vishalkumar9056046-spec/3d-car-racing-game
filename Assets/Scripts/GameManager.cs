using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int totalLevels = 5;
    private int totalCoins = 0;
    private float bestTime = 0f;
    private bool isPaused = false;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        LoadPlayerData();
    }
    
    public void LoadLevel(int levelNumber)
    {
        if (levelNumber >= 1 && levelNumber <= totalLevels)
        {
            currentLevel = levelNumber;
            SceneManager.LoadScene("Level_" + levelNumber);
        }
    }
    
    public void StartNewGame()
    {
        currentLevel = 1;
        totalCoins = 0;
        bestTime = 0f;
        LoadLevel(1);
    }
    
    public void AddCoins(int amount)
    {
        totalCoins += amount;
    }
    
    public int GetTotalCoins()
    {
        return totalCoins;
    }
    
    public void SetBestTime(float time)
    {
        bestTime = time;
    }
    
    public float GetBestTime()
    {
        return bestTime;
    }
    
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }
    
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
    
    public bool IsPaused()
    {
        return isPaused;
    }
    
    public int GetCurrentLevel()
    {
        return currentLevel;
    }
    
    public void NextLevel()
    {
        if (currentLevel < totalLevels)
        {
            LoadLevel(currentLevel + 1);
        }
        else
        {
            LoadMainMenu();
        }
    }
    
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame()
    {
        SavePlayerData();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    
    private void SavePlayerData()
    {
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.SetFloat("BestTime", bestTime);
        PlayerPrefs.Save();
    }
    
    private void LoadPlayerData()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        bestTime = PlayerPrefs.GetFloat("BestTime", 0f);
    }
}