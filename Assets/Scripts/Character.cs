using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Name")]
    public string userName;  
    public string job;
    public string description;

    [Header("Status")]
    public int level;
    public int atk;
    public int def;
    public int hp;      
    public int crit;    //퍼센트로 해야되는데 float로? 아니면 1단위씩늘어나게?
    public int curExp;  //현재 경험치
    public int maxExp;  //레벨마다 총 경험치량이 늘어날테니 배열로
    public string equiment;

    [Header("Resource")]
    public int gold;

    [Header("GameManager")]
    GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
}
