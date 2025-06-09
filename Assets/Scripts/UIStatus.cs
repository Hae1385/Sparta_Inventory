using TMPro;
using UnityEngine;

public class UIStatus : MonoBehaviour
{
    UIManager uiManager;

    [SerializeField] private TextMeshProUGUI atkStat;
    [SerializeField] private TextMeshProUGUI defStat;
    [SerializeField] private TextMeshProUGUI hpStat;
    [SerializeField] private TextMeshProUGUI critStat;

    private void Awake()
    {
        uiManager = GetComponentInParent<UIManager>();
    }

    private void Update()
    {
        UpdateStatusUI();
    }
    
    public void UpdateStatusUI()
    {
        if (atkStat != null)
            atkStat.text = string.Format("{0:N0}", uiManager.gameManager.character.Atk);

        if (defStat != null)
            defStat.text = string.Format("{0:N0}", uiManager.gameManager.character.Def);

        if (hpStat != null)
            hpStat.text = string.Format("{0:N0}", uiManager.gameManager.character.Hp);

        if (critStat != null)
            critStat.text = string.Format("{0:N0}", uiManager.gameManager.character.Crit);
    }
}
