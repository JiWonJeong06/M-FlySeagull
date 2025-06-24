using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public Player player;
    public FishData fishData;
    private float levelup = 1.03f;

    public int eg = 1;
    public int fh = 1;
    public int dt = 1;

    public float giveeg = 1000;
    public float givefh = 1500;
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
            player.maxEnergy *= levelup;
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
            givefh *= 1.15f;
            PlayerPrefs.SetFloat("givefh", givefh);
            fishData.energy *= levelup;
            PlayerPrefs.SetFloat("FEnergy", fishData.energy);
            fishData.score *= levelup;
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
            givedt *= 1.03f;
            PlayerPrefs.SetFloat("givedt", givedt);
            Scroll.whalescore *= levelup;
            PlayerPrefs.SetFloat("whalescore",Scroll.whalescore);
            dtlup.text = "LV. " + dt.ToString("D0");
            tgivedt.text = "₩ " + givedt.ToString("F2");
            PlayerPrefs.Save();
        }

    }
}
