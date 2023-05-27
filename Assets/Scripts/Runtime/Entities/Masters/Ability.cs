using MasterMemory;
using MessagePack;

namespace Pets.Entities
{
    [MemoryTable("m_abilities"), MessagePackObject(true)]
    public class Ability : IValidatable<Ability>
    {
        [Key(0)]
        [PrimaryKey]
        public int AbilityId { get; }
        [Key(1)]
        public string Name { get; }

        [SerializationConstructor]
        public Ability(int abilityId, string name)
        {
            AbilityId = abilityId;
            Name = name;
        }

        void IValidatable<Ability>.Validate(IValidator<Ability> validator)
        {
            validator.Validate(x => x.AbilityId > 0, "AbilityIdの値が不正です。");
            validator.Validate(x => !string.IsNullOrEmpty(x.Name), "Nameが空です。");
        }

        public override string ToString()
        {
            return MessagePackSerializer.SerializeToJson(this);
        }
    }
}