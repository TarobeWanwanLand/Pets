using MasterMemory;
using MessagePack;
using Pets.Core.Math;
using Pets.Entities.Masters;
using UnityEngine;

namespace Pets.Entities.Users
{
    /// <summary>
    /// ユニットの配置情報
    /// </summary>
    [MemoryTable("u_unit_placement"), MessagePackObject]
    public sealed class UnitPlacement : IValidatable<UnitPlacement>
    {
        /// <summary>
        /// 配置識別用ID
        /// </summary>
        [Key(0)]
        [PrimaryKey]
        public int PlacementId { get; }
        
        /// <summary>
        /// 配置されたユニット
        /// </summary>
        [Key(1)]
        public Unit Unit { get; }
        
        /// <summary>
        /// 配置された位置
        /// </summary>
        [Key(2)]
        public Vector2 Position { get; }
        
        /// <summary>
        /// 配置されたディグリー角度
        /// </summary>
        [Key(3)]
        public float Rotation { get; }
        
        [SerializationConstructor]
        public UnitPlacement(int placementId, Unit unit, Vector2 position, float rotation)
        {
            PlacementId = placementId;
            Unit = unit;
            Position = position;
            Rotation = rotation;
        }

        void IValidatable<UnitPlacement>.Validate(IValidator<UnitPlacement> validator)
        {
            validator.Validate(x => x.PlacementId > 0, "PlacementIdの値が不正です。");
            validator.Validate(x => x.Unit != null, "Unitがnullです。");
            validator.Validate(x => x.Rotation.IsWithin(0f, 360f), "Rotationの値が不正です。");
        }

        public override string ToString()
        {
            return MessagePackSerializer.SerializeToJson(this);
        }
    }
}