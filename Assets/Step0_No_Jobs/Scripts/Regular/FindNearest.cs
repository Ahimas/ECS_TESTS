using UnityEngine;

namespace ECSTests
{
    public class FindNearest : MonoBehaviour
    {
        private void Update()
        {
            Vector3 nearestTargetPosition = new Vector3();
            float nearestDistance = float.MaxValue;

            foreach (var target in Spawner.TargetTransforms)
            {
                var offset = target.position - transform.position;
                float distance = offset.sqrMagnitude;

                if (distance > nearestDistance) continue;
                
                nearestDistance = distance;
                nearestTargetPosition = target.position;
                
            }

            Debug.DrawLine(transform.position, nearestTargetPosition);
        }
    }
}
