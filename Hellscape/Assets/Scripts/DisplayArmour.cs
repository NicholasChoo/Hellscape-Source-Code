using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayArmour : MonoBehaviour
{
    public CharacterObject character;
    public Image armourImage;
    public GameObject dropdownUI;
    public bool dropdownActive = false;

    void Update()
    {
        if (character.armourEquipped == true)
        {
            for (int i = 0; i < character.Container.Count; i++)
            {
                if (character.Container[i].item.type.ToString() == "Armour")
                {
                    armourImage.sprite = character.Container[i].item.spriteIcon;
                    break;
                }
            }
        }

        if (character.armourEquipped == false)
        {
            dropdownActive = false;
            dropdownUI.SetActive(false);
        }
    }

    public void openDropdownUI()
    {
        if (character.armourEquipped == true)
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
    }

    public void UnequipArmour()
    {
        armourImage.sprite = null;
        character.Unequip("Armour");
        character.FalsifyArmour();
    }
}
