using UnityEngine;

public class FishData : MonoBehaviour
{
    public float energy = 5 ;
    public float score = 120;

    public float whalescore = 60; //고래 점수

    void Start()
    {
        energy = PlayerPrefs.GetFloat("FEnergy", energy);
        score = PlayerPrefs.GetFloat("Fscore", score);
        whalescore = PlayerPrefs.GetFloat("whalescore", whalescore);
    }
}
