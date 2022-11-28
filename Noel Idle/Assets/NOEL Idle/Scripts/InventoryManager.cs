using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    List<Inv_Item> drawedSlots = new List<Inv_Item>();
    bool empty_drawed_list = true;

    [SerializeField] Inv_System inv_sys;
    [SerializeField] GameObject m_slot_prefab;
    public void Start()
    {

    }

    public void DrawInventory()
    {
        foreach (Inv_Item item in inv_sys.inventory)
        {
            if (empty_drawed_list)
            {
                AddInventorySlot(item);
                drawedSlots.Add(item);
                empty_drawed_list = false;
            }
            else// boþ deðilse
            {
                if (!drawedSlots.Contains(item))
                {
                    AddInventorySlot(item);
                    drawedSlots.Add(item);
                }
                else
                {
                    if (item.stackSize < 4)
                    {
                        item.stackSize++;
                    }
                }
            }
            
        }
    }

    public void UpdateInv()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Slot>().SET();
        }
    }

    private void AddInventorySlot(Inv_Item item)
    {
        GameObject obj = Instantiate(m_slot_prefab);
        obj.transform.SetParent(transform, false);

        Slot slot = obj.GetComponent<Slot>();
        slot.SET(item);
    }
}
