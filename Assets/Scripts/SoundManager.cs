using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource[] effect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
