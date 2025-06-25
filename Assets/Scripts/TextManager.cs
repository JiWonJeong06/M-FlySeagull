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
        BStext.text = "최고기록: " + gameManager.bestscore.ToString("F2");
    }


    void Update()
    {
        Ctext.text = "₩ " + GameManager.coin.ToString("F0");
        Etext.text = "기력: " + player.currentEnergy.ToString("F0") + " / " + player.maxEnergy.ToString("F0");
        Dtext.text = "항해: " + player.distance.ToString("F1") + "m";
        Stext.text = Player.score.ToString("F2");
        Itext.text = "기력 : " + player.maxEnergy.ToString("F2") + " (능력치: +3.5% 증가, 가격: 5% 증가)\n\n" +
        "물고기 : " + "기력 추가: " + fishData.energy.ToString("F2") + " 점수: " + fishData.score.ToString("F2") + " (각, 능력치: +1.5%, +3% 증가, 가격: 7% 증가)\n\n"
        + "항해 : " + "고래: " + fishData.whalescore.ToString("F2") + " 보너스: " + levelManager.bonusdistance.ToString("F2") + " (각, 능력치: +2.5%, 1.5% 증가, 가격: 3.5% 증가)\n"
        + "   \" 정보창에서 소수점 2번째 자리 까지 보이는 능력치 입니다. \" ";

        totalcoin.text = "항해로 번 돈(코인제외): ₩" + gameManager.distancecoin.ToString("F2");
        totalscore.text =  "스코어: " + Player.score.ToString("F2");

    }
    
}
