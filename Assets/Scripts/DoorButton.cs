using UnityEngine;
using UnityEngine.Events;

public class DoorButton : MonoBehaviour
{
    //[SerializeField]
    //private Door _door;
    //[SerializeField]
    //private Collider _trigger;

    [SerializeField]
    private UnityEvent _onTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _onTrigger?.Invoke();

            // _door.Open();
        }
    }
}
