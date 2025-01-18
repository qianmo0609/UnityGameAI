using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void onEntry();
    void update();
    void onExit();
    Transition[] getTransitions();
    void AddTransition(Transition transition);
}

public class IdleState : IState
{
    public IdleState()
    {
        transitions = new List<Transition>(); 
    }
    List<Transition> transitions;

    public Transition[] getTransitions()
    {
       return transitions.ToArray();
    }

    public void onEntry()
    {
        Debug.Log("½øÈë¿ÕÏĞ×´Ì¬");
    }

    public void onExit()
    {
        Debug.Log("ÍË³ö¿ÕÏĞ×´Ì¬");
    }

    public void update()
    {
        Debug.Log("¿ÕÏĞ×´Ì¬¡£¡£¡£");
    }

    public void AddTransition(Transition transition)
    {
        this.transitions.Add(transition);
    }

    public IState getState(StateEnum se)
    {
        return null;
    }
}

public class WalkState : IState
{
    public WalkState()
    {
        transitions = new List<Transition>();
    }
    List<Transition> transitions;

    public Transition[] getTransitions()
    {
        return this.transitions.ToArray();
    }

    public void onEntry()
    {
        Debug.Log("½øÈë×ß×´Ì¬");
    }

    public void onExit()
    {
        Debug.Log("ÍË³ö×ß×´Ì¬");
    }

    public void update()
    {
        Debug.Log("×ß×´Ì¬¡£¡£¡£");
    }

    public void AddTransition(Transition transition)
    {
        this.transitions.Add(transition);
    }

    public IState getState(StateEnum se)
    {
        return null;
    }
}

public class RunState : IState
{
    public RunState()
    {
        transitions = new List<Transition>();
    }
    List<Transition> transitions;

    public void AddTransition(Transition transition)
    {
        this.transitions.Add(transition);
    }

    public Transition[] getTransitions()
    {
        return this.transitions.ToArray ();
    }

    public void onEntry()
    {
        Debug.Log("½øÈëÅÜ×´Ì¬");
    }

    public void onExit()
    {
        Debug.Log("ÍË³öÅÜ×´Ì¬");
    }

    public void update()
    {
        Debug.Log("ÅÜ×´Ì¬¡£¡£¡£");
    }

    public IState getState(StateEnum se)
    {
        return null;
    }
}

public class JumpState : IState
{
    public JumpState()
    {
        transitions = new List<Transition>();
    }
    List<Transition> transitions;

    public void AddTransition(Transition transition)
    {
        this.transitions.Add (transition);
    }

    public Transition[] getTransitions()
    {
        return this.transitions.ToArray ();
    }

    public void onEntry()
    {
        Debug.Log("½øÈëÌø×´Ì¬");
    }

    public void onExit()
    {
        Debug.Log("ÍË³öÌø×´Ì¬");
    }

    public void update()
    {
        Debug.Log("Ìø×´Ì¬¡£¡£¡£");
    }

    public IState getState(StateEnum se)
    {
        return null;
    }
}

public class DoubleJumpState : IState
{
    public DoubleJumpState()
    {
        transitions = new List<Transition>();
    }
    List<Transition> transitions;

    public void AddTransition(Transition transition)
    {
        this.transitions.Add(transition);
    }

    public Transition[] getTransitions()
    {
        return this.transitions.ToArray();
    }

    public void onEntry()
    {
        Debug.Log("½øÈë¶ş¶ÎÌø×´Ì¬");
    }

    public void onExit()
    {
        Debug.Log("ÍË³ö¶ş¶ÎÌø");
    }

    public void update()
    {
        Debug.Log("¶ş¶ÎÌø¡£¡£¡£");
    }

    public IState getState(StateEnum se)
    {
        return null;
    }
}