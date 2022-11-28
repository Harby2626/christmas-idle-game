using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] Inv_Item inv_item;
    public List<InventoryItemData> AllItems;


    bool Inv_drawed = false;
    public int stack_limit;


    #region Serialized Objects
    [Header("-------------- Attachables --------------")]
    [SerializeField] Inv_System inv_system;
    [SerializeField] InventoryManager inv_manager;
    [SerializeField] Player_Collider p_col;
    [SerializeField] Player_Move p_move;
    [SerializeField] Image GiftMenuImg;
    [SerializeField] Image Inv;
    [SerializeField] Image ClausImg;
    [SerializeField] Button InvButton;
    [SerializeField] Button InvCloseButton;
    [SerializeField] Button InvRefreshButton;

    [SerializeField] Image na_status_img;
    [SerializeField] TextMeshProUGUI status_text;
    #endregion

    IEnumerator Fill_Image()
    {
        for (float f_amount = 0; f_amount <= 1; f_amount += .01f)
        {
            ClausImg.fillAmount = f_amount;
            if (ClausImg.fillAmount > .95f)
            {
                int randItem_A = Random.Range(0, 5);// hangi itemlerin randomu
                int rand_amount = Random.Range(1, 3);// kaç tane randomu
                for (int i = 0; i < rand_amount; i++)
                {
                    inv_system.Add(AllItems[randItem_A]);
                }
            }
            yield return null;
        }
    }

    #region Variables
    public List<Button> Inv_Items;
    #endregion


    void Start()
    {
        stack_limit = 3;
    }

    #region Custom Button Functions
    public void OpenGiftMenu()
    {

        // Update and display Inventory and stop player
        if (!Inv_drawed)
        {
            inv_manager.UpdateInv();
            inv_manager.DrawInventory();
            Inv_drawed = true;
        }
        p_col.GiftMenuOpen = true;

        na_status_img.gameObject.SetActive(true); status_text.gameObject.SetActive(true);
        na_status_img.color = (p_col.c_status.status == "good") ? Color.green : Color.red;
        status_text.text = (p_col.c_status.status == "good") ? "Good Kid" : "Naughty Kid";

        InvButton.gameObject.SetActive(false);
        GiftMenuImg.gameObject.SetActive(true);
        Inv.gameObject.SetActive(true);
        p_move.GetComponent<Player_Move>().enabled = false;
    }

    public void CloseGiftMenu()
    {
        inv_manager.UpdateInv();
        na_status_img.gameObject.SetActive(false); status_text.gameObject.SetActive(false);
        p_col.GiftMenuOpen = false;
        GiftMenuImg.gameObject.SetActive(false);
        Inv.gameObject.SetActive(false);
        p_move.GetComponent<Player_Move>().enabled = true;
    }

    public void StartGettingGifts()
    {
        InvRefreshButton.gameObject.SetActive(false);
        Inv_drawed = false;
        StartCoroutine(Fill_Image());
    }

    public void GiveGiftToHouse()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name);
    }

    #endregion

    #region Custom Functions

    #endregion
}
