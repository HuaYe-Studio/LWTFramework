using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    
    [SerializeField] PlayerState[] states;
    Animator animator;
    PlayerInput input;
    // Start is called before the first frame update
    private PlayerController player;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        input = GetComponent<PlayerInput>();
        player = GetComponent<PlayerController>();
        statetable = new Dictionary<System.Type, IState>(states.Length);
        //后面初始化玩家状态
        foreach (PlayerState state in states)
        {
            state.Initialize(animator,this,input,player);
            statetable.Add(state.GetType(),state);
        }
    }
    void Start()
    {
        SwitchOn(statetable[typeof(PlayerStateIdle)]);
        //一开始从idle状态开始，其余状态切换在玩家状态的脚本里面进行
        // SwichState(runState);
    }

    // Update is called once per frame
    
}