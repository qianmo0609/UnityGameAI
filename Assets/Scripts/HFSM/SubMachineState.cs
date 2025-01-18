using System;
using System.Collections.Generic;
using System.Diagnostics;

public class SubMachineState : HierarchicalStateMachine, IState
{
    public SubMachineState(IState initState) : base(initState)
    {
        this.initialState = initState;
        transitions = new List<Transition>();
    }

    List<Transition> transitions;

    //子状态机进入事件
    public virtual void onEntry()
    {

    }

    //子状态机退出事件
    public virtual void onExit()
    {
       
    }

    public void AddTransition(Transition transition)
    {
        transitions.Add(transition);
    }

    public Transition[] getTransitions()
    {
        return this.transitions.ToArray();
    }
}

public class MovementMachineState : SubMachineState
{
    public MovementMachineState(IState initState) : base(initState)
    {
    }

    public override void onEntry()
    {
        base.onEntry();
    }

    public override void onExit()
    {
        base.onExit();
        currentState?.onExit();
    }

    public override void update()
    {
        base.update();
    }
}

public class JumpMachineState : SubMachineState
{
    public JumpMachineState(IState initState) : base(initState)
    {
    }

    public override void onEntry()
    {
        base.onEntry();
    }

    public override void onExit()
    {
        base.onExit();
        currentState?.onExit();
        currentState = null;
    }

    public override void update()
    {
        base.update();
    }
}
