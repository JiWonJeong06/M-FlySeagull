using UnityEngine;

public class FishData : MonoBehaviour
{
    public float energy = 5 ;
    public float score = 100;

    void Start()
    {
        energy = PlayerPrefs.GetFloat("FEnergy", energy);
        score = PlayerPrefs.GetFloat("Fscore", score);
    }
}
