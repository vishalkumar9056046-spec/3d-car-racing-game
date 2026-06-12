using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameOverUI gameOverUI;
    private HUD hud;
    private bool levelCompleted = false;
    
    private void Start()
    {
        hud = FindObjectOfType<HUD>();
        if (gameOverUI == null)
            gameOverUI = FindObjectOfType<GameOverUI>();
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && !levelCompleted)
        {
            levelCompleted = true;
            CompleteLevel();
        }
    }
    
    private void CompleteLevel()
    {
        if (hud != null && gameOverUI != null)
        {
            float time = hud.GetElapsedTime();
            int coins = hud.GetCoinsCollected();
            GameManager.Instance.SetBestTime(time);
            gameOverUI.ShowGameOver(true, time, coins);
        }
    }
}
