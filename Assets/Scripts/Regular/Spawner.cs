using UnityEngine;

namespace ECSTests
{
    public class Spawner : MonoBehaviour
    {
        public static Transform[] TargetTransforms;
        
        public GameObject SeekerPrefab;
        public GameObject TargetPrefab;
        public int NumSeekers;
        public int NumTargets;
        
        private void Start()
        {
            for (int i = 0; i < NumSeekers; i++)
            {
                Instantiate(SeekerPrefab);
            }

            TargetTransforms = new Transform[NumTargets];
            
            for (int i = 0; i < NumTargets; i++)
            {
                TargetTransforms[i] = Instantiate(TargetPrefab).transform;
            }
        }
    }
}
