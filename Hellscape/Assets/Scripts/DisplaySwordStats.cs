using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySwordStats : MonoBehaviour
{
    public CharacterObject character;
    public Image spriteImage;
    public Text swordStats;

    void Update()
    {
        if (character.swordEquipped == true)
        {
            for (int i = 0; i < character.Container.Count; i++)
            {
                if (character.Container[i].item.type.ToString() == "Sword")
                {
                    string name = spriteImage.sprite.name;
                    float attack = character.Container[i].item.attack;
                    float attackSpeed = character.Container[i].item.attackSpeed;
                    swordStats.text = name + "\n" + attack + " Damage" + "\n" + attackSpeed + " Attack Speed";
                    break;
                }
            }
        }
        else
        {
            swordStats.text = "No sword equipped.";
        }
    }
}
