using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGamestart = false;
    public GameObject canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GameStart()
    {
        isGamestart = true;
        canvas.SetActive(false);
    }
    public void GameOver()
    {
        isGamestart = false;
        Time.timeScale = 0f;
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
    public void EnergyLevelUp() //에너지 레벨업
    {
        
    }
       public void FishLevelUp() //생선 레벨업
    {
        
    }
    public void DistanceLevelUp()//거리 레벨업
    {
        
    }
    public void Setting()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }
}
