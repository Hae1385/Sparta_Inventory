using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData ItemData;
    public Image icon;
    public TextMeshProUGUI quantityText;
    private Outline outline;

    public UIInventory inventory;

    public int index;
    public bool isEquipped;
    public int quantity;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void OnEnable()
    {
        outline.enabled = isEquipped;
    }

    public void InItem()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = ItemData.icon;
        quantityText.text = quantity > 1 ? quantity.ToString() : string.Empty;

        if (outline != null)
        {
            outline.enabled = isEquipped;
            if (isEquipped)
                quantityText.text = "E";   //장착된 장비는 수량란에 E표시
        }
    }

    public void OutItme()
    {
        ItemData = null;
        icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;
    }

    public void OnClickButton()
    {
        if (ItemData == null) return;

        GameManager.Instance.selectedItemData = ItemData;

        foreach (Transform child in ItemStatSlot)  //장비아이템 스텟슬롯에 있는 오브젝트 삭제
        {
            Destroy(child.gameObject);
        }

        if (selectedItem.type == ItemType.Equipable)  //만약에 아이템 타입이 장비라면
        {
            equipButtons.SetActive(true);  //장착 버튼 활성화

            SelecteEquipItem();  //장착한 장비의 능력치를 검사 및 출력

            equipButton.onClick.RemoveAllListeners();    //초기화
            unEquipButton.onClick.RemoveAllListeners();
            equipButton.onClick.AddListener(() => OnClickEquipButton(index, selectedItem.EquipStat.Type));  //장착버튼
            unEquipButton.onClick.AddListener(() => OnClickUnequipButton(index));  //해제버튼
            UpdateUI();
        }
        else
        {
            equipButtons.SetActive(false); //장비가아니면 장착버튼 비활성화
        }
    }
}
