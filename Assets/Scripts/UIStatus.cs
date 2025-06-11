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
    
    public void UpdateStatusUI()
    {
        equipstat = uiManager.InvenMenu.GetTotalEquipStat(); //현재 장비의 능력치를 합산

        //장비의 스텟을 검사해 0이면 현 능력치만 출력 0이 아니라면 능력치 + 장비능력치가 출력
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
