using UnityEngine;

[CreateAssetMenu(menuName = "Data/Statemachine/PlyaerState/JumpUp", fileName = "PlayerStateJumpUp")]
public class PlayerStateJumpUP : PlayerState
{
    // Start is called before the first frame update
    [SerializeField]
    public float Jumpforce = 10f,
        speed = 5f,limitJumpSpeed=20f;

    // Start is called before the first frame update

    public override void Enter()
    {
        input.HasJumpInputBuffer = false;
        base.Enter();
        //Player.SetvelocityY(Player.GetComponent<Rigidbody2D>().velocity.y + Jumpforce);
        Player.SetvelocityY( Jumpforce);
        Player.audioManager.StopSFX();
    }
    
    public override void LogicUpdate()
    {
        // if (input.StopJump)
        // {
        //     stateMachine.SwichState(typeof(PlayerStateFall));
        // }
        if (Player.IsFalling)
        {
            stateMachine.SwichState(typeof(PlayerStateFall));
        }
        if (input.Jump&& Player.IsGound)
        {
            stateMachine.SwichState(typeof(PlayerStateJumpUP));
        }

        
        // if (IsAnimationFinished)
        // {
        //     stateMachine.SwichState(typeof(PlayerStateIdle));
        // }
        if (Player.CanClimb && input.OnClimb)
        {
            stateMachine.SwichState(typeof(PlayerStateClimbing));
        }

    }

    public override void PhysicUpdate()
    {
        //Debug.Log(10);
        Player.SpeedLimitY(limitJumpSpeed);
        Player.Move(speed);
    }
}
