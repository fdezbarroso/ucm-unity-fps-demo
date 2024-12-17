using UnityEngine;

public class RespawnOnTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform _respawnPoint = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = _respawnPoint.position;
            Physics.SyncTransforms(); // Necesario debido al character controller
        }
    }
}
