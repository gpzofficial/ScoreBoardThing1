using UnityEngine;
using TMPro;

public class NewDataInputManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject inputFieldThing;
    public TMP_InputField nameInput;
    public TMP_InputField scoreInput;
    public TMP_InputField levelInput;
    public GameObject blocker;
    public ListManagement lm;

    private int uiMode = 0;
    void Start()
    {
        inputFieldThing.SetActive(false);
        blocker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.N) && uiMode == 0)
        {
            inputFieldThing.SetActive(true);
            blocker.SetActive(true);
            uiMode = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && uiMode == 1)
        {
            inputFieldThing.SetActive(false);
            blocker.SetActive(false);
            uiMode = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Return) && uiMode == 1)
        {
            if (nameInput.text == "cleardat" && scoreInput.text == "cleardat" && levelInput.text == "cleardat")
            {
                lm.ClearData();
                nameInput.text = null;
                scoreInput.text = null;
                levelInput.text = null;
                inputFieldThing.SetActive(false);
                blocker.SetActive(false);

                uiMode = 0;
            }
            else if (nameInput.text != "" && scoreInput.text != "" && levelInput.text != "")
            {
                lm.AddPlayerData(int.Parse(scoreInput.text), nameInput.text, levelInput.text);

                nameInput.text = null;
                scoreInput.text = null;
                levelInput.text = null;
                inputFieldThing.SetActive(false);
                blocker.SetActive(false);

                uiMode = 0;
            }
            
        }
    }
    
    
}
