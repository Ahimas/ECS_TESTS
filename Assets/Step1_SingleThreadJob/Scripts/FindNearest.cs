using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace ECSTestsStep1
{
    public class FindNearest : MonoBehaviour
    {
         [SerializeField] private Spawner spawner;

         private NativeArray<float3> TargetPositions;
         private NativeArray<float3> SeekerPositions;
         private NativeArray<float3> NearestTargetPositions;

         private void Start()
         {
             TargetPositions = new NativeArray<float3>(spawner.NumTargets, Allocator.Persistent);
             SeekerPositions = new NativeArray<float3>(spawner.NumSeekers, Allocator.Persistent);
             NearestTargetPositions = new NativeArray<float3>(spawner.NumSeekers, Allocator.Persistent);
         }

         private void OnDestroy()
         {
             TargetPositions.Dispose();
             SeekerPositions.Dispose();
             NearestTargetPositions.Dispose();
         }

         private void Update()
        {
            for (int i = 0; i < spawner.NumTargets; i++)
            {
                TargetPositions[i] = Spawner.TargetTransforms[i].position;
            }

            for (int i = 0; i < spawner.NumSeekers; i++)
            {
                SeekerPositions[i] = Spawner.SeekerTransforms[i].position;
            }

            FindNearestJob findJob = new FindNearestJob()
            {
                TargetPositions = TargetPositions,
                SeekerPositions = SeekerPositions,
                NearestTargetPositions = NearestTargetPositions
            };

            JobHandle jobHandle = findJob.Schedule();
            
            jobHandle.Complete();

            for (int i = 0; i < SeekerPositions.Length; i++)
            {
                Debug.DrawLine(SeekerPositions[i], NearestTargetPositions[i]);
            }

        }
    }
}
