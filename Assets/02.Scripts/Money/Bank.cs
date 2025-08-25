using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public GameObject popupError;

    public TextMeshProUGUI inputPlus;
    public TextMeshProUGUI inputMinus;

    private int _inputValue;

    private void Awake()
    {
        popupError.SetActive(false);
    }

    public void OnClickInputPlus()
    {
        string inputText = inputPlus.text;

        if(int.TryParse(inputText, out _inputValue))
        {
            OnClickPlus(_inputValue);
            Debug.Log("변형 성공");
        }
        else
        {
            Debug.LogError("숫자만 입력해주세요");
        }


    }

    public void OnClickInputMinus()
    {
        string inputText = inputMinus.text;

        _inputValue = int.Parse(inputText);

        OnClickMinus(_inputValue);
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
