using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]       // === inspector창에 보임 ===
public class UserData
{
    public string name;
    public int usermoney; // === 소지금 ===
    public int value;     // === 현금 ===

    // === 초기값 ===
    public UserData(string newname, int newusermoney, int newvalue)
    {
        name = newname;
        usermoney = newusermoney;
        value = newvalue;
    }
}


    

