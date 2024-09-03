using System;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    // Start is called before the first frame update
    //这是玩家状态的抽象类

    [SerializeField] private string stateName;

    private int hashStateName;
    protected float currentSpeedX;
    protected float currentSpeedY;
    protected bool IsAnimationFinished =>
        stateTime >= animator.GetCurrentAnimatorStateInfo(0).length;
    protected float stateTime => Time.time - stateStartTime;
    private float stateStartTime;
    protected Animator animator;
    protected PlayerInput input;
    protected PlayerStateMachine stateMachine;
    protected PlayerController Player;

    private void OnEnable()
    {
        hashStateName = Animator.StringToHash(stateName);
    }

    public void Initialize(
        Animator animator,
        PlayerStateMachine stateMachine,
        PlayerInput input,
        PlayerController Player
    )
    {
        this.animator = animator;
        this.stateMachine = stateMachine;
        this.input = input;
        this.Player = Player;
    }

    // Update is called once per frame


    public virtual void Enter()
    {
        Debug.Log($"Enter State:{GetType().Name}");
        animator.Play(hashStateName);
        stateStartTime = Time.time;
    }

    public virtual void Exit() { }

    public virtual void LogicUpdate()
    {
        //Debug.Log(111);
    }

    public virtual void PhysicUpdate() { }
}
