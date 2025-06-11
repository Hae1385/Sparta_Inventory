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
        if (Jop != null && uiManager.gameManager.character.Job != null)
            Jop.text = uiManager.gameManager.character.Job;

        if (NickName != null && uiManager.gameManager.character.UserName != null)
            NickName.text = uiManager.gameManager.character.UserName;

        if (Description != null && uiManager.gameManager.character.Description != null)
            Description.text = uiManager.gameManager.character.Description;

        if (Level != null)
            Level.text = string.Format("{0:N0}", uiManager.gameManager.character.Level);

        if (EXP != null)
            EXP.text = uiManager.gameManager.character.CurExp + "/" + uiManager.gameManager.character.MaxExp;

        if (Gold != null)
            Gold.text = string.Format("{0:N0}", uiManager.gameManager.character.Gold);

        expBar.fillAmount = Getpercentage();  //퍼센트를 계산해서 UI의 exp바의 fillAmount를 조정
    }

    private float Getpercentage()  //퍼센트를 계산
    {
        return (float)uiManager.gameManager.character.CurExp / uiManager.gameManager.character.MaxExp;
    }
}
