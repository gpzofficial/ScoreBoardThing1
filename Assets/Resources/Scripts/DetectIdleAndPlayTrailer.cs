using UnityEngine;
using UnityEngine.UI;

public class DetectIdleAndPlayTrailer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool isVideoRevealed = false;

    void Start()
    {

    }

    private float idleTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (!isVideoRevealed)
        {
            idleTime += Time.deltaTime;
            if (idleTime > 20)
            {
                GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
                idleTime = 0;
                isVideoRevealed = true;
            }
        }

        if (Input.anyKey)
        {
            idleTime = 0;
            isVideoRevealed = false;
            GetComponent<RawImage>().color = new Color(1, 1, 1, 0);
        }
        
    }
}
