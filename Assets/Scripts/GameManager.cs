using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static float coin = 0;
    public float distancecoin;
    public float bestscore = 0;
    public static bool isGamestart = false;
    public GameObject canvas;
    public GameObject gameovercanvas;
    [Header("정보,설정,가이드")]
    public GameObject infocanvas;
    public GameObject Back;
    public GameObject SettingnGuide;

    [Header("플레이어, 레벨 매니저")]
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
        distancecoin += player.distance * 3 * levelManager.bonusdistance;
        coin += distancecoin;
        bestscore = PlayerPrefs.GetFloat("bestscore");
        PlayerPrefs.SetFloat("bestscore", Mathf.Max(bestscore, Player.score));
        PlayerPrefs.SetFloat("coin", coin);
        
    }
    public void ReStart()
    {
        gameovercanvas.SetActive(false);
        SceneManager.LoadScene(0);
        Player.score = 0f;
        distancecoin = 0f;
        PlayerPrefs.Save();
    }
    void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        coin = PlayerPrefs.GetFloat("coin", coin);
        bestscore = PlayerPrefs.GetFloat("bestscore", bestscore);

        //PlayerPrefs.DeleteAll();
    }
    

    public void Setting()
    {
        infocanvas.SetActive(true);
        SettingnGuide.SetActive(true);
    }
    public void Info()
    {
        infocanvas.SetActive(true);
        Back.SetActive(true);
    }

    public void ExitInfo()
    {
        infocanvas.SetActive(false);
        Back.SetActive(false);
        SettingnGuide.SetActive(false);
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
