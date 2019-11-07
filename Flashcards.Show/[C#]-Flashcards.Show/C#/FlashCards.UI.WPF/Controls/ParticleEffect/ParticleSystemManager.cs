using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Media3D;
using FlashCards.ViewModel;
using System.Reflection;

namespace Particles
{

    public class Particle
    {
        public Point3D Position;
        public Vector3D Velocity;
        public double StartLife;
        public double Life;
        public double Decay;
        public double StartSize;
        public double Size;
    }


    public class ParticleSystemManager
    {
        private Dictionary<System.Windows.Media.Color, ParticleSystem> particleSystems;

        public ParticleSystemManager()
        {
            this.particleSystems = new Dictionary<System.Windows.Media.Color, ParticleSystem>();
        }

        public void Update(float elapsed)
        {
            foreach (ParticleSystem ps in this.particleSystems.Values)
            {
                ps.Update(elapsed);
            }
        }

        public void SpawnParticle(Point3D position, double speed, System.Windows.Media.Color color, double size, double life)
        {
            try
            {
                ParticleSystem ps = this.particleSystems[color];
                ps.SpawnParticle(position, speed, size, life);
            }
            catch (Exception e)
            {
                Utils.LogException(MethodBase.GetCurrentMethod(), e);
            }
        }

        public Model3D CreateParticleSystem(int maxCount, System.Windows.Media.Color color,Uri source)
        {
            ParticleSystem ps = new ParticleSystem(maxCount, color, source);
            this.particleSystems.Add(color, ps);
            return ps.ParticleModel;
        }

        public int ActiveParticleCount
        {
            get
            {
                int count = 0;
                foreach (ParticleSystem ps in this.particleSystems.Values)
                    count += ps.Count;
                return count;
            }
        }
    }
}
