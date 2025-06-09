using System;
using UnityEngine;

public class Character : MonoBehaviour
{
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
    }


    public void LevelUp()
    {   
        //만렙 999;
        while (Level < 999 && CurExp >= MaxExp)
        {
            CurExp -= MaxExp;
            Level++;
            MaxExp = (int)Math.Round(MaxExp * 1.2);

            if (Level >= 999)
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
}
