using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySword : MonoBehaviour
{
    public CharacterObject character;
    public Image swordImage;
    public GameObject dropdownUI;
    public bool dropdownActive = false;

    void Update()
    {
        if (character.swordEquipped == true)
        {
            for (int i = 0; i < character.Container.Count; i++)
            {
                if (character.Container[i].item.type.ToString() == "Sword")
                {
                    swordImage.sprite = character.Container[i].item.spriteIcon;
                    break;
                }
            }
        }

        if (character.swordEquipped == false)
        {
            dropdownActive = false;
            dropdownUI.SetActive(false);
        }
    }

    public void openDropdownUI()
    {
        if (character.swordEquipped == true)
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

    public void UnequipSword()
    {
        swordImage.sprite = null;
        character.Unequip("Sword");
        character.FalsifySword();
    }
}
