using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_gift_handler : MonoBehaviour
{
    public string child_type;

    public string received_item_id;
    float timer = 0f;
    public float h_gift_cooldown;

    public bool request_made = false;
    public bool item_received_recently = false;

    [SerializeField] Game_Manager manager;
    [SerializeField] Child_Status c_status;

    public InventoryItemData wanted_item;
    void Start()
    {
        h_gift_cooldown = 15f;
    }

    void Update()
    {
        if (!request_made && !item_received_recently)
        {
            MakeRequest();
        }

        if (item_received_recently)
        {
            timer += Time.deltaTime;
            if (timer > h_gift_cooldown)
            {

                item_received_recently = false;
                MakeRequest();
                timer = 0f;
            }
        }
    }

    #region Custom Functions
    void MakeRequest()
    {
        int randReq = Random.Range(0, manager.AllItems.Count);
        wanted_item = manager.AllItems[randReq];

        if (wanted_item.TypeOfItem != "good")
        {
            while (wanted_item.TypeOfItem != "good")
            {
                randReq = Random.Range(0, manager.AllItems.Count);
                wanted_item = manager.AllItems[randReq];
            }
        }
        request_made = true;
    }

    
    #endregion


}
