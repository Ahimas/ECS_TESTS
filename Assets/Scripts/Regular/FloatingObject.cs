using UnityEngine;

namespace ECSTests
{
    public class FloatingObject : MonoBehaviour
    {
        private Vector3 _direction;
        private static Vector2 _bounds = new Vector2(50, 50);
        
        // Start is called before the first frame update
        private void Start()
        {
            var dir = Random.insideUnitCircle;
            var pos = new Vector3(Random.Range(0, _bounds.x), 0, Random.Range(0, _bounds.y));
            
            _direction = new Vector3(dir.x, 0, dir.y);
            transform.position = pos;
        }

        private void Update()
        {
            transform.position += _direction * Time.deltaTime;
        
            if (transform.position.x < 0 || transform.position.x > _bounds.x || transform.position.z < 0 ||
                transform.position.z > _bounds.y)
            {
                _direction *= -1;
            }
        }
    }
}
