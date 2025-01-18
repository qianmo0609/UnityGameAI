using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum StateEnum
{
    None,
    idle,
    walk,
    run,
    jump,
    doublejump,
    movementSubFSM,
    jumpSubFSM
}

public class HierarchicalStateMachine
{
    protected Dictionary<StateEnum,IState> states;

    public HierarchicalStateMachine(IState initState)
    {
        this.initialState = initState;
        this.states = new Dictionary<StateEnum,IState>();
    }

    //初始状态
    protected IState initialState;

    //状态机的当前状态
    protected IState currentState = null;

    public void AddState(StateEnum stateEnum , IState state)
    {
        this.states[stateEnum] = state;
    } 

    public virtual void update()
    {
        //如果当前状态是null，则使用initialSate
        if(currentState == null) {
            currentState = this.initialState;
            currentState.onEntry();
        }

        Transition[] transitions = currentState.getTransitions();
        //在当前状态中查找一个过渡
        Transition transition = null;
        foreach(Transition t in transitions)
        {
            if (t.isTriggered())
            {
                if(transition == null || transition?.getLevel() < t.getLevel())
                {
                    transition = t;
                }
            }
        }
 
        if(transition != null)
        {
            StateEnum se = transition.getTargetState();
            IState targetState = null;
            if(this.states.TryGetValue(se, out targetState))
            {
                currentState.onExit();
                targetState.onEntry();
                //设置当前状态
                currentState = targetState;
            }
            else
            {
                //如果没有找到，那么说明状态在子层
                currentState.update();
            }
        }
        else
        {
            currentState.update();
        }
        transition = null;
    }
}
