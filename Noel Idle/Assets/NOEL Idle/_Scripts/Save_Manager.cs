using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Manager : MonoBehaviour
{
    [SerializeField] Player_Collider p_col;
    [SerializeField] Inv_System inv_system;

    Dictionary<string, int> Data_saved;

    void Fill_Inventory_To_Save()
    {
        for (int it = 0; it < inv_system.inventory.Count; it++)
        {
            Data_saved.Add(inv_system.inventory[it].data.id, inv_system.inventory[it].stackSize);
        }
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("PlayerLevel", p_col.Level);
        PlayerPrefs.SetFloat("PlayerEXP", p_col.exp);

        Fill_Inventory_To_Save();
        // Save inventory items;
        foreach (KeyValuePair<string, int> kvp in Data_saved)
        {
            PlayerPrefs.SetString(kvp.Key, kvp.Key);
            PlayerPrefs.SetInt("item_id" + kvp.Value, kvp.Value);
        }
    }

    void LoadGame()
    {

    }
}
