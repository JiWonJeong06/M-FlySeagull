using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollspeed;
    private bool scoreAdded = false; // 한 번만 실행되도록 제어할 변수
    private bool seagullsound = false;

    public FishData fishData;
    

    void Update()
    {
        if (!GameManager.isGamestart)
        {
            return;
        }
        float totalSpeed = scrollspeed * Time.deltaTime * -1f;
        transform.Translate(totalSpeed, 0, 0);

        if (!scoreAdded && transform.position.x <= -2f && CompareTag("Whale"))
        {
            Player.score += fishData.whalescore;
            scoreAdded = true; // 다음부터는 실행되지 않도록 설정
        }
        if (!seagullsound && CompareTag("Seagull") && transform.position.x <= 2.8f)
        {
            SoundManager.effect[2].Play();
            if (!scoreAdded && transform.position.x <= -2f && CompareTag("Seagull"))
            {
                Player.score += fishData.whalescore;

                scoreAdded = true; 
                seagullsound = true;
            }
        }
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
