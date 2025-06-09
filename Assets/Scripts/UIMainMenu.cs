using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    UIManager uiManager;

    [SerializeField] TextMeshProUGUI Jop;
    [SerializeField] TextMeshProUGUI NickName;
    [SerializeField] TextMeshProUGUI Description;
    [SerializeField] TextMeshProUGUI Level;
    [SerializeField] TextMeshProUGUI EXP;
    [SerializeField] TextMeshProUGUI Gold;
    [SerializeField] Image expBar;
    private void Awake()
    {
        uiManager = GetComponentInParent<UIManager>();
    }
    private void Update()
    {
        
    }

    public void UpdateMainUI()
    {
        Debug.Log(NickName);
        Debug.Log(uiManager.gameManager.character.userName);
        if (Jop != null && uiManager.gameManager.character.job != null)
            Jop.text = uiManager.gameManager.character.job;

        if (NickName != null && uiManager.gameManager.character.userName != null)
            NickName.text = uiManager.gameManager.character.userName;

        if (Description != null && uiManager.gameManager.character.description != null)
            Description.text = uiManager.gameManager.character.description;

        if (Level != null)
            Level.text = string.Format("{0:N0}", uiManager.gameManager.character.level);

        if (EXP != null)
            EXP.text = uiManager.gameManager.character.curExp + "/" + uiManager.gameManager.character.maxExp;

        if (Gold != null)
            Gold.text = string.Format("{0:N0}", uiManager.gameManager.character.gold);

        expBar.fillAmount = Getpercentage();
    }

    private float Getpercentage()
    {
        return (float)uiManager.gameManager.character.curExp / uiManager.gameManager.character.maxExp;
    }
}
