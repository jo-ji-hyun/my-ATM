using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleInfomation : MonoBehaviour
{
    public TMP_InputField inputID;
    public TMP_InputField inputPw;
    public TMP_InputField inputName;

    public void OnFirstSignUp()
    {
        MoneyManager.Instance._user.id = inputID.text;
        MoneyManager.Instance._user.pw = inputPw.text;
        MoneyManager.Instance._user.name = inputName.text;

        MoneyManager.Instance.SaveData(MoneyManager.Instance._user);
    }
}
