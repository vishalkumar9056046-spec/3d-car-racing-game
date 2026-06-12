using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform[] checkpoints;
    [SerializeField] private int currentCheckpoint = 0;
    
    private CarController carController;
    
    private void Start()
    {
        carController = FindObjectOfType<CarController>();
        
        if (startPosition != null && carController != null)
        {
            carController.transform.position = startPosition.position;
            carController.transform.rotation = startPosition.rotation;
        }
    }
    
    public void RegisterCheckpoint(int checkpointIndex)
    {
        if (checkpointIndex == currentCheckpoint + 1)
        {
            currentCheckpoint++;
        }
    }
    
    public int GetCurrentCheckpoint()
    {
        return currentCheckpoint;
    }
    
    public int GetTotalCheckpoints()
    {
        return checkpoints.Length;
    }
}
