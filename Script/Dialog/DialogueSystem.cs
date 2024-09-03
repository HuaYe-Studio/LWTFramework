using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Dialogue dialogue;

    [SerializeField] private GameObject dialogBox;

    [SerializeField] private TextMeshProUGUI dialog;

    [SerializeField] private TextMeshProUGUI characterName;

    [SerializeField] private CharacterType type;

    [SerializeField] private PlayerInput input;
    private int index;

    private bool isInTurn=false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInTurn)
        {
            Play();
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    
        isInTurn = true;
    }

    private void OnTriggerExit2D(Collider2D other) => isInTurn = false;

    void Play()
    {
        input.inputActions.Player.Disable();
        dialogBox.SetActive(true);
        Debug.Log(index);
        DialogNode node = dialogue.dialogNodes[Mathf.Clamp(index++, 0, dialogue.dialogNodes.Length - 1)];
        dialog.text = node.dialog;
        characterName.text = node.characterName;
        if (index - 1 == dialogue.dialogNodes.Length)
        {
            
            index = 0;
            dialogBox.SetActive(false);
            input.inputActions.Player.Enable();
        }
            
        
    }
}
