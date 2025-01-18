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

    //��״̬�������¼�
    public virtual void onEntry()
    {

    }

    //��״̬���˳��¼�
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
