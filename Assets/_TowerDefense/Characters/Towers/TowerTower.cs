using UnityEngine;

namespace _TowerDefense.Towers
{
    public class TowerTower : Tower
    {
        [SerializeField] private ParticleSystem FireParticle;

        private bool zappedSomething = false;
        
        protected override void DoAttack()
        {
            for (int i = 0; i < NumHit; i++)
            {
                if (Hits[i].transform.TryGetComponent(out ObjectHealth health))
                {
                    health.Attacked(attackDamage);
                    FireParticle.Play();
                    zappedSomething = true;
                }
            }

            if (zappedSomething)
            {
                FireParticle.Play();
                zappedSomething = false;
            }
        }
    }
}