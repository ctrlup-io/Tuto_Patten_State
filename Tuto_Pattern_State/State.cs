namespace Tuto_Pattern_State
{
    public abstract class State: IState
    {
        public abstract void ChangeEtat(DistributeurAutomatique context);
        protected abstract bool Validate(DistributeurAutomatique context);
    }
}
