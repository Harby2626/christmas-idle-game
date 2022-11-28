using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Collider : MonoBehaviour
{
    [Range(0, 1)]
    public float exp;
    public float Level;

    public GameObject curr_house;
    public House_gift_handler hg_handler;
    public Child_Status c_status;

    [Header("Booleans")]
    public bool GiftMenuOpen;
    public bool leveled_up;
    public bool chose_upgrade;

    [Header("Attachables")]
    [SerializeField] Player_Move p_move;
    [SerializeField] Button inv_button;
    [SerializeField] Button inv_refresh_button;
    [SerializeField] Image inv_img;
    [SerializeField] Image Claus_img;
    [SerializeField] Image Level_fill_img;
    [SerializeField] GameObject upg_container;
    private void Start()
    {
        Level = 1;
        exp = 0f;
    }

    private void Update()
    {
        Level_fill_img.fillAmount = Mathf.Lerp(Level_fill_img.fillAmount, exp, 2.5f * Time.deltaTime);
        if (Level_fill_img.fillAmount >= .99f)
        {
            leveled_up = true;
            chose_upgrade = false;
            Level++;
            exp = 0;
        }
        if (leveled_up && !chose_upgrade)
        {
            upg_container.SetActive(true);
        }
    }

    #region OnTrigger Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "h_menu_area")
        {
            curr_house = other.transform.parent.parent.gameObject;
            hg_handler = curr_house.transform.GetChild(1).GetComponent<House_gift_handler>();
            c_status = other.transform.parent.parent.parent.GetChild(1).GetComponent<Child_Status>();
            if (!GiftMenuOpen)
            {
                inv_button.gameObject.SetActive(true);
                inv_button.GetComponent<Animator>().SetBool("h_entry", true);
            }
        }

        else if (other.gameObject.tag == "gather_area")
        {
            inv_refresh_button.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "h_menu_area")
        {
            curr_house = null;
            hg_handler = null;
            c_status = null;
            inv_button.gameObject.SetActive(false);
            inv_button.GetComponent<Animator>().SetBool("h_entry", false);
            inv_button.transform.Rotate(0, 0, 0);
        }

        else if (other.gameObject.tag == "gather_area")
        {
            inv_refresh_button.gameObject.SetActive(false);
        }
    }
    #endregion

}
