using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniBossValidate : MonoBehaviour
{
    public GameObject miniBoss1;
    public GameObject miniBoss2;

    public bool enterBossRoom = false;

    void Update()
    {
        if (miniBoss1 == null && miniBoss2 == null)
        {
            if (enterBossRoom == true)
            {
                SceneManager.LoadScene("1stFloorBossRoom");
            }
        }
    }

    void OnTriggerEnter2D()
    {
        enterBossRoom = true;
    }

    void OnTriggerExit2D()
    {
        enterBossRoom = false;
    }
}
