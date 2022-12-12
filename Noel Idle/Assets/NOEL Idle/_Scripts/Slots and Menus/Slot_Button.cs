using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot_Button : MonoBehaviour
{
    Child_Status c_status;
    Player_Collider p_col;
    Inv_System inventory;

    Button this_button;
    Slot this_slot;
    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inv_System>();
        p_col = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Collider>();

        this_slot = transform.parent.GetComponent<Slot>();
        this_button = GetComponent<Button>();
        this_button.onClick.AddListener(SlotButtonClick);
    }

    private void Update()
    {
        if (this_slot.attached_item.stackSize == 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void SlotButtonClick()
    {
        if (!p_col.hg_handler.item_received_recently)
        {
            inventory.Remove(this_slot.attached_item.data);
            this_slot.SET(this_slot.attached_item);
            p_col.hg_handler.received_item_id = this_slot.attached_item.data.id;

            if (this_slot.attached_item.data.TypeOfItem == "good")// item türü good
            {
                if (this_slot.attached_item.data.id == p_col.hg_handler.wanted_item.id)// good - good
                {
                    if (p_col.c_status.status == "good")// Verilen good - status good
                    {
                        Debug.Log("BAÞARILI");
                        p_col.exp += .20f;
                        p_col.hg_handler.item_received_recently = true;
                        p_col.hg_handler.request_made = false;
                    }
                    else// Verilen good - status bad
                    {
                        Debug.Log("Yaramaz Çocuk");
                        p_col.exp -= .10f;
                        p_col.hg_handler.item_received_recently = true;
                        p_col.hg_handler.request_made = false;
                    }
                    
                }
                else
                {
                    Debug.Log("AYNI URUN DEÐÝL");
                    p_col.exp += .1f;
                    p_col.hg_handler.item_received_recently = true;
                    p_col.hg_handler.request_made = false;
                }
            }

            else if (this_slot.attached_item.data.TypeOfItem == "neutral")// item türü neutral
            {
                if (p_col.hg_handler.wanted_item.TypeOfItem == "good")// neutral - good
                {
                    Debug.Log("Istenen good, verilen neutral");
                    p_col.exp += .1f;
                    p_col.hg_handler.item_received_recently = true;
                    p_col.hg_handler.request_made = false;
                }
            }

            else if (this_slot.attached_item.data.TypeOfItem == "bad")// item türü bad
            {
                if (p_col.c_status.status == "good")// Verilen bad - status iyi
                {
                    Debug.Log("Yanlýþ iyiye kötü");
                    p_col.exp -= .20f;
                    p_col.hg_handler.item_received_recently = true;
                    p_col.hg_handler.request_made = false;
                }
                else// Verilen bad - status bad
                {
                    Debug.Log("Baþarýlý kötüye kötü");
                    p_col.exp += .20f;
                    p_col.hg_handler.item_received_recently = true;
                    p_col.hg_handler.request_made = false;
                }
            }
        }
        
    }
}
