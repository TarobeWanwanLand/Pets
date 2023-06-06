using System;
using Unity.Entities;

namespace Pets.ECS.WorldBuilders
{
    internal sealed class GameWorldHandler : IDisposable
    {
        private World _world;
        
        public GameWorldHandler(string worldName, bool editorWorld)
        {
            // ワールドを作成
            _world = new World(worldName);
            World.DefaultGameObjectInjectionWorld = _world;

            // システムグループを作成
            var initializationSystemGroup = _world.GetOrCreateSystemManaged<InitializationSystemGroup>();
            var simulationSystemGroup = _world.GetOrCreateSystemManaged<SimulationSystemGroup>();
            var presentationSystemGroup = _world.GetOrCreateSystemManaged<PresentationSystemGroup>();
            
            // Systemの順序をソートする
            // initializationSystemGroup.SortSystems();
            // simulationSystemGroup.SortSystems();
            // presentationSystemGroup.SortSystems();
            
            // プレイヤー
            ScriptBehaviourUpdateOrder.AppendWorldToCurrentPlayerLoop(_world);
        }

        public void Dispose()
        {
            _world.Dispose();
            
            ScriptBehaviourUpdateOrder.RemoveWorldFromCurrentPlayerLoop(_world);
        }
    }
}
