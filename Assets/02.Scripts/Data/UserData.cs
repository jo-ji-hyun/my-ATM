using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]       // === inspector창에 보임 ===
public class UserData
{
    public string id;
    public string pw;
    public string name;
    public int usermoney;      // === 소지금 ===
    public int cashValue;     // === 현금(입금할 수 있는 금액) ===

    // === 초기값 ===
    public UserData(string newid, string newpw, string newname, int newusermoney, int newvalue)
    {
        id = newid;
        pw = newpw;
        name = newname;
        usermoney = newusermoney;
        cashValue = newvalue;
    }
}

[System.Serializable]
public class UserList
{
    public List<UserData> userList = new();
}



