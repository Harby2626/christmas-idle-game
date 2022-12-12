using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inv_Item
{
    Game_Manager manager = MonoBehaviour.FindObjectOfType<Game_Manager>();

    public InventoryItemData data { get; private set; }
    public int stackSize;
    //public int StackLimit = 4;

    public Inv_Item(InventoryItemData source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
        if (stackSize >= manager.stack_limit)
        {
            stackSize = manager.stack_limit;
        }
        
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }
}
