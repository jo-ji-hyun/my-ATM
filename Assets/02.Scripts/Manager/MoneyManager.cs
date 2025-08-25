using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI userValue;
    public TextMeshProUGUI moneyValue;

    private string _filePath;

    // === 처음인지 확인 ===
    public bool isfirst;

    public UserData _user;

    [Header("image")]
    public Image startImage;
    public Image nextImage;

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
        moneyValue.text = string.Format("{0:N0}원", _user.cashValue);
    }

    public void Refresh()
    {
        userValue.text = string.Format("{0:N0}원", _user.usermoney);
        moneyValue.text = string.Format("{0:N0}원", _user.cashValue);

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
            (" "," "," ", 50000, 100000);

            isfirst = true;

            SaveData(_user);
        }
    }

    public void SaveData(UserData userData)
    {
        var saveData = JsonUtility.ToJson(userData);

        File.WriteAllText(_filePath, saveData);
    }
}
