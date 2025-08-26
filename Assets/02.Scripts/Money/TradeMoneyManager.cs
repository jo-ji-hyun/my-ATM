using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TradeMoneyManager : MonoBehaviour
{
    public TMP_InputField inputID;
    public TMP_InputField inputValue;

    [Header("Check")]
    public GameObject popup;                // === 확인용 ===
    public GameObject popupRemittance;      // === 송금 확인용 ===
    public TextMeshProUGUI popupTxt;

    private int _inputValue;
    private int _keyNumber;                // === 넘겨줄 사람의 신원 ===

    public static TradeMoneyManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // === 상대방 신원 조회 ===
    public void OnCheckID()
    {
        popup.SetActive(true);

        if(inputID.text != null && inputID.text != MoneyManager.Instance._user.id) 
        {
            for(int i = 0; i < MoneyManager.Instance._users.userList.Count; i++)
            {
                if(inputID.text == MoneyManager.Instance._users.userList[i].id)
                {
                    popupTxt.text = "존재합니다.";
                    MoneyManager.Instance.ischeck = true;
                    _keyNumber = i;
                    break;
                }
            }
        }
        else if(inputID.text == MoneyManager.Instance._user.id)
        {
            popupTxt.text = " id를 확인해 주세요.";
        }
        else
        {
            popupTxt.text = "존재하지 않습니다.";
        }
    }

    // === 보낼 금액 확인 ===
    public void OnCheckGiveMoney()
    {
        if (MoneyManager.Instance.ischeck == false) return;

        popupRemittance.SetActive(true);
    }

    // === 돈을 송금 ===
    public void GiveMoney()
    {
        string input = inputValue.text;

        if (int.TryParse(input, out _inputValue))
        {
            if (MoneyManager.Instance._user.usermoney < _inputValue)
            {
                popup.SetActive(true);
                popupTxt.text = "금액이 부족합니다.";
                return;
            }

            MoneyManager.Instance._user.usermoney -= _inputValue;
            MoneyManager.Instance._users.userList[_keyNumber].usermoney += _inputValue;

            popupRemittance.SetActive(false);
            MoneyManager.Instance.ischeck = false;

            MoneyManager.Instance.Refresh();
            MoneyManager.Instance.SaveData(MoneyManager.Instance._users);
        }
        else
        {
            Debug.LogError("숫자를 입력해주세요.");
            inputValue.text = null;
        }
    }
}
