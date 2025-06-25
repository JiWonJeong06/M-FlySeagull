using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;
    
      [SerializeField] private AudioSource[] effectSources;
      public static AudioSource[] effect;

    public Slider Bgmslider;
    public Slider EftSlider;
    public Text Bgmtext;
    public Text Efttext;


    private void Awake()
    {
        effect = effectSources;
    }
    void Start()
    {
        float savedBgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1.0f);
        float savedEftVolume = PlayerPrefs.GetFloat("EFTVolume", 1.0f);
        // 슬라이더 초기값 설정
        Bgmslider.value = savedBgmVolume;
        EftSlider.value = savedEftVolume;

        // 사운드 볼륨 적용
        bgm.volume = savedBgmVolume;
        foreach (AudioSource audio in effect)
        {
            audio.volume = savedEftVolume;
        }
        // 텍스트 갱신
        Bgmtext.text = (savedBgmVolume * 100).ToString("F0");
        Efttext.text = (savedEftVolume * 100).ToString("F0");
        bgm.Play();
    }

  
    void Update()
    {
        bgm.volume = Bgmslider.value;
        foreach (AudioSource audio in effect)
        {
            audio.volume = EftSlider.value;
        }
      

        Bgmtext.text = (Bgmslider.value * 100).ToString("F0");
        Efttext.text = (EftSlider.value * 100).ToString("F0");
        PlayerPrefs.SetFloat("BGMVolume", Bgmslider.value);
        PlayerPrefs.SetFloat("EFTVolume", EftSlider.value);
    }
}
