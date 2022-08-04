using Microsoft.Xna.Framework;

public class AI_Swordsman : AI
{
    public AI_Swordsman(Character controlledCharacter) 
        : base(controlledCharacter) {}

    public override void Update(float gameTime)
    {
        controlledCharacter.Jump();
    }
}