using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; }

    [SerializeField] private UIMainMenu mainMenu;
    [SerializeField] private UIStatus statMenu;
    [SerializeField] private UIInventory invenMenu;

    public UIMainMenu MainMenu => mainMenu;
    public UIStatus StatMenu => statMenu;
    public UIInventory InvenMenu => invenMenu;

    public Button StatButton;
    public Button InvenButton;
    public Button[] CancleButtons;

    public GameManager gameManager;

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
    private void Start()
    {
        MainMenu.gameObject.SetActive(true);
        StatMenu.gameObject.SetActive(false);
        InvenMenu.gameObject.SetActive(false);

        StatButton.onClick.AddListener(OnStatButton);
        InvenButton.onClick.AddListener(OnInvenButton);
        for (int i = 0; i<CancleButtons.Length; i++)
        {
            CancleButtons[i].onClick.AddListener(OnCancleButton);
        }
    }

    public void OnStatButton()
    {
        statMenu.UpdateStatusUI();
        if (this == null || StatMenu == null)
        {
            return;
        }

        MainMenu.gameObject.SetActive(false);
        StatMenu.gameObject.SetActive(true); 
    }

    public void OnInvenButton()
    {
        if (this == null || InvenMenu == null)
        {
            return;
        }

        MainMenu.gameObject.SetActive(false);
        InvenMenu.gameObject.SetActive(true);
    }

    public void OnCancleButton()
    {
        if (this == null || StatMenu == null || InvenMenu == null)
        {
            return;
        }

        MainMenu.gameObject.SetActive(true);
        StatMenu.gameObject.SetActive(false);
        InvenMenu.gameObject.SetActive(false);
    }   
}
