using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    public Image popupError;
    private void Awake()
    {
        if(MoneyManager.Instance != null)
        {
            popupError.gameObject.SetActive(false);
        }
    }

    public void OnClickPlus(int value)
    {
        MoneyManager.Instance.user  += value;
        MoneyManager.Instance.money -= value;

        MoneyManager.Instance.Refresh();

        if(MoneyManager.Instance.money <= 0)
        {
            StartCoroutine(INoMoney());
        }
    }

    public void OnClickMinus(int value)
    {
        MoneyManager.Instance.user  -= value;
        MoneyManager.Instance.money += value;
    }

    private IEnumerator INoMoney()
    {
        popupError.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        popupError.gameObject.SetActive(false);
    }
}
