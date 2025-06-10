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

    public ItemSlot[] slots;
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
    //public EquimentType equimentType;

    private void Awake()
    {
        uiManager = GetComponentInParent<UIManager>();
        equipButtons.SetActive(false);
    }

    private void Start()
    {
        slots = new ItemSlot[slotPanel.childCount];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            slots[i].index = i;
            slots[i].inventory = this;

            ClearSelctedItemWindow();
        }

    }

    private void Update()
    {
        
    }

    void ClearSelctedItemWindow()
    {
        ItemName.text = string.Empty;
        ItemDescription.text = string.Empty;
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

    public void AddRandomItem()
    {
        AddItem(randomItems[Random.Range(0, randomItems.Count)]);
    }

    ItemSlot GetItemStack(ItemData data)
    {
        for (int i = 0; i < slots.Length; i++)
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
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].ItemData == null)
            {
                return slots[i];
            }
        }
        UpdateUI();
        return null;
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
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
    }

    public void SelectItem(int index)
    {
        if (slots[index].ItemData == null) return;

        selectedItem = slots[index].ItemData;
        selectedItemIndex = index;

        ItemName.text = selectedItem.ItemName;
        ItemDescription.text = selectedItem.description;

        foreach (Transform child in ItemStatSlot)
        {
            Destroy(child.gameObject);
        }

        if (slots[index].ItemData.type == ItemType.Equipable)
        {
            equipButtons.SetActive(true);
            if (selectedItem.type == ItemType.Equipable)
            {
                SelecteEquipItem();
            }
            equipButton.onClick.RemoveAllListeners();
            unEquipButton.onClick.RemoveAllListeners();
            equipButton.onClick.AddListener(() => OnClickEquipButton(index, selectedItem.EquipStat.Type));
            unEquipButton.onClick.AddListener(() => OnClickUnequipButton(index));
            UpdateUI();
        }
        else
        {
            equipButtons.SetActive(false);
        }
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
        for (int i = 0; i < statNames.Length; i++)
        {
            if (statValues[i] != 0)
            {
                GameObject statObj = Instantiate(ItemStat, ItemStatSlot);
                ItemStatValue statValueScript = statObj.GetComponent<ItemStatValue>();
                statValueScript.SetStat(statNames[i], statValues[i]);
            }
        }
    }

    public void OnClickEquipButton(int selected, EquimentType type)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].ItemData != null && slots[i].ItemData.EquipStat != null)
            {
                if (i != selected && slots[i].ItemData.EquipStat.Type == type)
                {
                    slots[i].isEquipped = false;
                }
            }
        }
        if (slots[selected].ItemData != null)
            slots[selected].isEquipped = true;

        UpdateUI();
    }

    public void OnClickUnequipButton(int selected)
    {
        slots[selected].isEquipped = false;
        UpdateUI();
    }

    public EquipStats GetTotalEquipStat()
    {
        EquipStats total = new EquipStats();
        for (int i = 0; i < slots.Length;i++)
        {
            if (slots[i].isEquipped && slots[i].ItemData != null && slots[i].ItemData.EquipStat != null)
            {
                total.Add(slots[i].ItemData.EquipStat);
            }
        }
        UpdateUI();
        return total;
    }
}
