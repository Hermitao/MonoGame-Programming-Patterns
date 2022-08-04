using Microsoft.Xna.Framework;

namespace IroncladSewing
{
    public class AI_Swordsman : AI
    {
        public AI_Swordsman(Character controlledCharacter) 
            : base(controlledCharacter) {}

        public override void Update(float gameTime)
        {
            this.FollowTarget();
        }

        public override void FollowTarget(Entity entity)
        {
            float followDistance = 50;
            if (parent.Position.X < entity.Position.X - followDistance)
            {
                character.MoveRight();
            }
            if (parent.Position.X > entity.Position.X + followDistance)
            {
                character.MoveLeft();
            }
            
            float horizontalDistance = 
                Math.Abs(parent.Position.X - entity.Position.X);

            if (horizontalDistance <= followDistance)
            {
                character.Idle();
            }
        }
    }
}