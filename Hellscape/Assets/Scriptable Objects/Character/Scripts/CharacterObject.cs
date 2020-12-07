using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "New Character", menuName = "Inventory System/Character")]
public class CharacterObject : ScriptableObject, ISerializationCallbackReceiver
{
    public InventoryObject inventory;

    public string savePath;
    private ItemDatabaseObject database;
    public List<CharacterSlot> Container = new List<CharacterSlot>();

    public bool helmetEquipped = false;
    public bool armourEquipped = false;
    public bool swordEquipped = false;

    private void OnEnable()
    {
#if UNITY_EDITOR
        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject));
#else
        database = Resources.Load<ItemDatabaseObject>("Database");
#endif
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }

    public void EquipHelmet(ItemObject __item, int __amount)
    {
        if (helmetEquipped == false)
        {
            Container.Add(new CharacterSlot(database.GetId[__item], __item, __amount));
            helmetEquipped = true;
        }
    }

    public void EquipArmour(ItemObject __item, int __amount)
    {
        if (armourEquipped == false)
        {
            Container.Add(new CharacterSlot(database.GetId[__item], __item, __amount));
            armourEquipped = true;
        }
    }

    public void EquipSword(ItemObject __item, int __amount)
    {
        if (swordEquipped == false)
        {
            Container.Add(new CharacterSlot(database.GetId[__item], __item, __amount));
            swordEquipped = true;
        }
    }

    public void Unequip(string __type)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item.type.ToString() == __type)
            {
                inventory.AddItem(Container[i].item, 1);
                Container.RemoveAt(i);
                break;
            }
        }
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Count; i++)
            Container[i].item = database.GetItem[Container[i].ID];
    }

    public void OnBeforeSerialize()
    {

    }

    public void FalsifyHelmet()
    {
        helmetEquipped = false;
    }

    public void FalsifyArmour()
    {
        armourEquipped = false;
    }

    public void FalsifySword()
    {
        swordEquipped = false;
    }
}

[System.Serializable]
public class CharacterSlot
{
    public int ID;
    public ItemObject item;
    public int amount;
    public CharacterSlot(int _id, ItemObject _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }

    public void RemoveAmount(int value)
    {
        amount -= value;
    }
}