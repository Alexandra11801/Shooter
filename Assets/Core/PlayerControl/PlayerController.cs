using UnityEngine;

namespace Shooter.PlayerControl
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private Animator animator;
        [SerializeField] private float runningSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float jumpForce;
        private bool running;
        private int rotationDirection;

        private void FixedUpdate()
        {
            if (running)
            {
                rigidbody.MovePosition(transform.position + runningSpeed * Time.deltaTime * transform.forward);
            }
            if (rotationDirection != 0)
            {
                rigidbody.MoveRotation(transform.rotation * 
                                       Quaternion.Euler(rotationSpeed * rotationDirection * Time.deltaTime * Vector3.up));
            }
        }

        public void Run()
        {
            running = true;
            animator.SetBool("Running", true);
        }

        public void Stop()
        {
            running = false;
            animator.SetBool("Running", false);
        }

        public void AddRotationDirection(int direction)
        {
            rotationDirection += direction;
        }

        public void StartJump()
        {
            animator.SetTrigger("Jump");
        }

        public void Jump()
        {
            rigidbody.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }

        public void StartShooting()
        {
            animator.SetBool("Shooting", true);
        }

        public void StopShooting()
        {
            animator.SetBool("Shooting", false);
        }
    }
}