using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QrRevealer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DOTween.Init();
        
    }

    private bool isRevealed = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Backslash))
        {
            if (isRevealed)
            {
                HideQr();
                isRevealed = false;
            }
            else
            {
                ShowQr();
                isRevealed = true;
            }
        }
    }

    void ShowQr()
    {
        GetComponent<RectTransform>().DOAnchorPosY(-210, 0.4f).SetEase(Ease.OutBack);
    }

    void HideQr()
    {
        GetComponent<RectTransform>().DOAnchorPosY(210, 0.4f).SetEase(Ease.InBack);
    }
    
}
