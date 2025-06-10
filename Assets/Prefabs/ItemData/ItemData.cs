using System;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Resource
}

public enum EquimentType
{
    Weapon,
    UpperAmor,
    LowerAmor
}

[Serializable]
public class ItemDataEquip
{
    public EquimentType Type;
    public int atk;
    public int def;
    public float crit;
    public int hp;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string ItemName;
    public string description;
    public ItemType type;
    public Sprite icon;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Equip")]
    public ItemDataEquip EquipStat;
}
