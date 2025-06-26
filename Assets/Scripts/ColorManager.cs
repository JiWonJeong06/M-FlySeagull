using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public SpriteRenderer player;  
    public Image previewImage;    // 색상을 적용할 스프라이트
    public Slider Red;
    public Slider Green;
    public Slider Blue;

    public Text RedText;               // R값을 보여줄 텍스트
    public Text GreenText;             // G값을 보여줄 텍스트
    public Text BlueText;              // B값을 보여줄 텍스트

    void Start()
    {
        // 저장된 RGB 값을 불러오기 (기본값: 255)
        float savedRed = PlayerPrefs.GetFloat("red", 255f);
        float savedGreen = PlayerPrefs.GetFloat("green", 255f);
        float savedBlue = PlayerPrefs.GetFloat("blue", 255f);

        // 슬라이더에 값 설정
        Red.value = savedRed;
        Green.value = savedGreen;
        Blue.value = savedBlue;

        // 초기 색상 적용
        ApplyColor(savedRed, savedGreen, savedBlue);

        // 초기 텍스트 업데이트
        UpdateColorTexts(savedRed, savedGreen, savedBlue);

        // 슬라이더 이벤트 연결
        Red.onValueChanged.AddListener(delegate { OnColorChanged(); });
        Green.onValueChanged.AddListener(delegate { OnColorChanged(); });
        Blue.onValueChanged.AddListener(delegate { OnColorChanged(); });
    }

    void OnColorChanged()
    {
        float r = Red.value;
        float g = Green.value;
        float b = Blue.value;

        // 색상 적용
        ApplyColor(r, g, b);

        // 텍스트 갱신
        UpdateColorTexts(r, g, b);

        // 저장
        PlayerPrefs.SetFloat("red", r);
        PlayerPrefs.SetFloat("green", g);
        PlayerPrefs.SetFloat("blue", b);
        PlayerPrefs.Save();
    }

    void ApplyColor(float r255, float g255, float b255)
    {
        Color newColor = player.color;
        newColor.r = r255 / 255f;
        newColor.g = g255 / 255f;
        newColor.b = b255 / 255f;
        player.color = newColor;
        previewImage.color = newColor;  
    }

    void UpdateColorTexts(float r, float g, float b)
    {
        RedText.text = $"{(int)r}";
        GreenText.text = $"{(int)g}";
        BlueText.text = $"{(int)b}";
    }
}
