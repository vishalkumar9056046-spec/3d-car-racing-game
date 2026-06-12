using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int checkpointIndex = 0;
    private TrackManager trackManager;
    
    private void Start()
    {
        trackManager = FindObjectOfType<TrackManager>();
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && trackManager != null)
        {
            trackManager.RegisterCheckpoint(checkpointIndex);
        }
    }
}
