namespace Helloween
{
    public class Human : Entity
    {
        public readonly bool witcher;
        public Human(bool witcher, bool adult) : base("Human")
        {
            this.witcher = witcher;
            if (adult && !witcher)
            {
                inventory[ItemType.Candy] = 3;
                inventory[ItemType.Blood] = 1;
            }
            else if (!witcher)
            {
                inventory[ItemType.Candy] = 2;
                inventory[ItemType.Blood] = 0.5;
            }
        }
    }
}
