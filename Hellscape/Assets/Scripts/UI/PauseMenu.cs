using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public static bool CharacterOpen = false;
    public static bool InventoryOpen = false;

    public GameObject pauseMenuUI;
    public GameObject characterUI;
    public GameObject inventoryUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            LoadChar();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            LoadInventory();
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void LoadChar()
    {
        if (IsPaused)
        {
            Resume();
        }

        if (CharacterOpen)
        {
            characterUI.SetActive(false);
            CharacterOpen = false;
        }
        else
        {
            characterUI.SetActive(true);
            CharacterOpen = true;
        }
    }

    public void LoadInventory()
    {
        if (IsPaused)
        {
            Resume();
        }

        if (InventoryOpen)
        {
            inventoryUI.SetActive(false);
            InventoryOpen = false;
        }
        else
        {
            inventoryUI.SetActive(true);
            InventoryOpen = true;
        }
    }

    public void ExitGame()
    {
        Debug.Log("exitting game");
        Application.Quit();
    }
}
