using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossValidate : MonoBehaviour
{
    public GameObject boss;
    public GameObject returnPoint;

    void Update()
    {
        if (boss == null)
        {
            returnPoint.SetActive(true);
        }
    }
}
