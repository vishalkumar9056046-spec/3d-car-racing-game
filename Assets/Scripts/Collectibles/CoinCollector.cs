using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private int coinValue = 10;
    [SerializeField] private ParticleSystem collectEffect;
    private HUD hud;
    
    private void Start()
    {
        hud = FindObjectOfType<HUD>();
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (hud != null)
            {
                hud.AddCoin(coinValue);
            }
            
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);
        }
    }
}
