using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    public virtual int getLevel()
    {
        return 0;
    }

    public virtual bool isTriggered()
    {
        return false;
    }

    public virtual StateEnum getTargetState()
    {
        return StateEnum.None;
    }
}


public class IdleStateTransition : Transition
{
    Player player;

    public IdleStateTransition(Player player)
    {
        this.player = player;
    }

    public override StateEnum getTargetState()
    {
        return StateEnum.idle;
    }

    public override bool isTriggered()
    {
        if (this.player && (this.player.Speed <= 0f && this.player.Y <= 0))
        {
            return true;
        }
        return false;
    }
}

public class WalkTransition : Transition
{

    Player player;

    public override int getLevel()
    {
        return 1;
    }

    public WalkTransition(Player player)
    {
        this.player = player;
    }

    public override StateEnum getTargetState()
    {
        return StateEnum.run;
    }

    public override bool isTriggered()
    {
        if (this.player && this.player.Speed > 1f)
        {
            return true;
        }
        return false;
    }
}

public class RunTransition : Transition
{

    Player player;

    public override int getLevel()
    {
        return 1;
    }

    public RunTransition(Player player)
    {
        this.player = player;
    }

    public override StateEnum getTargetState()
    {
        return StateEnum.run;
    }

    public override bool isTriggered()
    {
        if (this.player && this.player.Speed > 2.5f)
        {
            return true;
        }
        return false;
    }
}

public class JumpTransition : Transition
{
    Player player;

    public override int getLevel()
    {
        return 2;
    }

    public JumpTransition(Player player)
    {
        this.player = player;
    }
    public override StateEnum getTargetState()
    {
        return StateEnum.doublejump;
    }

    public override bool isTriggered()
    {
        if (this.player && this.player.Y > 2f)
        {
            return true;
        }
        return false;
    }
}


public class DoubleJumpTransition : Transition
{
    Player player;

    public override int getLevel()
    {
        return 2;
    }

    public DoubleJumpTransition(Player player)
    {
        this.player = player;
    }
    public override StateEnum getTargetState()
    {
        return StateEnum.doublejump;
    }

    public override bool isTriggered()
    {
        if (this.player && this.player.Y > 5f)
        {
            return true;
        }
        return false;
    }
}

public class MovementFSMTransition : Transition
{
    Player player;

    public override int getLevel()
    {
        return 1;
    }

    public MovementFSMTransition(Player player)
    {
        this.player = player;
    }
    public override StateEnum getTargetState()
    {
        return StateEnum.movementSubFSM;
    }

    public override bool isTriggered()
    {
        if (this.player && (this.player.Speed > 0f || this.player.Y > 0f))
        {
            return true;
        }
        return false;
    }
}

public class JumpFSMTransition : Transition
{
    Player player;
    public override int getLevel()
    {
        return 2;
    }

    public JumpFSMTransition(Player player)
    {
        this.player = player;
    }
    public override StateEnum getTargetState()
    {
        return StateEnum.jumpSubFSM;
    }

    public override bool isTriggered()
    {
        if (this.player && this.player.Y > 0f)
        {
            return true;
        }
        return false;
    }
}




