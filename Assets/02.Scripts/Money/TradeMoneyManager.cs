using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class TradeMoneyManager : MonoBehaviour
{
    public TMP_InputField inputID;
    public TMP_InputField inputValue;

    [Header("Check")]
    public GameObject popup;                // === 확인용 ===
    public GameObject popupRemittance;      // === 송금 확인용 ===
    public TextMeshProUGUI popupTxt;

    private int _inputValue;

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

        if(inputID.text == MoneyManager.Instance._user.id) // 나중에 수정
        {
            popupTxt.text = "존재합니다.";
            MoneyManager.Instance.ischeck = true;
        }
        else
        {
            popupTxt.text = "존재하지 않습니다.";
        }
    }

    // === 보낼 금액 확인 ===
    public void OnCheckGiveMoney()
    {
        popupRemittance.SetActive(true);
    }

    // === 돈을 송금 ===
    public void GiveMoney()
    {
        string input = inputValue.text;

        if (int.TryParse(input, out _inputValue))
        {
            
        }
    }
}
