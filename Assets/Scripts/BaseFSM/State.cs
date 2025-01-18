using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class State
{
    protected StateMachine m_machine;

    public State(StateMachine stateMachine)
    {
        this.m_machine = stateMachine;
    }

    public abstract void Enter();
    public abstract void Tick(float deltaTime);
    public abstract void Exit();
}

public class Idle : State
{
    Player player;
    public Idle(Player player,StateMachine stateMachine) :base(stateMachine){
        this.player = player;
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
       
    }

    public override void Tick(float deltaTime)
    {
        if(player.m_hungryValue < 40)
        {
            this.m_machine.SwitchState(new Hungry(this.player,this.m_machine));
        }
    }
}

public class Hungry : State
{
    private float timer = 0;
    private Player m_player;

    public Hungry(Player player,StateMachine stateMachine) : base(stateMachine) {
        this.m_player = player; 
    }

    public override void Enter()
    {
        Debug.Log("我饿了");
    }

    public override void Exit()
    {
        Debug.Log("找到食物了");
    }

    public override void Tick(float deltaTime)
    {
        this.timer += deltaTime;
        if(this.timer > 4)
        {
            this.m_machine.SwitchState(new Eat(this.m_player, this.m_machine));
            this.timer = 0;
        }
    }
}

public class Eat : State
{
    private float timer = 0;
    private Player m_player;

    public Eat(Player player,StateMachine stateMachine) : base(stateMachine) { 
          this.m_player = player;
    }

    public override void Enter()
    {
        Debug.Log("吃饭了");
    }

    public override void Exit()
    {
        Debug.Log("吃饱了");
    }

    public override void Tick(float deltaTime)
    {
        this.timer += deltaTime;
        if (this.timer > 4)
        {
            this.m_player.m_hungryValue = 100;
            this.m_machine.SwitchState(new Idle(this.m_player, this.m_machine));
            this.timer = 0;
        }
    }
}
