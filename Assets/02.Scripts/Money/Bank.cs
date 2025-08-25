using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public GameObject popupError;

    public TMP_InputField inputPlus;
    public TMP_InputField inputMinus;

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
        }
        else
        {
            inputPlus.text = null;
            Debug.LogError("숫자만 입력해주세요");
        }

    }

    public void OnClickInputMinus()
    {
        string inputText = inputMinus.text;

        if (int.TryParse(inputText, out _inputValue))
        {
            OnClickMinus(_inputValue);
        }
        else
        {
            inputMinus.text = null;
            Debug.LogError("숫자만 입력해주세요");
        }

    }

    public void OnClickPlus(int value)
    {
        if(value > MoneyManager.Instance._user.cashValue) // === 돈이 부족할 경우 ===
        {
            StartCoroutine(INoMoney());
        }
        else
        {
            MoneyManager.Instance._user.usermoney += value;
            MoneyManager.Instance._user.cashValue -= value;

            MoneyManager.Instance.Refresh();
        }
    }

    public void OnClickMinus(int value)
    {
        if (value > MoneyManager.Instance._user.usermoney) // === 돈이 부족할 경우 ===
        {
            StartCoroutine(INoMoney());
        }
        else 
        {
            MoneyManager.Instance._user.usermoney -= value;
            MoneyManager.Instance._user.cashValue += value;

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
