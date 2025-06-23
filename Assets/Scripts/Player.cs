using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    public enum State { Idle, Die };
    Animator animator;
    public float ascendForce = 5f;
    private float maxAscendSpeed = 2f;
    public float currentEnergy;
    public float maxEnergy;
    public float distance; //항해한 거리
    public static float score;
    public GameManager gameManager;
    private Rigidbody2D rigid;
    public FishData fishData;
  
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
            if (rigid. linearVelocity.y < maxAscendSpeed)
            {
                rigid.AddForce(Vector2.up * ascendForce);
            }
            
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
        currentEnergy -= Time.deltaTime * 1.15f;
        distance += Time.deltaTime * 1.2f;
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Whale"))
        {
            rigid.simulated = false;
            AnimatorChange(State.Die);
         
        }      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fish"))
        {

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
