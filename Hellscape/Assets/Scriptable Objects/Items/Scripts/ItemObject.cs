using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Helmet,
    Armour,
    Sword
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public Sprite spriteIcon;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
    public float health;
    public float attack;
    public float attackSpeed;
}
