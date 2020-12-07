using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayArmourStats : MonoBehaviour
{
    public CharacterObject character;
    public Image spriteImage;
    public Text armourStats;

    void Update()
    {
        if (character.armourEquipped == true)
        {
            for (int i = 0; i < character.Container.Count; i++)
            {
                if (character.Container[i].item.type.ToString() == "Armour")
                {
                    string name = spriteImage.sprite.name;
                    float health = character.Container[i].item.health;
                    armourStats.text = name + "\n" + health + " HP";
                    break;
                }
            }
        }
        else
        {
            armourStats.text = "No armour equipped.";
        }
    }
}
