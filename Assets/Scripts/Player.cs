using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public enum State { Idle, Die };
    Animator animator;
    public float ascendForce = 5f;
    public float currentEnergy;
    public float maxEnergy;
    public GameManager gameManager;

    private Rigidbody2D rigid;

    public UnityEvent onHit;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentEnergy = maxEnergy;
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
                rigid.AddForce(Vector2.up * ascendForce);
                Debug.Log("화면을 꾹 누르고 있음 (천천히 상승 중)");
            }
        }
    }
    void Update()
    {
        if (!gameManager.isGamestart)
        {
            return;
        }
        rigid.simulated = true;
        currentEnergy -= Time.deltaTime * 5f;
        Gameover();
    }

    void Gameover()
    {
        if (currentEnergy <= 0)
        {
            rigid.simulated = false;
            gameManager.GameOver();
            onHit.Invoke();
        }
    }


    void AnimatorChange(State state) {
       animator.SetInteger("State", (int)state);
    }  












}
