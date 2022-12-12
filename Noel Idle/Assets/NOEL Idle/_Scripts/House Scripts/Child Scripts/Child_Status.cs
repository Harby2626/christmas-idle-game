using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_Status : MonoBehaviour
{
    Child_Move c_move;
    [SerializeField] House_gift_handler hg_handler;
    bool na_set;

    float naughtiness;
    public string status;

    void Start()
    {
        c_move = GetComponent<Child_Move>();
    }

    void Update()
    {
        if (!hg_handler.item_received_recently)
        {
            if (!c_move.reached_pos)
            {
                if (!na_set)
                {
                    naughtiness = Random.Range(0f, 1f);
                    if (naughtiness < 0.5f) status = "good";
                    else status = "bad";
                    na_set = true;
                }
            }
        }
        else
        {
            na_set = false;
        }
        
    }
}
