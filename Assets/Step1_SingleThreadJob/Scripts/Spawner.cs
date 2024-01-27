using UnityEngine;

namespace ECSTestsStep1
{
    public class Spawner : MonoBehaviour
    {
        public static Transform[] TargetTransforms;
        public static Transform[] SeekerTransforms;
        
        public GameObject SeekerPrefab;
        public GameObject TargetPrefab;
        public int NumSeekers;
        public int NumTargets;
        
        private void Start()
        {
            SeekerTransforms = new Transform[NumSeekers];
            
            for (int i = 0; i < NumSeekers; i++)
            {
                SeekerTransforms[i] = Instantiate(SeekerPrefab).transform;
            }

            TargetTransforms = new Transform[NumTargets];
            
            for (int i = 0; i < NumTargets; i++)
            {
                TargetTransforms[i] = Instantiate(TargetPrefab).transform;
            }
        }
    }
}
