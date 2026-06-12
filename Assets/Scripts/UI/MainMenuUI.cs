using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button carShopButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Text titleText;
    [SerializeField] private Text coinsText;
    
    private void Start()
    {
        startGameButton.onClick.AddListener(() => StartGame());
        carShopButton.onClick.AddListener(() => OpenCarShop());
        settingsButton.onClick.AddListener(() => OpenSettings());
        quitButton.onClick.AddListener(() => GameManager.Instance.QuitGame());
        
        UpdateCoinsDisplay();
    }
    
    private void StartGame()
    {
        GameManager.Instance.StartNewGame();
    }
    
    private void OpenCarShop()
    {
        SceneManager.LoadScene("CarShop");
    }
    
    private void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    
    private void UpdateCoinsDisplay()
    {
        int coins = GameManager.Instance.GetTotalCoins();
        coinsText.text = "Coins: " + coins;
    }
}
