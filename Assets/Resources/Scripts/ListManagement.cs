using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int score;
    public string name;
    public string level;
}

[Serializable]
public class PlayerDataList
{
    public List<PlayerData> data;
    public PlayerDataList(List<PlayerData> dat)
    {
        data = dat;
    }
}

public class ListManagement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject scrollViewContentArea;
    // HEIGHT = 250, SPACING = 40;

    
    public GameObject listContentPrefab;
    public string savePath;

    public PlayerDataList playerDataList = new PlayerDataList(null);


    void Start()
    {
        savePath = Application.persistentDataPath + "/playerData.json";
        // if file exists, load data
        if (System.IO.File.Exists(savePath))
        {
            string json = System.IO.File.ReadAllText(savePath);
            playerDataList = JsonUtility.FromJson<PlayerDataList>(json);
            SortPlayerDataByScore();
            UpdateScrollView();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SortPlayerDataByScore()
    {
        // sort playerDataList.data by score
        playerDataList.data.Sort((x, y) => y.score.CompareTo(x.score));
    }

    public void AddPlayerData(PlayerData data)
    {
        playerDataList.data.Add(data);
        SortPlayerDataByScore();
        UpdateScrollView();
    }

    public void AddPlayerData(int score, string name, string level)
    {
        PlayerData data = new PlayerData();
        data.score = score;
        data.name = name;
        data.level = level;
        playerDataList.data.Add(data);
        SortPlayerDataByScore();
        UpdateScrollView();
        // save data
        string json = JsonUtility.ToJson(playerDataList);
        Debug.Log(json);
        System.IO.File.WriteAllText(savePath, json);
    }

    void UpdateScrollView()
    {
        foreach (Transform child in scrollViewContentArea.transform)
        {
            Destroy(child.gameObject);
        }
        int listOrder = 0;
        foreach (var pd in playerDataList.data)
        {
            listOrder++;
            GameObject content = Instantiate(listContentPrefab, scrollViewContentArea.transform);
            ListContent listContent = content.GetComponent<ListContent>();
            listContent.SetContent(listOrder, pd.score, pd.name, pd.level);
            content.GetComponent<RectTransform>().anchoredPosition = new Vector2(listContent.GetComponent<RectTransform>().anchoredPosition.x, -listOrder * 230 + 170);
        }
        scrollViewContentArea.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollViewContentArea.GetComponent<RectTransform>().sizeDelta.x, playerDataList.data.Count * 230 + 40);
    }

    public void ClearData()
    {
        // remove all data
        playerDataList.data.Clear();
        UpdateScrollView();
        // save data
        string json = JsonUtility.ToJson(playerDataList);
        System.IO.File.WriteAllText(savePath, json);
    }

}
