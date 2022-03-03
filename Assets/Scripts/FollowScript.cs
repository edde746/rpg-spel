using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
