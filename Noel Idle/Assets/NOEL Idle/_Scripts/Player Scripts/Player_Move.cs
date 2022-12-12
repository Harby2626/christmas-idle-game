using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [SerializeField] Transform MainCAM;// For Cam Follow
    [SerializeField] ParticleSystem walk_particle;

    public Vector3 offset;

    public float maxMoveSpeed;
    float moveSpeed, inputX, inputZ;
    Vector3 MoveVEC;
    Vector2 IN_touchPOS, MOV_touchPOS, res_VEC;

    Rigidbody rgb;
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }

    private void LateUpdate()// FOR CAM FOLLOW
    {
        Vector3 desiredPOS = transform.position - offset;
        MainCAM.position = desiredPOS;
    }

    void Update()
    {
        MoveVEC = new Vector3(inputX, 0, inputZ);
        MovePlayer(MoveVEC * moveSpeed * Time.deltaTime);
        if (MoveVEC != Vector3.zero)
        {
            transform.forward = MoveVEC;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (res_VEC != Vector2.zero)
            {
                //animator
                walk_particle.Pause(false);
                walk_particle.Play(true);

            }
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    IN_touchPOS = touch.position;
                    break;

                case TouchPhase.Moved:
                    moveSpeed = maxMoveSpeed;
                    MOV_touchPOS = touch.position;
                    res_VEC = (MOV_touchPOS - IN_touchPOS).normalized;
                    inputX = res_VEC.x; inputZ = res_VEC.y;
                    break;

                default:
                    break;
            }
        }
        else
        {
            // animator false
            walk_particle.Stop(true);

            moveSpeed = 0f;
            rgb.velocity = Vector3.zero;
        }
    }

    void MovePlayer(Vector3 MV)
    {
        rgb.velocity = MV;
    }
}
