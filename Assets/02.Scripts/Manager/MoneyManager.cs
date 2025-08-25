using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI userValue;
    public TextMeshProUGUI moneyValue;

    [HideInInspector]
    public int user;        // === 가지고 있는 돈 ===
    [HideInInspector]
    public int money;     // === 현금 ===

    [SerializeField]
    private UserData _user;

    public static MoneyManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        user = 50000;
        money = 100000;

        _user = new UserData("조지현", user, money);

        UpdateUi();
    }

    public void UpdateUi()
    {
        userValue.text = string.Format("{0:N0}원", user);
        moneyValue.text = string.Format("{0:N0}원", money);
    }

    public void Refresh()
    {
        userValue.text = string.Format("{0:N0}원", user);
        moneyValue.text = string.Format("{0:N0}원", money);
    }
}
