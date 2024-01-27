using UnityEngine;

namespace ECSTests
{
    public class FindNearest : MonoBehaviour
    {
        [SerializeField] private Spawner spawner;

        private Vector3[] _nearestTargetPosition;

        private void Start()
        {
            _nearestTargetPosition = new Vector3[spawner.NumSeekers];
        }
        
        private void Update()
        {
            for (int i = 0; i < spawner.NumSeekers; i++)
            {
                float nearestDistance = float.MaxValue;

                foreach (var target in Spawner.TargetTransforms)
                {
                    var offset = target.position - Spawner.SeekerTransforms[i].position;
                    float distance = offset.sqrMagnitude;
                    
                    if (distance > nearestDistance) continue;
                    
                    nearestDistance = distance;
                    _nearestTargetPosition[i] = target.position;
                }
            }

            for (int i = 0; i < spawner.NumSeekers; i++)
            {
                Debug.DrawLine(Spawner.SeekerTransforms[i].position, _nearestTargetPosition[i]);
            }
        }
    }
}
