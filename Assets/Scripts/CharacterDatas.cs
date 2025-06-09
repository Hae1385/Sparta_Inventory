using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChracterDataList
{
    public List<CharacterDatas> characterDatas = new List<CharacterDatas>();
}
[System.Serializable]
public class CharacterDatas
{
    [Header("Name")]
    public string UserName;
    public string Job;
    public string Description;

    [Header("Status")]
    public int Level;
    public int Atk;
    public int Def;
    public int Hp;
    public int Crit;
    public int CurExp;  //현재 경험치
    public int MaxExp;  //레벨마다 총 경험치량이 늘어날테니 배열로
    public string Equiment;

    [Header("Resource")]
    public int Gold;
}
