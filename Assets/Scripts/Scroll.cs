using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollspeed;
    private bool scoreAdded = false; // 한 번만 실행되도록 제어할 변수
    public static float whalescore = 75f;
    void Start()
    {
        whalescore = PlayerPrefs.GetFloat("whalescore",whalescore);
    }
    void Update()
    {
        if (!GameManager.isGamestart)
        {
            return;
        }
        float totalSpeed = scrollspeed * Time.deltaTime * -1f;
        transform.Translate(totalSpeed, 0, 0);

        if (!scoreAdded && transform.position.x <= -1.5f && CompareTag("Whale"))
        {
            Player.score += whalescore;
            scoreAdded = true; // 다음부터는 실행되지 않도록 설정
        }

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
