using UnityEngine;

public class Target : MonoBehaviour
{
    public Vector3 Direction;

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * Time.deltaTime;
    }
}
