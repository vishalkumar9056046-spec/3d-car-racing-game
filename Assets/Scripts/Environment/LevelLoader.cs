using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private int levelNumber = 1;
    
    private void Start()
    {
        InitializeLevel();
    }
    
    private void InitializeLevel()
    {
        switch (levelNumber)
        {
            case 1:
                LoadLevel1();
                break;
            case 2:
                LoadLevel2();
                break;
            case 3:
                LoadLevel3();
                break;
            case 4:
                LoadLevel4();
                break;
            case 5:
                LoadLevel5();
                break;
        }
    }
    
    private void LoadLevel1()
    {
        Time.timeScale = 1f;
    }
    
    private void LoadLevel2()
    {
        Time.timeScale = 1f;
    }
    
    private void LoadLevel3()
    {
        Time.timeScale = 1f;
    }
    
    private void LoadLevel4()
    {
        Time.timeScale = 1f;
    }
    
    private void LoadLevel5()
    {
        Time.timeScale = 1f;
    }
}
