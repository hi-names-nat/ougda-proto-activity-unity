using UnityEngine;

namespace _TowerDefense.Towers
{
    //This is called inheritance. In this case we're taking the base class of tower and telling C# that
    //we want TowerTower to be everything tower is. TowerTower will have every part of Tower that is either
    // public or protected (meaning that only itself and its child classes can access that thing).
    public class TowerTower : Tower
    {
        [SerializeField] private ParticleSystem FireParticle;

        private bool zappedSomething = false;
        
        //'override' means to change the behavior of an inhereted function.
        protected override void DoAttack()
        {
            //We need to access NumHit and Hits, but we can't. They exist in Tower.cs, so why can't we see them??
            //hint: read the above carefully and look at where we declare NumHit and Hits in Tower.cs...
            for (int i = 0; i < NumHit; i++)
            {
                if (Hits[i].transform.TryGetComponent(out ObjectHealth health))
                {
                    //What do we do to make the health script's health go down?
                    // hint: Check the ObjectHealth script!
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