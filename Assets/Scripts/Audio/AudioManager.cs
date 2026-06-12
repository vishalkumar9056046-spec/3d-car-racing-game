using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    [SerializeField] private AudioClip engineSound;
    [SerializeField] private AudioClip nitroSound;
    [SerializeField] private AudioClip coinCollectSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioClip levelCompleteSound;
    
    private AudioSource audioSource;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayEngineSound()
    {
        if (engineSound != null && audioSource != null)
            audioSource.PlayOneShot(engineSound);
    }
    
    public void PlayNitroSound()
    {
        if (nitroSound != null && audioSource != null)
            audioSource.PlayOneShot(nitroSound);
    }
    
    public void PlayCoinCollectSound()
    {
        if (coinCollectSound != null && audioSource != null)
            audioSource.PlayOneShot(coinCollectSound);
    }
    
    public void PlayCrashSound()
    {
        if (crashSound != null && audioSource != null)
            audioSource.PlayOneShot(crashSound);
    }
    
    public void PlayLevelCompleteSound()
    {
        if (levelCompleteSound != null && audioSource != null)
            audioSource.PlayOneShot(levelCompleteSound);
    }
    
    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
