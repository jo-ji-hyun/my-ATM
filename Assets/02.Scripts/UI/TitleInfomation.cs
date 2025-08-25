using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleInfomation : MonoBehaviour
{
    public TMP_InputField inputID;
    public TMP_InputField inputPw;
    public TMP_InputField inputName;

    [Header("login")]
    public GameObject popup;
    public TextMeshProUGUI popupTxt;

    // === 첫 회원가입 시 ===
    public void OnFirstSignUp()
    {
        if(MoneyManager.Instance.isfirst == true)
        {
            MoneyManager.Instance._users.userList[0].id = inputID.text;
            MoneyManager.Instance._users.userList[0].pw = inputPw.text;
            MoneyManager.Instance._users.userList[0].name = inputName.text;

            MoneyManager.Instance.isfirst = false;   // === 회원가입 완료 ===

            MoneyManager.Instance.SaveData(MoneyManager.Instance._users);

            popup.SetActive(true);
            popupTxt.text = "회원가입 성공";
        }
        else
        {
            foreach(var list in MoneyManager.Instance._users.userList)
            {
                if (list.id != inputID.text)
                {
                    MoneyManager.Instance._user.id = inputID.text;
                    MoneyManager.Instance._user.pw = inputPw.text;
                    MoneyManager.Instance._user.name = inputName.text;

                    MoneyManager.Instance.SaveData(MoneyManager.Instance._users);

                    popup.SetActive(true);
                    popupTxt.text = "회원가입 성공";
                    return;
                }
                else
                {
                    popup.SetActive(true);
                    popupTxt.text = "중복된 아이디입니다.";
                    return;
                }
            }
        }
    }

    // === 로그인 버튼을 누를시 ===
    public void OnLogin()
    {
        if(MoneyManager.Instance.isfirst == true)
        {
            popup.SetActive(true);
            popupTxt.text = "회원가입을 먼저 해주세요!";
        }
        else if(MoneyManager.Instance._user.id == inputID.text && MoneyManager.Instance._user.pw == inputPw.text && MoneyManager.Instance._user.name == inputName.text)
        {
            popup.SetActive(true);
            popupTxt.text = "로그인 성공!";

            StartCoroutine(ILogin());
        }
        else
        {
            popup.SetActive(true);
            popupTxt.text = "회원 정보가 일치하지 않습니다!";
        }
    }

    private IEnumerator ILogin()
    {
        yield return new WaitForSeconds(1f);

        popup.SetActive(false);

        MoneyManager.Instance.startImage.gameObject.SetActive(false);
        MoneyManager.Instance.nextImage.gameObject.SetActive(true);
    }
}
