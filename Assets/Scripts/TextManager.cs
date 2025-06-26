using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Player player;
    public Text Etext; //기력
    public Text Dtext; //거리
    public Text Stext; //점수
    public Text BStext; //최고 기록
    public Text Ctext; //코인

    public Text Itext; //정보창

    public GameManager gameManager;
    public FishData fishData;
    public LevelManager levelManager;

    [Header("게임종료")]
    public Text totalcoin;
    public Text totalscore;


    void Start()
    {
        BStext.text = "최고기록: " + gameManager.bestscore.ToString("F0");
    }


    void Update()
    {
        Ctext.text = "₩ " + GameManager.coin.ToString("F0");
        Etext.text = "기력: " + player.currentEnergy.ToString("F0") + " / " + player.maxEnergy.ToString("F0");
        Dtext.text = "항해: " + player.distance.ToString("F0") + "m";
        Stext.text = Player.score.ToString("F0");
        Itext.text = "기력\n" + player.maxEnergy.ToString("F2") + " \n(+3.5%) , 가격 상승률: +5%\n\n\n" +
        "물고기\n" + "기력: +" + fishData.energy.ToString("F2") + " 점수: +" + fishData.score.ToString("F2") + "\n(각, +1.5%, +3%),  가격 상승률: +7%\n\n\n"
        + "항해\n" + "회피: +" + fishData.whalescore.ToString("F2") + " 코인 보너스: x" + levelManager.bonusdistance.ToString("F2") + "\n(각, +2.5%, 1.5%) 가격 상승률: +5.5%\n\n";

        totalcoin.text = "항해로 번 돈\n₩" + gameManager.distancecoin.ToString("F0");
        totalscore.text =  "점수\n " + Player.score.ToString("F0") + "점 + "+ (player.distance*0.7f).ToString("F0") +"m = "+ player.Totalscore.ToString("F0") + "점";

    }
    
}
