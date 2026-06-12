using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Text speedText;
    [SerializeField] private Text coinsText;
    [SerializeField] private Text levelText;
    [SerializeField] private Image nitroBar;
    [SerializeField] private Text timerText;
    [SerializeField] private CarController carController;
    
    private float elapsedTime = 0f;
    private int coinsCollected = 0;
    
    private void Start()
    {
        levelText.text = "Level " + GameManager.Instance.GetCurrentLevel();
    }
    
    private void Update()
    {
        if (!GameManager.Instance.IsPaused())
        {
            elapsedTime += Time.deltaTime;
        }
        
        UpdateSpeedDisplay();
        UpdateNitroDisplay();
        UpdateTimerDisplay();
    }
    
    private void UpdateSpeedDisplay()
    {
        if (carController != null)
        {
            float speedPercent = carController.GetSpeed() * 100f;
            speedText.text = "Speed: " + speedPercent.ToString("F0") + "%";
        }
    }
    
    private void UpdateNitroDisplay()
    {
        if (carController != null && nitroBar != null)
        {
            nitroBar.fillAmount = carController.GetNitroEnergy();
        }
    }
    
    private void UpdateTimerDisplay()
    {
        int minutes = (int)(elapsedTime / 60f);
        int seconds = (int)(elapsedTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    public void AddCoin(int amount)
    {
        coinsCollected += amount;
        coinsText.text = "Coins: " + coinsCollected;
        GameManager.Instance.AddCoins(amount);
    }
    
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
    
    public int GetCoinsCollected()
    {
        return coinsCollected;
    }
}
