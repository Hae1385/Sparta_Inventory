using TMPro;
using UnityEngine;

public class ItemStatValue : MonoBehaviour
{
    public TextMeshProUGUI statNameText;
    public TextMeshProUGUI statValueText;

    public void SetStat(string name, float value)
    {
        statNameText.text = name;
        statValueText.text = value.ToString();
    }
}
