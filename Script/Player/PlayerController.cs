using System.Collections;
using Assets.Script.Player.Skills;
using Assets.Script.State_Machine_System.Player_States;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput input;
    internal Rigidbody2D rigidBody;
    public GroundDetect groundDetect;
    public bool CanClimb = false;
    public bool IsGound => groundDetect.onGorund;
    public bool IsFalling => rigidBody.velocity.y <= 0f;

    public float ladderPosition = 0f;
    public bool OnHurt = false;

    public AudioManager audioManager;
    //public AudioClass audioClass;
    private Animator animator;
    public float moveSpeedX => rigidBody.velocity.x;
    public float moveSpeedY => rigidBody.velocity.y;

    internal Vector2? nearbyHookablePoint = null;


    private void Awake()
    {
        animator = GetComponent<Animator>();

        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    [SerializeField] internal PlayerStateMachine stateMachine;

    private void Start()
    {
        input.EnableGamePlayInputs();
        input.DisAblenTalent();
    }

    public void SetVelocity(Vector2 vector2)
    {
        rigidBody.velocity = vector2;
    }

    public void Move(float speed)
    {
        if (input.Move)
        {
            transform.localScale = new Vector2(input.AxisX, 1f);
        }

        //Debug.Log(input.AxisX);
        SetvelocityX(speed * input.AxisX);
    }

    public void PlayerSprint(float speed)
    {
        //Debug.Log(sprint.sprintEnergy);
        Vector2 direction = new Vector2(input.AxisX, input.AxisY).normalized;
        if (input.AxisY == 0 && input.AxisX == 0)
        {
            direction = new Vector2(transform.localScale.x, input.AxisY).normalized;
        }

        SetVelocity(direction * speed);
        // rigidBody.AddForce(direction * speed);


    }

    public void SetvelocityX(float velocityX)
    {
        //Debug.Log(velocityX);
        rigidBody.velocity = new Vector2(velocityX, rigidBody.velocity.y);
    }

    public void SetvelocityY(float velocityY)
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, velocityY);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    public void SetGravity(float gravity)
    {
        rigidBody.gravityScale = gravity;
    }
    

    public void Climb(float climbSpeed)
    {
        SetvelocityY(climbSpeed * input.AxisY);
    }

    public void GetOnLadder()
    {
        if (ladderPosition != 0)
        {
            transform.DOMove(new Vector2(ladderPosition, transform.position.y), 0.2f);
            //transform.position = new Vector2(ladderPosition, transform.position.y);
        }

    }

    
    public IEnumerator OnHurtTrigger()
    {
        // ReduceHP(1);
        yield return null;
        OnHurt = false;
    }

    public void SpeedLimitY(float limit)
    {
        if (rigidBody.velocity.y > limit)
        {
            SetvelocityY(limit);
        }
    }

}