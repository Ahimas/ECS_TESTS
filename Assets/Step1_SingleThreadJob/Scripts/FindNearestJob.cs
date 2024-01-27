using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace ECSTestsStep1
{
    [BurstCompile]
    public struct FindNearestJob : IJob
    {
        [ReadOnly] public NativeArray<float3> TargetPositions;
        [ReadOnly] public NativeArray<float3> SeekerPositions;
        
        public NativeArray<float3> NearestTargetPositions;

        public void Execute()
        {
            for (int i = 0; i < SeekerPositions.Length; i++)
            {
                float nearestDistance = float.MaxValue;

                foreach (var targetPos in TargetPositions)
                {
                    float distance = math.distancesq(SeekerPositions[i], targetPos);
                    
                    if (distance > nearestDistance) continue;

                    nearestDistance = distance;
                    NearestTargetPositions[i] = targetPos;
                }
            }

        }
    }
}
