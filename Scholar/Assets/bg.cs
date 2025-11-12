using UnityEngine;
using UnityEngine.UI;

public class FullscreenBackground : MonoBehaviour
{
    void Start()
    {
        MakeFullscreen();
    }
    
    void MakeFullscreen()
    {
        RectTransform rect = GetComponent<RectTransform>();
        if (rect != null)
        {
            rect.anchoredPosition = Vector2.zero;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.sizeDelta = Vector2.zero;
        }
    }
}
