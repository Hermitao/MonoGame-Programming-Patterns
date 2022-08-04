using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace IroncladSewing
{

    public class Command
    {
        public virtual void execute(Character character)
        {

        }
    }

    public class AttackCommand : Command
    {
        public override void execute(Character character)
        {
            switch (character.state)
            {
                case Character.State.Idle:
                    character.Attack();
                    break;
                case Character.State.Ducking:
                    character.Attack();
                    break;
                case Character.State.RunningRight:
                    character.Attack();
                    break;
                case Character.State.RunningLeft:
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
                case Character.State.Idle:
                    character.Duck();
                    break;
                case Character.State.RunningRight:
                    character.Duck();
                    break;
                case Character.State.RunningLeft:
                    character.Duck();
                    break;
            }
        }
    }

    public class DuckReleaseCommand : Command
    {
        public override void execute(Character character)
        {
            switch (character.state)
            {
                case Character.State.Ducking:
                    character.Idle();
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
                case Character.State.Jumping:
                    character.Idle();
                    break;
                case Character.State.Ducking:
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
                case Character.State.Idle:
                    character.Jump();
                    break;
                case Character.State.RunningRight:
                    character.Jump();
                    break;
                case Character.State.RunningLeft:
                    character.Jump();
                    break;
                case Character.State.Ducking:
                    character.Jump();
                    break;
            }
        }
    }

    public class MoveRightCommand : Command
    {
        public override void execute(Character character)
        {
            character.PressingRight = true;

            switch (character.state)
            {
                case Character.State.Idle:
                    character.MoveRight();
                    break;
                case Character.State.RunningLeft:
                    character.MoveRight();
                    break;
                case Character.State.Ducking:
                    character.MoveRight();
                    break;
            }
        }
    }

    public class MoveRightReleaseCommand : Command
    {
        public override void execute(Character character)
        {
            character.PressingRight = false;

            switch (character.state)
            {
                case Character.State.RunningRight:
                    character.MoveRight(true);
                    break;
            }
        }
    }

    public class MoveLeftCommand : Command
    {
        public override void execute(Character character)
        {
            character.PressingLeft = true;

            switch (character.state)
            {
                case Character.State.Idle:
                    character.MoveLeft();
                    break;
                case Character.State.RunningRight:
                    character.MoveLeft();
                    break;
                case Character.State.Ducking:
                    character.MoveLeft();
                    break;
            }
        }
    }

    public class MoveLeftReleaseCommand : Command
    {
        public override void execute(Character character)
        {
            character.PressingLeft = false;

            switch (character.state)
            {
                case Character.State.RunningLeft:
                    character.MoveLeft(true);
                    break;
            }
        }
    }

    public class NullCommand : Command
    {
        // public override void execute(Character character) 
        // {
        //     switch (character.state)
        //     {
        //         case Character.State.RunningRight:
        //             character.Idle();
        //             break;
        //         case Character.State.RunningLeft:
        //             character.Idle();
        //             break;
        //         case Character.State.Ducking:
        //             character.Idle();
        //             break;
        //         case Character.State.Attacking:
        //             character.Idle();
        //             break;
        //     }
        // }
    }
}