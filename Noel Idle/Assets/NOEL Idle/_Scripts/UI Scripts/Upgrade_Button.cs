using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrade_Button : MonoBehaviour
{
    float dropper = .7f;
    Game_Manager manager;
    Inv_Item inv_item;
    Button this_button;

    Player_Collider p_col;
    Player_Move p_move;
    Upgrade_Info up_info;

    void Start()
    {
        p_col = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Collider>();
        p_move = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Move>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game_Manager>();

        this_button = GetComponent<Button>();
        up_info = GetComponent<Upgrade_Info>();
        this_button.onClick.AddListener(UpgradeButtonClick);
    }

    void Update()
    {
        
    }

    void UpgradeButtonClick()
    {
        if (!p_col.chose_upgrade)
        {
            if (up_info.upgrade_type == "speed")
            {
                p_move.maxMoveSpeed += 100 ;
                p_col.chose_upgrade = true;
                transform.parent.parent.gameObject.SetActive(false);
            }
            else if (up_info.upgrade_type == "cap")
            {
                manager.stack_limit = manager.stack_limit + (int)up_info.multiplier;
                //inv_item.StackLimit += (int)up_info.multiplier;
                p_col.chose_upgrade = true;
                transform.parent.parent.gameObject.SetActive(false);
            }
            else if (up_info.upgrade_type == "coin")
            {
                Debug.Log("COIN COIN");
                p_col.chose_upgrade = true;
                transform.parent.parent.gameObject.SetActive(false);
            }
        }
    }
}
