using System;
using Microsoft.Xna.Framework;

namespace IroncladSewing
{
    public class AI_Swordsman : AI
    {
        private Entity targetEntity;

        public AI_Swordsman(Character controlledCharacter, Entity targetEntity) 
            : base(controlledCharacter) 
        {
            this.targetEntity = targetEntity;
        }

        public override void Update(float gameTime)
        {
            this.FollowTarget(targetEntity);
        }

        public override void FollowTarget(Entity entity)
        {
            Command command = new IdleCommand();

            float followDistance = 50f;
            float followDistanceOffset = 150f;
            if (ParentCharacter.Position.X < entity.Position.X - followDistance - followDistanceOffset)
            {
                command = new MoveRightCommand();
            }
            if (ParentCharacter.Position.X > entity.Position.X + followDistance + followDistanceOffset)
            {
                command = new MoveLeftCommand();
            }
            
            float horizontalDistance = 
                Math.Abs(ParentCharacter.Position.X - entity.Position.X);

            if (horizontalDistance <= followDistance)
            {
                command = new MoveRightReleaseCommand();
                command.execute(ParentCharacter);
                command = new MoveLeftReleaseCommand();
                command.execute(ParentCharacter);
                command = new IdleCommand();
                command.execute(ParentCharacter);
            }

            command.execute(ParentCharacter);
        }
    }
}