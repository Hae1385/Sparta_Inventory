using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIMainMenu MainMenu;
    [SerializeField] private UIStatus StatMenu;
    [SerializeField] private UIInventory InvenMenu;

    [SerializeField] TextMeshProUGUI Jop;
    [SerializeField] TextMeshProUGUI NickName;
    [SerializeField] TextMeshProUGUI Description;
    [SerializeField] TextMeshProUGUI Level;
    [SerializeField] TextMeshProUGUI EXP;
    [SerializeField] TextMeshProUGUI Gold;

    public GameManager gameManager;

    private void Start()
    {
        MainMenu.gameObject.SetActive(true);
        StatMenu.gameObject.SetActive(false);
        InvenMenu.gameObject.SetActive(false);
        UpdateUI();
    }

    public void OnStatButton()
    {
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

    public void UpdateUI()
    {
        if (Jop != null && gameManager.character.job != null)
            Jop.text = gameManager.character.job;

        if (NickName != null && gameManager.character.userName != null)
            NickName.text = gameManager.character.userName;

        if (Description != null && gameManager.character.description != null)
            Description.text = gameManager.character.description;

        if (Level != null)
            Level.text = gameManager.character.level + "";

        if (EXP != null)
            EXP.text = gameManager.character.curExp + "/" + gameManager.character.maxExp;

        if (Gold != null)
            Gold.text = string.Format("{0:N0}", gameManager.character.gold);
    }
}
