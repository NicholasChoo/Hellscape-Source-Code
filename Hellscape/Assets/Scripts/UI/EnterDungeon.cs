using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDungeon : MonoBehaviour
{
    private bool npcDialogue = false;

    public GameObject dialogueUI;

    public GameObject player;

    void Update()
    {
        npcDialogue = NonPlayerCharacter.npcDialogue;

        if (npcDialogue)
        {
            dialogueUI.SetActive(true);
        }
        else
        {
            dialogueUI.SetActive(false);
        }
    }

    public void CloseDialogue()
    {
        player.transform.position = new Vector3(0, 4, -1.2f);
    }
}
