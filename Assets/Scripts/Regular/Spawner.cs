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
        public Vector2 Bounds;
        
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < NumSeekers; i++)
            {
                var dir = Random.insideUnitCircle;
                var pos = new Vector3(Random.Range(0, Bounds.x), 0, Random.Range(0, Bounds.y));
                var seeker = Instantiate(SeekerPrefab).GetComponent<Seeker>();

                seeker.Direction = new Vector3(dir.x, 0, dir.y);
                seeker.transform.position = pos;
            }

            TargetTransforms = new Transform[NumTargets];
            
            for (int i = 0; i < NumTargets; i++)
            {
                var dir = Random.insideUnitCircle;
                var pos = new Vector3(Random.Range(0, Bounds.x), 0, Random.Range(0, Bounds.y));
                var target = Instantiate(TargetPrefab).GetComponent<Target>();

                target.Direction = new Vector3(dir.x, 0, dir.y);
                TargetTransforms[i] = target.transform;
                TargetTransforms[i].position = pos;
            }
        }
    }
}
