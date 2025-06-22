using UnityEngine;

public class Player : MonoBehaviour
{
    public float ascendForce = 5f;
    public GameManager gameManager;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!gameManager.isGamestart)
        {
            return;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // 상승하는 힘을 조금씩 줌

                rigid.AddForce(Vector2.up * ascendForce);
                Debug.Log("화면을 꾹 누르고 있음 (천천히 상승 중)");

            }
        }
    }
}
