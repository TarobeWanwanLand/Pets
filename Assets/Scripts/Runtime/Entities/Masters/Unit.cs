using System.Collections.Generic;
using MasterMemory;
using MessagePack;

namespace Pets.Entities.Masters
{
    [MemoryTable("m_unit"), MessagePackObject]
    public sealed class Unit : IValidatable<Unit>
    {
        [Key(0)]
        [PrimaryKey]
        public int UnitId { get; }
        
        [Key(1)]
        public string Name { get; }
        
        [Key(2)]
        public int Rarity { get; }
        
        [Key(3)]
        public int Cost { get; }

        [Key(4)]
        public IReadOnlyList<Ability> Abilities { get; }
        
        [Key(5)]
        public string PrefabPath { get; }

        [SerializationConstructor]
        public Unit(int unitId, string name, int rarity, int cost, IReadOnlyList<Ability> abilities, string prefabPath)
        {
            UnitId = unitId;
            Name = name;
            Rarity = rarity;
            Cost = cost;
            Abilities = abilities;
            PrefabPath = prefabPath;
        }

        void IValidatable<Unit>.Validate(IValidator<Unit> validator)
        {
            validator.Validate(x => x.UnitId > 0, "UnitIdの値が不正です。");
            validator.Validate(x => !string.IsNullOrEmpty(x.Name), "Nameが空です。");
            validator.Validate(x => x.Rarity > 0, "Rarityの値が不正です。");
            validator.Validate(x => x.Cost > 0, "Costの値が不正です。");
            validator.Validate(x => x.Abilities != null, "Abilitiesがnullです。");
            validator.Validate(x => !string.IsNullOrEmpty(x.PrefabPath), "PrefabPathが空です。");
        }

        public override string ToString()
        {
            return MessagePackSerializer.SerializeToJson(this);
        }
    }
}