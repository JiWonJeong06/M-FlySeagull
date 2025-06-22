using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGamestart = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GameStart()
    {
        isGamestart = true;
    }
     public void GameOver()
    {
        isGamestart = false;
    }
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    } 
    // Update is called once per frame
    void Update()
    {

    }
}
