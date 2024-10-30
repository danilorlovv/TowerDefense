﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Скрипт прожектайла. Кидается на топ префаба прожектайла.
    /// </summary>
    public class Projectile : Entity
    {
        /// <summary>
        /// Линейная скорость полета снаряда.
        /// </summary>
        [SerializeField] private float m_Velocity;

        /// <summary>
        /// Время жизни снаряда.
        /// </summary>
        [SerializeField] private float m_Lifetime;

        /// <summary>
        /// Повреждения наносимые снарядом.
        /// </summary>
        [SerializeField] private int m_Damage;

        /// <summary>
        /// Эффект попадания от что то твердое. 
        /// </summary>
        [SerializeField] private ImpactEffect m_ImpactEffectPrefab;

        private float m_Timer;

        private void Update()
        {
            float stepLength = Time.deltaTime * m_Velocity;
            Vector2 step = transform.up * stepLength;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up,stepLength);
            
            // не забыть выключить в свойствах проекта, вкладка Physics2D иначе не заработает
            // disable queries hit triggers
            // disable queries start in collider
            if (hit)
            {
                var destructible = hit.collider.transform.root.GetComponent<Destructible>();

                if(destructible != null && destructible != m_Parent)
                {
                    destructible.ApplyDamage(m_Damage);

                    // #Score
                    // добавляем очки за уничтожение
                    if(Player.Instance != null && destructible.HitPoints < 0)
                    {
                        // проверяем что прожектайл принадлежит кораблю игрока. 
                        // здесь есть нюанс - если мы выстрелим прожектайл и после умрем
                        // то новый корабль игрока будет другим, в случае если прожектайл запущенный из предыдущего шипа
                        // добьет то очков не дадут. Можно отправить пофиксить на ДЗ. (например тупо воткнув флаг что прожектайл игрока)
                        if(m_Parent == Player.Instance.ActiveShip)
                        {
                            Player.Instance.AddScore(destructible.ScoreValue);
                        }
                    }
                }

                OnProjectileLifeEnd(hit.collider, hit.point);
            }

            m_Timer += Time.deltaTime;

            if(m_Timer > m_Lifetime)
                Destroy(gameObject);

            transform.position += new Vector3(step.x, step.y, 0);
        }

        private void OnProjectileLifeEnd(Collider2D collider, Vector2 pos)
        {
            if(m_ImpactEffectPrefab != null)
            {
                var impact = Instantiate(m_ImpactEffectPrefab.gameObject);
                impact.transform.position = pos;
            }

            Destroy(gameObject);
        }


        private Destructible m_Parent;

        public void SetParentShooter(Destructible parent)
        {
            m_Parent = parent;
        }
    }
}

