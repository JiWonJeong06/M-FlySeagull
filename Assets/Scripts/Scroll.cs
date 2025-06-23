using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollspeed;
    private bool scoreAdded = false; // 한 번만 실행되도록 제어할 변수

    void Update()
    {
        float totalSpeed = scrollspeed * Time.deltaTime * -1f;
        transform.Translate(totalSpeed, 0, 0);

        if (!scoreAdded && transform.position.x <= -1.5f && CompareTag("Whale"))
        {
            Player.score += 15;
            scoreAdded = true; // 다음부터는 실행되지 않도록 설정
        }

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
