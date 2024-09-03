using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState currentState;

    public Type CurrentStateType => currentState.GetType();

    //这里是状态机的基本操作
    protected Dictionary<System.Type, IState> statetable;

    protected void Update ( )
    {
        currentState.LogicUpdate(); //逻辑更新
    }

    private void FixedUpdate ( )
    {
        // Debug.Log(121212);

        currentState.PhysicUpdate(); //物理更新
    }

    //进入某个状态
    protected void SwitchOn (IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    //切换到某个状态
    public void SwitchState (IState newState)
    {
        currentState.Exit();
        SwitchOn(newState);
    }

    public void SwichState (System.Type newStateType)
    {
        if ( CurrentStateType != newStateType )
        {
            SwitchState(statetable[newStateType]);
        }
    }
}
