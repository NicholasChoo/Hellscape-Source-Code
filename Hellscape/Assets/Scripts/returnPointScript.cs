﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnPointScript : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
