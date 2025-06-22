using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Player player;
    public Text Etext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Etext.text = player.currentEnergy.ToString("F0") + " / "  + player.maxEnergy.ToString("F0");
    }
}
