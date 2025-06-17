using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EquipStats
{
    public int atk;
    public int def;
    public float crit;
    public int hp;

    public EquipStats()
    {
        atk = 0; def = 0; crit = 0; hp = 0;
    }

    public void Add(ItemDataEquip stat)
    {
        atk += stat.atk;
        def += stat.def;
        crit += stat.crit;
        hp += stat.hp;
    }
}

public class UIInventory : MonoBehaviour
{
    UIManager uiManager;
    public int maxItemSlotCount = 119;
    public TextMeshProUGUI inventorySlotstext;


    
    public GameObject slotPrefab;
    public Transform slotPanel;
    public List<ItemData> randomItems = new List<ItemData>();

    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;
    public GameObject ItemStat;
    public Transform ItemStatSlot;

    public GameObject equipButtons;
    public Button equipButton;
    public Button unEquipButton;

    ItemData selectedItem;
    int selectedItemIndex = 0;

    private void Awake()
    {
        uiManager = GetComponentInParent<UIManager>();
        equipButtons.SetActive(false);
    }

    private void Start()
    {
        slots.Clear();
        for (int i = 0; i < slotPanel.childCount; i++)
        {
            ItemSlot slot = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            slot.index = i;
            slot.inventory = this;
            slots.Add(slot);
            ClearSelctedItemWindow();
        }
    }

    void ClearSelctedItemWindow()
    {
        ItemName.text = string.Empty;
        ItemDescription.text = string.Empty;
    }

    public void AddRandomItem()
    {
        AddItem(randomItems[Random.Range(0, randomItems.Count)]);
    }

    public void AddItem(ItemData data)
    {
        if (data.canStack)
        {
            ItemSlot slot = GetItemStack(data);
            if (slot != null)
            {
                slot.quantity++;
                UpdateUI();
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            emptySlot.ItemData = data;
            emptySlot.quantity = 1;
            UpdateUI();
            return;
        }
    }


    ItemSlot GetItemStack(ItemData data)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].ItemData == data && slots[i].quantity < data.maxStackAmount)
            {
                return slots[i];
            }
        }
        UpdateUI();
        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].ItemData == null)
            {
                return slots[i];
            }
        }
        // 비어있는 슬롯이 없고, 최대 슬롯 수 미만이면 새 슬롯 생성
        if (slots.Count < maxItemSlotCount)
        {
            CreateNewSlot();
            return slots[slots.Count - 1]; // 새로 만든 슬롯 반환
        }
        return null; //슬롯초과시 생성 x
    }

    private void UpdateUI()
    {
        if (slots.Count == 0)
        {
            return;
        }
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].ItemData == null)
            {
                slots[i].OutItme();
                slots[i].gameObject.SetActive(false); // 슬롯 자체 비활성화
            }
            else
            {
                slots[i].gameObject.SetActive(true);  // 슬롯 활성화
                slots[i].InItem();
            }
        }
        inventorySlotstext.text = slots.Count + "/" + (maxItemSlotCount + 1);
    }

    public void SelectItem()
    {
        
    }

    public void SelecteEquipItem()
    {
        string[] statNames = { "atk", "def", "crit", "hp" };
        float[] statValues = {
                selectedItem.EquipStat.atk,
                selectedItem.EquipStat.def,
                selectedItem.EquipStat.crit,
                selectedItem.EquipStat.hp
                };
        for (int i = 0; i < statNames.Length; i++)  //atk def crit hp 총 네개만큼 반복
        {
            if (statValues[i] != 0)  //스텟이 0이되면 출력이 되지않도록 작성
            {   //스텟이 0이아니라면 예)atk 10 등과같이 출력되게 조치
                GameObject statObj = Instantiate(ItemStat, ItemStatSlot);  
                ItemStatValue statValueScript = statObj.GetComponent<ItemStatValue>();
                statValueScript.SetStat(statNames[i], statValues[i]);
            }
        }
    }

    public void OnClickEquipButton(EquimentType type)
    {
        for (int i = 0; i < slots.Count; i++)  //모든 슬롯을 검사해서
        {
            if (slots[i].ItemData != null && slots[i].ItemData.EquipStat != null) 
            {
                if (i != selected && slots[i].ItemData.EquipStat.Type == type)  //장착한 장비타입과 동일한 장비타입이 있으면
                {
                    slots[i].isEquipped = false;  //장착해제
                }
            }
        }

        if (slots[selected].ItemData != null)  
            //slots[selected].isEquipped = true;  //해당장비 장착

        UpdateUI();
    }

    public void OnClickUnequipButton(int selected)
    {
        //slots[selected].isEquipped = false;  //선택한 장비를 isEquipped = false로 변경
        UpdateUI();
    }

    public EquipStats GetTotalEquipStat()  //장비의 모든 스텟을 계산해서 저장
    {
        EquipStats total = new EquipStats();  //atk = 0; def = 0; crit = 0; hp = 0;
        for (int i = 0; i < slots.Count; i++)  //슬롯에 있는 아이템을검사해
        {    //isEquipped가 true인 장비만 검사
            if (slots[i].isEquipped && slots[i].ItemData != null && slots[i].ItemData.EquipStat != null)
            {
                total.Add(slots[i].ItemData.EquipStat);  //반복해서 모든 스텟을 더해주고
            }
        }
        UpdateUI();  
        return total; //더해준 모든 스텟을 반환
    }

    void CreateNewSlot()
    {
        if (slots.Count > maxItemSlotCount) return; // 120개 초과 방지

        GameObject newSlotObj = Instantiate(slotPrefab, slotPanel);
        ItemSlot newSlot = newSlotObj.GetComponent<ItemSlot>();
        newSlot.index = slots.Count;
        newSlot.inventory = this;
        slots.Add(newSlot);
    }
}
