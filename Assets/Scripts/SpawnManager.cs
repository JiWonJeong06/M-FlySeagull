using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameManager gameManager;
    public FishData fishData;    
    public GameObject[] Fish;               
    public GameObject[] whalePrefab;
    public GameObject[] seagullPrefab;
    public GameObject wp;

    [Header("소환 간격")]
    public float spawnInterval = 2f;      

    private bool isSpawning = false;

    
    void Update()
    {
        if (!GameManager.isGamestart || isSpawning)
            return;

        StartCoroutine(SpawnDelay(spawnInterval));
    }

    IEnumerator SpawnDelay(float interval)
    {
        isSpawning = true;

        SpawnObject();

        yield return new WaitForSeconds(interval);

        isSpawning = false;
    }

    private void SpawnObject()
    {
        int Randomobj = Random.Range(0, 2);

        Debug.Log("소환");
        //생선 소환
        if (Randomobj == 0)
        {
            float Ranpos = Random.Range(-3.05f, 2.5f);
            Vector3 fishpos = new Vector3(8, Ranpos, 0);
            int randomIndex = Random.Range(0, Fish.Length);
            Instantiate(Fish[randomIndex], fishpos, Quaternion.identity);
            if (wp == null)
            {
                return;
            }
        }
        //고래, 갈매기 무리소환
        if (Randomobj == 1)
        {
            int Index = Random.Range(0, 2);
            if (Index == 0)
            {
                Vector3 spawnPosition = new Vector3(8, -1.85f, 0);
                int randomIndex = Random.Range(0, whalePrefab.Length);
                wp = Instantiate(whalePrefab[randomIndex], spawnPosition, Quaternion.identity);
                wp.GetComponent<Scroll>().fishData = fishData;
            }
            if(Index==1)
            {
                Vector3 spawnPosition = new Vector3(8, 1.77f, 0);
                int randomIndex = Random.Range(0, seagullPrefab.Length);
                wp = Instantiate(seagullPrefab[randomIndex], spawnPosition, Quaternion.identity);
                wp.GetComponent<Scroll>().fishData = fishData;
            }
        //demo test
        }
        
    }
}
