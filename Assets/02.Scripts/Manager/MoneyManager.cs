using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI userValue;
    public TextMeshProUGUI moneyValue;

    private string _filePath;

    public UserData _user;

    public static MoneyManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        // === 저장 경로 ===
        _filePath = Path.Combine(Application.persistentDataPath, "userData.json");

        LoadData();
        
        UpdateUi();
    }

    public void UpdateUi()
    {
        userValue.text = string.Format("{0:N0}원", _user.usermoney);
        moneyValue.text = string.Format("{0:N0}원", _user.value);
    }

    public void Refresh()
    {
        userValue.text = string.Format("{0:N0}원", _user.usermoney);
        moneyValue.text = string.Format("{0:N0}원", _user.value);

        SaveData(_user);
    }

    public void LoadData()
    {
        //Debug.Log(_filePath); // === 제이슨 파일 저장 경로 ===

        if (File.Exists(_filePath))
        {
            var loadData = File.ReadAllText(_filePath);

            _user = JsonUtility.FromJson<UserData>(loadData);
        }
        else
        {
            _user = new UserData
            ("조지현", 50000, 100000);

            SaveData(_user);
        }
    }

    public void SaveData(UserData userData)
    {
        var saveData = JsonUtility.ToJson(userData);

        File.WriteAllText(_filePath, saveData);
    }
}
