using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    UIManager uiManager;

    private void Awake()
    {
        uiManager = GetComponentInParent<UIManager>();
    }
}
