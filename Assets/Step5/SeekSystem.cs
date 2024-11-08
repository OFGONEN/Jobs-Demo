using Unity.Burst;
using Unity.Entities;

namespace Jobs_Demo.Step5
{
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
    partial struct SeekSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {

        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {

        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}