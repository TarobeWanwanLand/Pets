using System.Collections.Generic;
using System.Text;
using MasterMemory;
using MessagePack;

namespace Pets.Entities
{
    /// <summary>
    /// ゲームのキャラクター情報を表す
    /// </summary>
    [MemoryTable("m_character"), MessagePackObject]
    public class Character : IValidatable<Character>
    {
        [Key(0)]
        [PrimaryKey]
        public int EntityId { get; }
        
        [Key(1)]
        public string Name { get; }
        
        [Key(2)]
        public IReadOnlyList<Ability> Abilities { get; }

        [SerializationConstructor]
        public Character(int entityId, string name, IReadOnlyList<Ability> abilities)
        {
            EntityId = entityId;
            Name = name;
            Abilities = abilities;
        }

        void IValidatable<Character>.Validate(IValidator<Character> validator)
        {
            validator.Validate(x => x.EntityId > 0, "EntityIdの値が不正です。");
            validator.Validate(x => !string.IsNullOrEmpty(x.Name), "Nameが空です。");
            validator.Validate(x => x.Abilities != null, "Abilitiesがnullです。");
        }

        public override string ToString()
        {
            return MessagePackSerializer.SerializeToJson(this);
        }
    }
}
