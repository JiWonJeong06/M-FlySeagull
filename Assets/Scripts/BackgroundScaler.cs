using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundScaler : MonoBehaviour
{
    void Update()
    {
        FitToScreen();
    }

    void FitToScreen()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr.sprite == null) return;

        // 카메라의 높이와 너비 계산
        float screenHeight = cam.orthographicSize * 2f;
        float screenWidth = screenHeight * cam.aspect;
        screenHeight = cam.orthographicSize * 1.25f;

        // 스프라이트 원본 사이즈
        Vector2 spriteSize = sr.sprite.bounds.size;

        // 배경의 새로운 스케일 계산
        Vector3 scale = transform.localScale;
        scale.x = screenWidth / spriteSize.x;
        scale.y = screenHeight / spriteSize.y;

        transform.localScale = scale;
    }
}
