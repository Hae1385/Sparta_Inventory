using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Character character;
    public UIManager uiManager;
    private void Awake()
    {
        // 싱글턴 인스턴스가 이미 있으면 중복된 객체를 파괴
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        // 씬이 바뀌어도 파괴되지 않게 설정 (필요하다면)
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {

    }
}
