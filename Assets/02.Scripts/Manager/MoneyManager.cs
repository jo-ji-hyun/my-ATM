using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI userValue;
    public TextMeshProUGUI moneyValue;

    public int user;
    public int money;

    private void Awake()
    {
        user = 50000;
        money = 100000;

        UpdateUi();
    }

    public void UpdateUi()
    {
        userValue.text = string.Format("{0:N0}¿ø", user);
        moneyValue.text = string.Format("{0:N0}¿ø", money);
    }
}
