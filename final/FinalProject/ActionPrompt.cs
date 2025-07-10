public class ActionPrompt
{
    protected string _promptType;
    protected int _requiredActions;
    protected int _timeLimitSecs;

    public virtual void Execute() { /* ... */ }
}
