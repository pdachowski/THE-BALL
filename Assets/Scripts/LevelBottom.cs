using UnityEngine;

public class LevelBottom : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Movement movement)) {
            movement.ResetPosition();
        }
    }
}