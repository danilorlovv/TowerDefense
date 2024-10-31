using UnityEngine;
using SpaceShooter;

namespace TowerDefense
{
    public class StandUp : MonoBehaviour
    {
        private Rigidbody2D m_Rigidbody;
        private SpriteRenderer m_SpriteRenderer;

        private void Start()
        {
            m_Rigidbody = GetComponentInParent<Rigidbody2D>();
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void LateUpdate()
        {
            transform.up = Vector2.up;

            var vel = m_Rigidbody.velocity.x;
            
            if (vel > 0.1f )
                m_SpriteRenderer.flipX = false;
            else if (vel < 0.1f)
                m_SpriteRenderer.flipX = true;
        }
    }
}