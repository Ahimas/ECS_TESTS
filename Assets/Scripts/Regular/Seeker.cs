using UnityEngine;

namespace ECSTests
{
    public class Seeker : MonoBehaviour
    {
        public Vector3 Direction;
        
        private void Update()
        {
            transform.position += Direction * Time.deltaTime;
        }
    }
}
