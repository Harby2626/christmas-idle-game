using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_Move : MonoBehaviour
{
    public Quaternion door_ROT, door_O_ROT;
    public bool reached_pos = true;
    float move_speed, door_turn_speed;
    Animator child_animator;
    [SerializeField] CapsuleCollider collider;

    [SerializeField] Transform h_inside;
    [SerializeField] Transform wait_point;

    [SerializeField] House_gift_handler hg_handler;
    void Start()
    {
        Physics.IgnoreCollision(collider, GameObject.FindGameObjectWithTag("LR_border").GetComponent<BoxCollider>());
        Physics.IgnoreCollision(collider, GameObject.FindGameObjectWithTag("LR_border1").GetComponent<BoxCollider>());

        child_animator = GetComponent<Animator>();
        move_speed = 1f;
        door_turn_speed = 2f;
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }

    void Update()
    {
        if (hg_handler.item_received_recently)// item al�nm��sa
        {
            
            ChildMove(h_inside);
        }
        else if (!hg_handler.item_received_recently)// item alma cooldown'� bittiyse
        {
            ChildMove(wait_point);
        }
    }

    void ChildMove(Transform dest)
    {
        if ((transform.position - dest.position).magnitude > 0.1f)
        {
            reached_pos = false;
            if (hg_handler.wanted_item.id == hg_handler.received_item_id)
            {
                child_animator.SetBool("isHappy", true);
                child_animator.SetBool("isSad", false);
            }
            else
            {
                child_animator.SetBool("isSad", true);
                child_animator.SetBool("isHappy", false);
            }
            child_animator.SetBool("Happy_idle", false);
        }
        else
        {
            reached_pos = true;
            child_animator.SetBool("Happy_idle", true);
            child_animator.SetBool("isSad", false);
            child_animator.SetBool("isHappy", false);
        }
        
        transform.position = Vector3.MoveTowards(transform.position, dest.position, move_speed * Time.deltaTime);
        
        Vector3 targetDIR = dest.position - transform.position;
        Vector3 newDIR = Vector3.RotateTowards(transform.forward, targetDIR, move_speed * 4 * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDIR);
    }
}
