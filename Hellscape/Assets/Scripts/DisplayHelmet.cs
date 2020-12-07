using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHelmet : MonoBehaviour
{
    public CharacterObject character;
    public Image helmetImage;
    public GameObject dropdownUI;
    public bool dropdownActive = false;

    void Update()
    {
        if (character.helmetEquipped == true)
        {
            for (int i = 0; i < character.Container.Count; i++)
            {
                if (character.Container[i].item.type.ToString() == "Helmet")
                {
                    helmetImage.sprite = character.Container[i].item.spriteIcon;
                    break;
                }
            }
        }

        if (character.helmetEquipped == false)
        {
            dropdownActive = false;
            dropdownUI.SetActive(false);
        }
    }

    public void openDropdownUI()
    {
        if (character.helmetEquipped == true)
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

    public void UnequipHelmet()
    {
        helmetImage.sprite = null;
        character.Unequip("Helmet");
        character.FalsifyHelmet();
    }
}
