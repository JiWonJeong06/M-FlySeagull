using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static float coin = 0;
    public float bestscore = 0;
    public static bool isGamestart = false;
    public GameObject canvas;
    public GameObject gameovercanvas;
    public Player player;
    public LevelManager levelManager;
    
    
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
        coin += player.distance * 3 * levelManager.bonusdistance;
        bestscore = PlayerPrefs.GetFloat("bestscore");
        PlayerPrefs.SetFloat("bestscore", Mathf.Max(bestscore, Player.score));
        PlayerPrefs.SetFloat("coin", coin);
        
    }
    public void ReStart()
    {
        SceneManager.LoadScene(0);
        Player.score = 0f;
        PlayerPrefs.Save();
    }
    void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        coin = PlayerPrefs.GetFloat("coin", coin);
        bestscore = PlayerPrefs.GetFloat("bestscore", bestscore);

        

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
