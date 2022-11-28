using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades
{
    [SerializeField] Sprite Speed_sprite;
    [SerializeField] Sprite Capacity_sprite;
    [SerializeField] Sprite Coin_sprite;
    public enum ItemType
    {
        Speed_Upg,
        Capacity_Upg,
        Coin_Upg
    }

    public static int GetCost(ItemType item_type)
    {
        switch (item_type)
        {
            case ItemType.Speed_Upg: return 100;
            case ItemType.Capacity_Upg: return 200;
            case ItemType.Coin_Upg: return 500;
            default: return 0;
        }
    }



    public static Sprite GetSprite(ItemType item_type)
    {
        switch (item_type)
        {
            case ItemType.Speed_Upg: return GameAssets.instance._speed_upg_sprite;
            case ItemType.Capacity_Upg: return GameAssets.instance._cap_upg_sprite;
            case ItemType.Coin_Upg: return GameAssets.instance._coin_upg_sprite;
            default: return null;
        }
    }
}
