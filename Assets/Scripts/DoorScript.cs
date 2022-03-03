using UnityEngine;
using UnityEngine.Events;

public class DoorScript : MonoBehaviour
{
    bool _colliding;
    public bool colliding { get { return _colliding; } }
    public UnityEvent enterEvent;

    void Update()
    {
        if (colliding && Input.GetKey(KeyCode.E))
        {
            Debug.Log("Should Invoke");
            enterEvent.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            _colliding = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            _colliding = false;
    }
}
