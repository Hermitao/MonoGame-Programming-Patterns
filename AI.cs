using Microsoft.Xna.Framework;

namespace IroncladSewing
{
    public class AI : Component
    {
        private Character parentCharacter;
        public Character ParentCharacter
        {
            get
            {
                return parentCharacter;
            }
            set
            {
                parentCharacter = value;
            }
        }
        
        public AI(Character controlledCharacter)
        {
            this.parentCharacter = controlledCharacter;
        }

        public virtual void FollowTarget(Entity entity) {}
    }
}