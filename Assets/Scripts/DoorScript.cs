using UnityEngine;
using UnityEngine.Events;

public class DoorScript : MonoBehaviour
{
    bool _colliding;
    public bool colliding { get { return _colliding; } }
    public UnityEvent interactEvent, enterEvent, leaveEvent;
    public bool fireEnter = true, fireLeave = true;

    void Update()
    {
        if (colliding && Input.GetKeyDown(KeyCode.E)) interactEvent.Invoke();
    }

    public void SetEventFiring(bool active)
    {
        fireEnter = active;
        fireLeave = active;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            _colliding = true;
            if (fireEnter) enterEvent.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            _colliding = false;
            if (fireLeave) leaveEvent.Invoke();
        }
    }
}
