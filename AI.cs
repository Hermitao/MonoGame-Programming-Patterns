using Microsoft.Xna.Framework;

namespace IroncladSewing
{
    public class AI : Component
    {
        private Character controlledCharacter;
        public Character ControlledCharacter
        {
            get
            {
                return controlledCharacter;
            }
            set
            {
                controlledCharacter = value;
            }
        }
        
        public AI(Character controlledCharacter)
        {
            this.controlledCharacter = controlledCharacter;
        }

        public virtual void FollowTarget(Entity entity) {}
    }
}