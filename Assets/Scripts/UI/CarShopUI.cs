using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarShopUI : MonoBehaviour
{
    [System.Serializable]
    public class CarItem
    {
        public string carName;
        public int price;
        public Image carImage;
        public Button selectButton;
        public Text priceText;
    }
    
    [SerializeField] private CarItem[] cars = new CarItem[5];
    [SerializeField] private Text totalCoinsText;
    [SerializeField] private Button backButton;
    [SerializeField] private Text selectedCarText;
    
    private int currentCoins = 0;
    private int selectedCarIndex = 0;
    
    private void Start()
    {
        currentCoins = GameManager.Instance.GetTotalCoins();
        totalCoinsText.text = "Total Coins: " + currentCoins;
        
        // Initialize car prices and buttons
        int[] carPrices = { 0, 500, 1000, 1500, 2500 }; // Free, prices for others
        string[] carNames = { "Sports Car", "Truck", "Formula", "SUV", "Hypercar" };
        
        for (int i = 0; i < cars.Length; i++)
        {
            int index = i;
            cars[i].carName = carNames[i];
            cars[i].price = carPrices[i];
            cars[i].priceText.text = cars[i].price == 0 ? "FREE" : "$" + cars[i].price;
            cars[i].selectButton.onClick.AddListener(() => SelectCar(index));
        }
        
        backButton.onClick.AddListener(() => GoBack());
        
        SelectCar(0);
    }
    
    private void SelectCar(int carIndex)
    {
        if (carIndex < 0 || carIndex >= cars.Length)
            return;
        
        selectedCarIndex = carIndex;
        selectedCarText.text = "Selected: " + cars[carIndex].carName;
        
        // Check if can afford
        if (currentCoins >= cars[carIndex].price)
        {
            cars[carIndex].selectButton.interactable = true;
            cars[carIndex].selectButton.GetComponentInChildren<Text>().text = "SELECT";
        }
        else
        {
            cars[carIndex].selectButton.interactable = false;
            cars[carIndex].selectButton.GetComponentInChildren<Text>().text = "LOCKED";
        }
    }
    
    private void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
