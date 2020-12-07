using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHelmetStats : MonoBehaviour
{
    public CharacterObject character;
    public Image spriteImage;
    public Text helmetStats;

    void Update()
    {
        if (character.helmetEquipped == true)
        {
            for (int i = 0; i < character.Container.Count; i++)
            {
                if (character.Container[i].item.type.ToString() == "Helmet")
                {
                    string name = spriteImage.sprite.name;
                    float health = character.Container[i].item.health;
                    helmetStats.text = name + "\n" + health + " HP";
                    break;
                }
            }
        }
        else
        {
            helmetStats.text = "No helmet equipped.";
        }
    }
}
