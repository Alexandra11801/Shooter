using UnityEngine;

namespace Shooter.Footprints
{
    public class StepsRegister : MonoBehaviour
    {
        [SerializeField] private GameObject footprintPrefab;
        [SerializeField] private float footprintsHeight;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<FootTrigger>(out var foot))
            {
                var footprintPosition = new Vector3(other.transform.position.x, footprintsHeight, other.transform.position.z);
                var footprintRotation = Quaternion.Euler(Vector3.up * other.transform.parent.eulerAngles.y);
                var footprint = Instantiate(footprintPrefab, footprintPosition, footprintRotation, transform);
                footprint.transform.localScale = new Vector3(footprint.transform.localScale.x * foot.FootIndex,
                    footprint.transform.localScale.y, footprint.transform.localScale.z);
            }
        }
    }
}