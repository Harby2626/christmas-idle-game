using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Look_Cam : MonoBehaviour
{
    [SerializeField] Transform mainCAM;
    void Start()
    {
        mainCAM = GameObject.Find("Main Camera").transform;
    }

    void LateUpdate()
    {
        transform.LookAt(mainCAM);
    }
}
