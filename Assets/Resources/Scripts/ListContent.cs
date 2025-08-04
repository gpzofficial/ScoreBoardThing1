using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ListContent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject PlayerName;
    public GameObject PlayerScore;
    public GameObject PlayerRank;

    private int _rank;
    private int _score;
    private string _level;
    private string _name;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public int GetRank()
    {
        return _rank;
    }

    public void SetRank(int rank)
    {
        _rank = rank;
    }


    public void SetData(int nScore, string nName, string nLevel)
    {
        _score = nScore;
        _level = nLevel;
        _name = nName;
    }

    public void SetColorByRank()
    {
        Image bgImage = gameObject.GetComponent<Image>();
        if (_rank == 1)
        {
            bgImage.color = new Color(255 / 255f, 206 / 255f, 89 / 255f);
            PlayerName.GetComponent<TMP_Text>().color = new Color(23 / 255f, 23 / 255f, 23 / 255f);
            PlayerScore.GetComponent<TMP_Text>().color = new Color(23 / 255f, 23 / 255f, 23 / 255f);
            PlayerRank.GetComponent<TMP_Text>().color = new Color(23 / 255f, 23 / 255f, 23 / 255f);
        }
        else if (_rank == 2)
        {
            bgImage.color = new Color(246 / 255f, 251 / 255f, 255 / 255f);
            PlayerName.GetComponent<TMP_Text>().color = new Color(23 / 255f, 23 / 255f, 23 / 255f);
            PlayerScore.GetComponent<TMP_Text>().color = new Color(23 / 255f, 23 / 255f, 23 / 255f);
            PlayerRank.GetComponent<TMP_Text>().color = new Color(23 / 255f, 23 / 255f, 23 / 255f);
        }
        else if (_rank == 3)
        {
            bgImage.color = new Color(249 / 255f, 123 / 255f, 81 / 255f);
            PlayerName.GetComponent<TMP_Text>().color = new Color(23 / 255f, 23 / 255f, 23 / 255f);
            PlayerScore.GetComponent<TMP_Text>().color = new Color(23 / 255f, 23 / 255f, 23 / 255f);
            PlayerRank.GetComponent<TMP_Text>().color = new Color(23 / 255f, 23 / 255f, 23 / 255f);
        }
        else
        {
            bgImage.color = new Color(56 / 255f, 56 / 255f, 56 / 255f);
            
        }

    }

    public void SetContent(int nRank, int nScore, string nName, string nLevel)
    {
        SetRank(nRank);
        SetData(nScore, nName, nLevel);
        SetColorByRank();
        PlayerName.GetComponent<TMP_Text>().text = _name;
        PlayerRank.GetComponent<TMP_Text>().text = _rank.ToString();
        PlayerScore.GetComponent<TMP_Text>().text = _score.ToString() + " • " + _level;
    }
    
    
}
