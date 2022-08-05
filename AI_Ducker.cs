using Microsoft.Xna.Framework;

namespace IroncladSewing
{
    public class AI_Ducker : AI
    {
        public AI_Ducker(Character controlledCharacter) 
            : base(controlledCharacter) {}

        public override void Update(float gameTime)
        {
            ControlledCharacter.Duck();
        }
    }
}