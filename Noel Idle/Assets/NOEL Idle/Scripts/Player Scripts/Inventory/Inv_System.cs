using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inv_System : MonoBehaviour
{
    public Dictionary<InventoryItemData, Inv_Item> m_itemDictionary;
    public List<Inv_Item> inventory { get; private set; }
    void Awake()
    {
        inventory = new List<Inv_Item>();
        m_itemDictionary = new Dictionary<InventoryItemData, Inv_Item>();
    }

    public Inv_Item Get(InventoryItemData refData)
    {
        if (m_itemDictionary.TryGetValue(refData, out Inv_Item value))
            return value;
        else
            return null;
    }

    public void Add(InventoryItemData refData)
    {
        if (m_itemDictionary.TryGetValue(refData, out Inv_Item value))
        {
            value.AddToStack();
        }
        else
        {
            Inv_Item newItem = new Inv_Item(refData);
            inventory.Add(newItem);
            m_itemDictionary.Add(refData, newItem);
        }
    }

    public void Remove(InventoryItemData refData)
    {
        if (m_itemDictionary.TryGetValue(refData, out Inv_Item value))
        {
            value.RemoveFromStack();
            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(refData);
            }
        }
    }
}
