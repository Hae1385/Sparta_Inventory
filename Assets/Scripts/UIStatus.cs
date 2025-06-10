using TMPro;
using UnityEngine;

public class UIStatus : MonoBehaviour
{
    UIManager uiManager;

    [SerializeField] private TextMeshProUGUI atkStat;
    [SerializeField] private TextMeshProUGUI defStat;
    [SerializeField] private TextMeshProUGUI hpStat;
    [SerializeField] private TextMeshProUGUI critStat;

    EquipStats equipstat;

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
        equipstat = uiManager.InvenMenu.GetTotalEquipStat();
        if (atkStat != null)
            atkStat.text = equipstat.atk != 0 ? $"{uiManager.gameManager.character.Atk} + {equipstat.atk}" : $"{uiManager.gameManager.character.Atk}";

        if (defStat != null)
            defStat.text = equipstat.def != 0 ? $"{uiManager.gameManager.character.Def} + {equipstat.def}" : $"{uiManager.gameManager.character.Def}";

        if (hpStat != null)
            hpStat.text = equipstat.hp != 0 ? $"{uiManager.gameManager.character.Hp} + {equipstat.hp}" : $"{uiManager.gameManager.character.Hp}";

        if (critStat != null)
            critStat.text = equipstat.crit != 0 ? $"{uiManager.gameManager.character.Crit} + {equipstat.crit}" : $"{uiManager.gameManager.character.Crit}";
    }
}
