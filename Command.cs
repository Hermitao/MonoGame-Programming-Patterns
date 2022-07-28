using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public interface Command
{
    public void execute(Character character);
}

public class JumpCommand : Command
{
    public void execute(Character character)
    {
        character.Jump();
    }
}

public class DuckCommand : Command
{
    public void execute(Character character)
    {
        character.Duck();
    }
}

public class IdleCommand : Command
{
    public void execute(Character character)
    {
        character.Idle();
    }
}