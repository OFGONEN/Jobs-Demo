using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine.Jobs;

namespace Jobs_Demo.Step2
{
    [BurstCompile]
    public struct SeekJob : IJobParallelForTransform
    {
        [ReadOnly] public float SeekRadiusSq;
        [ReadOnly] public float3 CurrentPosition;

        [NativeDisableParallelForRestriction] public NativeArray<int> TargetIndices;


        [BurstCompile]
        public void Execute(int index, TransformAccess transform)
        {
            var targetPosition = transform.position;
            var distance = math.distancesq(targetPosition, CurrentPosition);

            if (distance < SeekRadiusSq)
            {
                TargetIndices[index] = 1;
            }
        }
    }
}