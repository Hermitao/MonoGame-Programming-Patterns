using Microsoft.Xna.Framework;

public class AI_Ducker : AI
{
    public AI_Ducker(Character controlledCharacter) 
        : base(controlledCharacter) {}

    public override void Update(float gameTime)
    {
        controlledCharacter.Duck();
    }
}