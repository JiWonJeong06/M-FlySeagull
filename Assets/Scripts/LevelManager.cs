using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public Player player;
    public FishData fishData;
    private float elevelup = 1.035f;
    private float flevelup1 = 1.015f; //생선 기력
    private float flevelup2 = 1.03f; //생선 점수
    private float dlevelup = 1.025f; 

    public float bonusdistance = 1;
    private float bonuslevelup = 1.015f;

    public int eg = 1;
    public int fh = 1;
    public int dt = 1;

    public float giveeg = 500;
    public float givefh = 500;
    public float givedt = 500;

    public Text elup;
    public Text flup;
    public Text dtlup;

    public Text tgiveeg;
    public Text tgivefh ;
   public Text tgivedt;
    void Start()
    {

        eg = PlayerPrefs.GetInt("eg", eg);
        fh = PlayerPrefs.GetInt("fh", fh);
        dt = PlayerPrefs.GetInt("dt", dt);
        bonusdistance = PlayerPrefs.GetFloat("bonusdistance", bonusdistance); 
       

        giveeg = PlayerPrefs.GetFloat("giveeg", giveeg);
        givefh = PlayerPrefs.GetFloat("givefh", givefh);
        givedt = PlayerPrefs.GetFloat("givedt", givedt);

        tgiveeg.text = "₩ " + giveeg.ToString("F2");
        elup.text = "LV. " + eg.ToString("D0");
        tgivefh.text = "₩ " + givefh.ToString("F2");
        flup.text = "LV. " + fh.ToString("D0");
        tgivedt.text = "₩ " + givedt.ToString("F2");
        dtlup.text = "LV. " + dt.ToString("D0");
        
    }
    public void EnergyLevelUp() //에너지 레벨업
    {
        if (GameManager.coin > giveeg)
        {
            eg++;
            PlayerPrefs.SetInt("eg", eg);
            GameManager.coin -= giveeg;
            PlayerPrefs.SetFloat("coin", GameManager.coin);
            giveeg *= 1.05f;
            PlayerPrefs.SetFloat("giveeg", giveeg);
            player.maxEnergy *= elevelup;
            PlayerPrefs.SetFloat("Energy", player.maxEnergy);
            elup.text = "LV. " + eg.ToString("D0");
            tgiveeg.text = "₩ " + giveeg.ToString("F2");
            PlayerPrefs.Save();
        }

    }
    public void FishLevelUp() //생선 레벨업
    {
        if (GameManager.coin > givefh)
        {
            fh++;
            PlayerPrefs.SetInt("fh", fh);
            GameManager.coin -= givefh;
            PlayerPrefs.SetFloat("coin", GameManager.coin);
            givefh *= 1.07f;
            PlayerPrefs.SetFloat("givefh", givefh);
            fishData.energy *= flevelup1;
            PlayerPrefs.SetFloat("FEnergy", fishData.energy);
            fishData.score *= flevelup2;
            PlayerPrefs.SetFloat("Fscore", fishData.score);
            flup.text = "LV. " + fh.ToString("D0");
            tgivefh.text = "₩ " + givefh.ToString("F2");
            PlayerPrefs.Save();
        }

    }
    public void DistanceLevelUp()//항해 레벨업
    {
        if (GameManager.coin > givedt)
        {
            dt++;
            PlayerPrefs.SetInt("dt", dt);
            GameManager.coin -= givedt;
            PlayerPrefs.SetFloat("coin", GameManager.coin);
            givedt *= 1.055f;
            PlayerPrefs.SetFloat("givedt", givedt);
            fishData.whalescore *= dlevelup;
            PlayerPrefs.SetFloat("whalescore",fishData.whalescore);
            bonusdistance *= bonuslevelup;
            PlayerPrefs.SetFloat("bonusdistance", bonusdistance); 
            dtlup.text = "LV. " + dt.ToString("D0");
            tgivedt.text = "₩ " + givedt.ToString("F2");
            PlayerPrefs.Save();
        }

    }
}
