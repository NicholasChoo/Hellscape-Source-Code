using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public CharacterObject character;

    public void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
        character.Container.Clear();
        character.helmetEquipped = false;
        character.armourEquipped = false;
        character.swordEquipped = false;
    }

    public void SaveData()
    {
        inventory.Save();
        character.Save();
    }

    public void LoadData()
    {
        inventory.Load();
        character.Load();
    }
}
