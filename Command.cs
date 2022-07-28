using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class Command
{
    public virtual void execute(Character character);
}

public class AttackCommand : Command
{
    public override void execute(Character character)
    {
        switch (character.state)
        {
            case State.Idle:
                character.Attack();
                break;
            case State.Ducking:
                character.Attack();
                break;
            case State.Running:
                character.Attack();
                break;
        }
    }
}

public class DuckCommand : Command
{
    public override void execute(Character character)
    {
        switch (character.state)
        {
            case State.Idle:
                character.Duck();
                break;
            case State.Jumping:
                character.Duck();
                break;
        }
    }
}

public class IdleCommand : Command
{
    public override void execute(Character character)
    {
        switch (character.state)
        {
            case State.Jumping:
                character.Idle();
                break;
            case State.Ducking:
                character.Idle();
                break;
        }
    }
}

public class JumpCommand : Command
{
    public override void execute(Character character)
    {
        switch (character.state)
        {
            case State.Idle:
                character.Jump();
                break;
            case State.Running:
                character.Jump();
                break;
            case State.Ducking:
                character.Jump();
                break;
        }
    }
}

public class MoveRightCommand : Command
{
    public override void execute(Character character)
    {
        switch (character.state)
        {
            case State.Idle:
                character.MoveRight();
                break;
            case State.Running:
                character.MoveRight();
                break;
        }
    }
}

public class MoveLeftCommand : Command
{
    public override void execute(Character character)
    {
        switch (character.state)
        {
            case State.Idle:
                character.MoveLeft();
                break;
            case State.Running:
                character.MoveLeft();
                break;
        }
    }
}

public class NullCommand : Command
{
    public override void execute(Character character) 
    {
        switch (character.state)
        {
            case State.Running:
                character.Idle();
                break;
            case State.Ducking:
                character.Idle();
                break;
            case State.Attack:
                character.Idle();
        }
    }
}