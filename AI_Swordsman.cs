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
            Command command = new NullCommand();

            float followDistance = 50f;
            float followDistanceOffset = 50f;
            if (ControlledCharacter.Position.X < entity.Position.X - followDistance - followDistanceOffset)
            {
                command = new MoveRightCommand();
            }
            if (ControlledCharacter.Position.X > entity.Position.X + followDistance + followDistanceOffset)
            {
                command = new MoveLeftCommand();
            }
            
            float horizontalDistance = 
                Math.Abs(ControlledCharacter.Position.X - entity.Position.X);

            if (horizontalDistance <= followDistance && ControlledCharacter.state != Character.State.Idle)
            {
                command = new MoveRightReleaseCommand();
                command.execute(ControlledCharacter);
                command = new MoveLeftReleaseCommand();
                command.execute(ControlledCharacter);
                command = new IdleCommand();
            }

            command.execute(ControlledCharacter);
        }
    }
}