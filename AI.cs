using Microsoft.Xna.Framework;

namespace IroncladSewing
{
    public class AI : Component
    {
        private Character parent;
        public Character Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }
        
        public AI(Character controlledCharacter)
        {
            this.parent = controlledCharacter;
        }

        public virtual void FollowTarget(Entity entity) {}
    }
}