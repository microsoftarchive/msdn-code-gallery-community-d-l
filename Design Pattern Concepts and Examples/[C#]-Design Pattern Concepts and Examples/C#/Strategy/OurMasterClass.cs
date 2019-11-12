namespace com.tp.pattern.strategy
{
    public abstract class OurMasterClass
    {
        private Algorithm algorithm;
        private Behavior behavior;
        public void setAlgorithm(Algorithm algorithm)
        {
            this.algorithm = algorithm;
        }
        public void setBehavior(Behavior behavior)
        {
            this.behavior = behavior;
        }
        public void PerformAlgorithm()
        {
            algorithm.SomeProcess();
        }
        public void ChangeBehavior()
        {
            behavior.ApplyBehavior();
        }
    }
}
