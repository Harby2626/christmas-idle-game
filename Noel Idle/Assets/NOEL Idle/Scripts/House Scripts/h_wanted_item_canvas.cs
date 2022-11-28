using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class h_wanted_item_canvas : MonoBehaviour
{
    [SerializeField] House_gift_handler hg_handler;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ChangeWantedSprite();
    }

    void ChangeWantedSprite()
    {
        if (hg_handler.request_made)
        {
            Color tempC;
            tempC = transform.GetComponent<Image>().color;
            tempC.a = 1;
            transform.GetComponent<Image>().color = tempC;

            anim.SetBool("wanted_slow", true);
            this.transform.GetComponent<Image>().sprite = hg_handler.wanted_item.item_icon;
        }
        else
        {
            Color tempC;
            tempC = transform.GetComponent<Image>().color;
            tempC.a = 0;
            transform.GetComponent<Image>().color = tempC;

            anim.SetBool("wanted_slow", false);
        }
    }
}
