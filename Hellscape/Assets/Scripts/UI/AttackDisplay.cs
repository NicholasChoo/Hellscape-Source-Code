using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackDisplay : MonoBehaviour
{
    private float attackCooldown;
    public Text cdText;

    void Update()
    {
        attackCooldown = PlayerAttack.timeBetweenAttack;

        cdText.text = attackCooldown.ToString("F1") + "s";
    }
}
