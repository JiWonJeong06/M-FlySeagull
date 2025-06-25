using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public enum State { Idle, Die };
    Animator animator;
    public float ascendForce = 5f;
    private float maxAscendSpeed = 3f;
    public float currentEnergy;
    public float maxEnergy = 100;
    public float distance; //항해한 거리
    public static float score;
    private Rigidbody2D rigid;
    public FishData fishData;
     public UnityEvent onHit;

    public GameManager gameManager;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        maxEnergy = PlayerPrefs.GetFloat("Energy",maxEnergy);
    }
    void FixedUpdate()
    {
        if (!GameManager.isGamestart)
        {
            return;
        }
 if (Input.touchCount > 0)
{
    Touch touch = Input.GetTouch(0);

    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
    {
            if (rigid. linearVelocity.y < maxAscendSpeed)
            {
                rigid.AddForce(Vector2.up * ascendForce);
            }
            
    }
}
}
    void Update()
    {
        if (!GameManager.isGamestart)
        {
            return;
        }
        rigid.simulated = true;
        currentEnergy -= Time.deltaTime * 1.15f;
        distance += Time.deltaTime * 1.2f;
        if (currentEnergy <= 0)
        {
            AnimatorChange(State.Die);
            rigid.simulated = false;
            gameManager.GameOver();
       }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Whale") || collision.collider.CompareTag("Seagull"))
        {
            AnimatorChange(State.Die);
            rigid.simulated = false;
            onHit.Invoke();
        }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fish"))
        {
            SoundManager.effect[0].Play();
            Destroy(collision.gameObject);
            currentEnergy += fishData.energy;
            if (currentEnergy >= maxEnergy)
            {
                currentEnergy = maxEnergy;
            }
            score += fishData.score;

        }
    }


    void AnimatorChange(State state) {
       animator.SetInteger("State", (int)state);
    }  












}
