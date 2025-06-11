using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    int baseExp = 12; //시작 EXP

    [field : Header("Name")]
    [field : SerializeField] public string UserName { get; private set; }
    [field : SerializeField] public string Job { get; private set; }
    [field : SerializeField] public string Description { get; private set; }

    [field: Header("Status")]
    [field : SerializeField] public int Level { get; private set; }
    [field : SerializeField] public int Atk { get; private set; }
    [field : SerializeField] public int Def { get; private set; }
    [field : SerializeField] public int Hp { get; private set; }
    [field : SerializeField] public float Crit { get; private set; }
    [field : SerializeField] public int CurExp { get; private set; }  
    [field : SerializeField] public int MaxExp { get; private set; }  
    [field : SerializeField] public string Equiment { get; private set; }

    [field: Header("Resource")]
    [field : SerializeField] public int Gold { get; private set; }


    [Header("GameManager")]
    GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        MaxExp = GetMaxExpForLevel(Level);
    }


    public void LevelUp()
    {
        //만렙 999;
        while (Level < 999 && CurExp >= MaxExp) //레벨이 999이상이 넘지않거나 현재 경험치가 최대 경험치 보다 높으면 코드 실행
        {
            CurExp -= MaxExp;  //현재 경험치에서 최대 경험치를 빼고
            Level++;           //레벨을 올려준다
            MaxExp = GetMaxExpForLevel(Level);  //레벨비례 경험치 계산

            if (Level >= 999)  //만약에 레벨 999에서 레벨이 올라도 레벨 999로 초기화
            {
                Level = 999;
                CurExp = 0;
                break;
            }
        }
    }
    public void GetEXP(int getExp)
    {
        CurExp += getExp;  //얻는 경험치
        LevelUp();  //레벨업이 되는지 검사
    }
    private int GetMaxExpForLevel(int level)
    {   //기존 최대 경험치에서 1.2를 계속 곱했더니 시작레벨을 2로놔도 12로 시작하는 현상이 발생해서 따로 시작경험치를 준비
        return (int)Math.Round(baseExp * Math.Pow(1.2, level - 1));  
    }
}
