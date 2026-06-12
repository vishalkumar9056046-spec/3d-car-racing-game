using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameOverUI gameOverUI;
    private HUD hud;
    private bool crashed = false;
    
    private void Start()
    {
        hud = FindObjectOfType<HUD>();
        if (gameOverUI == null)
            gameOverUI = FindObjectOfType<GameOverUI>();
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && !crashed)
        {
            crashed = true;
            CrashCar();
        }
    }
    
    private void CrashCar()
    {
        if (hud != null && gameOverUI != null)
        {
            float time = hud.GetElapsedTime();
            int coins = hud.GetCoinsCollected();
            gameOverUI.ShowGameOver(false, time, coins);
        }
    }
}
