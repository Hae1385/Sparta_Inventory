using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Character character;
    public UIManager uiManager;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
