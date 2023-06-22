using UnityEngine;

namespace Shooter.Footprints
{
    public class FootTrigger : MonoBehaviour
    {
        [SerializeField] private int footIndex;

        public int FootIndex => footIndex;
    }
}