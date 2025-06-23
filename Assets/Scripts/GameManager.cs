using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static float coin = 0;

    public static bool isGamestart = false;
    public GameObject canvas;
    public GameObject gameovercanvas;
    public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GameStart()
    {
        isGamestart = true;
        canvas.SetActive(false);
        player.currentEnergy = player.maxEnergy;
        
    }
    public void GameOver()
    {
        isGamestart = false;
        gameovercanvas.SetActive(true);
    }
    public void ReStart()
    {
        SceneManager.LoadScene(0);
        Player.score = 0f;
        PlayerPrefs.Save();
    }
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        coin = PlayerPrefs.GetFloat("coin", coin);

        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
    }
    
    // Update is called once per frame
    void Update()
    {
      
    }

    public void Setting()
    {

    }

    public void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
         #else
        Application.Quit(); // 어플리케이션 종료
        #endif
    }
    
}
