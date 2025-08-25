using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    public GameObject popupDeposit;
    public GameObject popupWithDraw;
    public GameObject popupGive;

    // === 입금시 팝업창 ===
    public void OnClickDepositTrue()
    {
        popupDeposit.SetActive(true);
    }

    public void OnClickDepositFalse()
    {
        popupDeposit.SetActive(false);
    }

    // === 출금시 팝업창 ===
    public void OnClickWithDrawTrue()
    {
        popupWithDraw.SetActive(true);
    }

    public void OnClickWithDrawFalse()
    {
        popupWithDraw.SetActive(false);
    }

    // === 송금시 팝업창 ===
    public void OnClickGiveTrue()
    {
        popupGive.SetActive(true);
    }

    public void OnClickGiveFalse()
    {
        popupGive.SetActive(false);
    }
}
