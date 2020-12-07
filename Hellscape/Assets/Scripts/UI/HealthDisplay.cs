using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private PlayerAttack PlayerAttck;
    private float health;
    public Text healthText;

    void Start()
    {
        health = PlayerAttack.health;

        healthText.text = "Health: " + health;
    }

    void Update()
    {
        health = PlayerAttack.health;

        healthText.text = "Health: " + health;
    }
}
