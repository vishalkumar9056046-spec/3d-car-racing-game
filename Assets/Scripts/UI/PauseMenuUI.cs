using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Text pauseTitle;
    
    private bool isPaused = false;
    
    private void Start()
    {
        resumeButton.onClick.AddListener(() => ResumeGame());
        restartButton.onClick.AddListener(() => RestartLevel());
        mainMenuButton.onClick.AddListener(() => GoToMainMenu());
        
        pausePanel.SetActive(false);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    
    private void PauseGame()
    {
        isPaused = true;
        GameManager.Instance.PauseGame();
        pausePanel.SetActive(true);
    }
    
    private void ResumeGame()
    {
        isPaused = false;
        GameManager.Instance.ResumeGame();
        pausePanel.SetActive(false);
    }
    
    private void RestartLevel()
    {
        GameManager.Instance.ResumeGame();
        int currentLevel = GameManager.Instance.GetCurrentLevel();
        GameManager.Instance.LoadLevel(currentLevel);
    }
    
    private void GoToMainMenu()
    {
        GameManager.Instance.ResumeGame();
        GameManager.Instance.LoadMainMenu();
    }
}
