using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRemittance : MonoBehaviour
{
    public void OnClickYES()
    {
        if(MoneyManager.Instance.ischeck == true)
        {
            TradeMoneyManager.Instance.GiveMoney();
            MoneyManager.Instance.ischeck = false;
        }
    }

    public void OnClickNo()
    {
        TradeMoneyManager.Instance.popupRemittance.SetActive(false);
        MoneyManager.Instance.ischeck = false;
    }

}
