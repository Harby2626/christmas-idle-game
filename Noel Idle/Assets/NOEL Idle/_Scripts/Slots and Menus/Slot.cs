using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public Inv_Item attached_item;

    [SerializeField] private Image m_icon;
    [SerializeField] private TextMeshProUGUI m_label;
    [SerializeField] public TextMeshProUGUI m_stack_label;
    [SerializeField] public GameObject m_stack;

    public string GET_id()
    {
        return attached_item.data.id;
    }

    public void SET(Inv_Item item)
    {
        attached_item = item;

        m_icon.sprite = item.data.item_icon;
        m_label.text = item.data.displayNAME;
        if (item.stackSize <= 1)
        {
            m_stack.gameObject.SetActive(false);
            return;
        }
        m_stack_label.text = item.stackSize.ToString();
    }

    public void SET()
    {
        if (attached_item.stackSize > 1)
        {
            m_stack.gameObject.SetActive(true);
        }
        m_stack_label.text = attached_item.stackSize.ToString();
    }
}
