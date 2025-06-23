using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Fish
{
    public string name;
    public int id;
    public GameObject fish;
    public float energy;
    public float score;
}
public class SpawnManager : MonoBehaviour
{
    public GameManager gameManager;         
    public List<Fish> Fish;               
    public GameObject whalePrefab;
    [Header("소환 간격")]
    public float spawnInterval = 2f;      

    private bool isSpawning = false;        

    void Update()
    {
        if (!gameManager.isGamestart || isSpawning)
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
        Vector3 spawnPosition = new Vector3(10, -1.85f, 0);
        Debug.Log("소환");
        //생선 소환
        if (Randomobj == 0)
        {
            int randomIndex = Random.Range(0, Fish.Count);
            Fish selectedFish = Fish[randomIndex];
            Instantiate(selectedFish.fish, spawnPosition, Quaternion.identity);
        }
        //고래 소환
        if (Randomobj == 1)
        {
            Instantiate(whalePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
