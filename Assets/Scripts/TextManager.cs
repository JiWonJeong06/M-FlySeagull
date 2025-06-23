using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Player player;
    public Text Etext; //기력
    public Text Dtext; //거리
    public Text Stext; //점수
    public Text BStext;
    void Start()
    {
        BStext.text = "최고기록: ";
    }


    void Update()
    {
        Etext.text = "기력: " + player.currentEnergy.ToString("F0") + " / " + player.maxEnergy.ToString("F0");
        Dtext.text = "항해: " + player.distance.ToString("F1") + "m";
        Stext.text = Player.score.ToString("F0");
    }
}
