using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    //在这个脚本里面获取玩家的输入
    private Vector2 axes => inputActions.Player.Axes.ReadValue<Vector2>();

    public bool HasJumpInputBuffer { get; set; }
    public bool OnClimb => inputActions.Player.Climb.WasPerformedThisFrame();
    public bool UseKey => inputActions.Player.Use.WasPerformedThisFrame();

    public bool Jump => inputActions.Player.Jump.WasPerformedThisFrame();

    public bool StopJump => inputActions.Player.Jump.WasReleasedThisFrame();
    public Vector2 MousePosition => inputActions.Player.MousePosition.ReadValue<Vector2>();

    public float AxisX => axes.x;
    public float AxisY => axes.y;
    public bool Move => AxisX != 0f;

    private WaitForSeconds waitJumpBuffer;
    
    [SerializeField]
     float jumpInputBufferTime = 0.5f;
    
    public InputActions inputActions;

    private void Awake ( )
    {

        waitJumpBuffer = new WaitForSeconds(jumpInputBufferTime);
        inputActions = new InputActions();
        
    }

    // Update is called once per frame
    public void EnableGamePlayInputs ( )
    {
        inputActions.Player.Enable();
        // Cursor.lockState = CursorLockMode.Locked;
    }

    public void DisAblenTalent()
    {
       
    }

    


    public void SetJumpBufferTimer()
    {
        StopCoroutine(nameof(JumpInputBuffercoroutine));
        StartCoroutine(nameof(JumpInputBuffercoroutine));
    }
    IEnumerator JumpInputBuffercoroutine()
    {
        HasJumpInputBuffer = true;
        yield return waitJumpBuffer;
        HasJumpInputBuffer = false;
    }
}
