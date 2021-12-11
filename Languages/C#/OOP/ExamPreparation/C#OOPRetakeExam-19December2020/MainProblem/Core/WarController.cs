using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characterParty = new List<Character>();
        private List<Item> itemPool = new List<Item>();

        public WarController()
        {
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character = null;

            if (characterType == "Warrior")
            {
                character = new Warrior(name);
            }
            else if (characterType == "Priest")
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException($"Invalid character type {characterType}!");
            }

            this.characterParty.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = null;

            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException($"Invalid item {itemName}!");
            }

            this.itemPool.Add(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = this.characterParty.Find(x => x.Name == characterName);

            if (character is null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item item = this.itemPool[this.itemPool.Count - 1];
            character.Bag.AddItem(item);
            this.itemPool.RemoveAt(this.itemPool.Count - 1);
            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            Character character = this.characterParty.Find(x => x.Name == characterName);
            string itemName = args[1];

            if (character is null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return $"{character.Name} used {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in this.characterParty.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {(character.IsAlive ? "Alive" : "Dead")}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string recieverName = args[1];

            Character attacker = this.characterParty.Find(x => x.Name == attackerName);
            Character receiver = this.characterParty.Find(x => x.Name == recieverName);

            if (attacker is null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            if (receiver is null)
            {
                throw new ArgumentException($"Character {recieverName} not found!");
            }

            if (attacker is IAttacker warrior)
            {
                StringBuilder output = new StringBuilder();
                warrior.Attack(receiver);
                output.AppendLine($"{attackerName} attacks {recieverName} for {attacker.AbilityPoints} hit points! {recieverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

                if (!receiver.IsAlive)
                {
                    output.Append($"{receiver.Name} is dead!");
                }

                return output.ToString().TrimEnd();
            }
            else
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.characterParty.Find(x => x.Name == healerName);
            Character receiver = this.characterParty.Find(x => x.Name == healingReceiverName);

            if (healer is null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            if (receiver is null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (healer is IHealer priest)
            {
                priest.Heal(receiver);
                return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
            }
            else
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }
        }
    }
}