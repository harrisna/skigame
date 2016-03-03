// adapted from Unity's standard roller ball
using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float m_MovePower = 5; // The force added to the ball to move it.
        [SerializeField] private bool m_UseTorque = true; // Whether or not to use torque to move the ball.
        [SerializeField] private float m_MaxAngularVelocity = 25; // The maximum velocity the ball can rotate at.
        [SerializeField] private float m_JumpPower = 2; // The force added to the ball when it jumps.

        private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        private Rigidbody m_Rigidbody;

        [SerializeField] private float jetJuice = 10.0f;
        [SerializeField] private float m_JetPower = 1f;
        [SerializeField] private float m_MaxJetJuice = 10.0f;
        [SerializeField] private float m_JetJuiceUsageRate = 0.1f;
        [SerializeField] private float m_JetJuiceRechargeRate = 0.25f;
        [SerializeField] private float m_AirControlPower = 0.25f;


        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            // Set the maximum angular velocity.
            GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
        }


        public void Move(Vector3 moveDirection, bool jump, bool jet)
        {
            // If using torque to rotate the ball...
            if (m_UseTorque)
            {
                // ... add torque around the axis defined by the move direction.
                m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x)*m_MovePower);
            }
            else
            {
                // Otherwise add force in the move direction.
                m_Rigidbody.AddForce(moveDirection*m_MovePower);
            }

            // If on the ground and jump is pressed...
            if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength) && jump)
            {
                // ... add force in upwards.
                m_Rigidbody.AddForce(Vector3.up*m_JumpPower, ForceMode.Impulse);
            }

            if (jet && jetJuice > 0.0f)
            {
                // jets!
                m_Rigidbody.AddForce(Vector3.up * m_JetPower, ForceMode.Impulse);
                jetJuice -= m_JetJuiceUsageRate;
                jetJuice = Math.Max(jetJuice, 0.0f);
            }
            else if (!jet && jetJuice < m_MaxJetJuice)
            {
                // recharge jets
                jetJuice += m_JetJuiceRechargeRate;
                jetJuice = Math.Min(jetJuice, m_MaxJetJuice);
            }

            // air control!
            if (!Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength))
            {
                m_Rigidbody.AddForce(moveDirection * m_MovePower * m_AirControlPower);
            }
        }
    }
}
