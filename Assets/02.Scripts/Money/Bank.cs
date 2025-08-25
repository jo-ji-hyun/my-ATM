using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public GameObject popupError;

    private void Awake()
    {
        popupError.SetActive(false);
    }

    public void OnClickPlus(int value)
    {
        if(value > MoneyManager.Instance.money) // === 돈이 부족할 경우 ===
        {
            StartCoroutine(INoMoney());
        }
        else
        {
            MoneyManager.Instance.user += value;
            MoneyManager.Instance.money -= value;

            MoneyManager.Instance.Refresh();
        }
    }

    public void OnClickMinus(int value)
    {
        if (value > MoneyManager.Instance.user) // === 돈이 부족할 경우 ===
        {
            StartCoroutine(INoMoney());
        }
        else 
        {
            MoneyManager.Instance.user -= value;
            MoneyManager.Instance.money += value;

            MoneyManager.Instance.Refresh();
        }
    }

    private IEnumerator INoMoney()
    {
        popupError.SetActive(true);

        yield return new WaitForSeconds(2f);

        popupError.SetActive(false);
    }
}
