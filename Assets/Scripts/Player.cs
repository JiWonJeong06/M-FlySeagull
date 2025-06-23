using Unity.VisualScripting;
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
    public SpawnManager spawnManager;

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
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Whale"))
        {
            AnimatorChange(State.Die);
            gameManager.GameOver();
        }      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fish"))
        {
            Debug.Log("생선야금야금야금야금");
           Destroy(collision.gameObject);
            foreach (Fish fish in spawnManager.Fish)
            {
                if (fish.fish.name.Contains(collision.gameObject.name.Replace("(Clone)", "").Trim()))
                {
                    Debug.Log("에너지는 이만큼 먹었지" + fish.energy);
                    Debug.Log("점수는 이만큼 먹었지" + fish.score);
                    Debug.Log(fish.name + "이생선이지 키키윽");
            }
            }
        }        
   }


    void AnimatorChange(State state) {
       animator.SetInteger("State", (int)state);
    }  












}
