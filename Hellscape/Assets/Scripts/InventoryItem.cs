using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public InventoryObject inventory;
    public CharacterObject character;
    public GameObject dropdownUI;
    public bool dropdownActive = false;

    public void openDropdownUI()
    {
        if (dropdownActive == false)
        {
            dropdownUI.SetActive(true);
            dropdownActive = true;
        }
        else
        {
            dropdownUI.SetActive(false);
            dropdownActive = false;
        }
    }

    public void Equip()
    {
        var item = GetComponentInChildren<Item>();
        if (item)
        {
            inventory.Equip(item.item, item.type, 1);
            dropdownUI.SetActive(false);
        }
    }

    public void Delete()
    {
        var item = GetComponentInChildren<Item>();
        if (item)
        {
            inventory.Delete(item.item, 1);
            dropdownUI.SetActive(false);
        }
    }
}
