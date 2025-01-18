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

    //��ʼ״̬
    protected IState initialState;

    //״̬���ĵ�ǰ״̬
    protected IState currentState = null;

    public void AddState(StateEnum stateEnum , IState state)
    {
        this.states[stateEnum] = state;
    } 

    public virtual void update()
    {
        //�����ǰ״̬��null����ʹ��initialSate
        if(currentState == null) {
            currentState = this.initialState;
            currentState.onEntry();
        }

        Transition[] transitions = currentState.getTransitions();
        //�ڵ�ǰ״̬�в���һ������
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
                //���õ�ǰ״̬
                currentState = targetState;
            }
            else
            {
                //���û���ҵ�����ô˵��״̬���Ӳ�
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
