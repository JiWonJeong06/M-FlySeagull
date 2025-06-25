using Mono.Cecil.Cil;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int gcoin = 1500;
    int scoin = 1000;
    int bcoin = 500;
    public bool isgcoin;
    public bool isscoin;
    public bool isbcoin;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isgcoin)
            {
                GameManager.coin += gcoin;
                Destroy(gameObject);
                PlayerPrefs.SetFloat("coin", GameManager.coin);
                PlayerPrefs.Save();

            }
            if (isscoin)
            {
                GameManager.coin += scoin;
                Destroy(gameObject);
                PlayerPrefs.SetFloat("coin", GameManager.coin);
                PlayerPrefs.Save();
            }
            if (isbcoin)
            {
                GameManager.coin += bcoin;
                Destroy(gameObject);
                PlayerPrefs.SetFloat("coin", GameManager.coin);
                PlayerPrefs.Save();
            }

        }
    }
}
