using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text titleText;
    [SerializeField] private Text statsText;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button mainMenuButton;
    
    private bool gameOver = false;
    
    private void Start()
    {
        if (nextLevelButton != null)
            nextLevelButton.onClick.AddListener(() => NextLevel());
        if (retryButton != null)
            retryButton.onClick.AddListener(() => RetryLevel());
        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(() => GoToMainMenu());
        
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }
    
    public void ShowGameOver(bool won, float time, int coinsCollected)
    {
        gameOver = true;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        
        if (won)
        {
            titleText.text = "LEVEL COMPLETE!";
            if (nextLevelButton != null)
                nextLevelButton.gameObject.SetActive(true);
        }
        else
        {
            titleText.text = "GAME OVER";
            if (nextLevelButton != null)
                nextLevelButton.gameObject.SetActive(false);
        }
        
        statsText.text = $"Time: {time:F2}s\nCoins: {coinsCollected}";
    }
    
    private void NextLevel()
    {
        Time.timeScale = 1f;
        GameManager.Instance.NextLevel();
    }
    
    private void RetryLevel()
    {
        Time.timeScale = 1f;
        int currentLevel = GameManager.Instance.GetCurrentLevel();
        GameManager.Instance.LoadLevel(currentLevel);
    }
    
    private void GoToMainMenu()
    {
        Time.timeScale = 1f;
        GameManager.Instance.LoadMainMenu();
    }
}
