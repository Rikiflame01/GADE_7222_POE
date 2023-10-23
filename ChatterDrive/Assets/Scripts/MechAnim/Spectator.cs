using UnityEngine;

public abstract class SpectatorState
{
    protected Spectator spectator;
    public abstract void Handle();
}

public class ClappingState : SpectatorState
{
    public ClappingState(Spectator spectator)
    {
        this.spectator = spectator;
    }

    public override void Handle()
    {
        spectator.Animator.CrossFade("Clapping", 0.1f);
        spectator.ChangeStateAfterRandomDuration();
    }
}

public class CheeringState : SpectatorState
{
    public CheeringState(Spectator spectator)
    {
        this.spectator = spectator;
    }

    public override void Handle()
    {
        spectator.Animator.CrossFade("Cheering", 0.1f);
        spectator.ChangeStateAfterRandomDuration();
    }
}

public class DissapointedState : SpectatorState
{
    public DissapointedState(Spectator spectator)
    {
        this.spectator = spectator;
    }

    public override void Handle()
    {
        spectator.Animator.CrossFade("Dissapointed", 0.1f);
        spectator.ChangeStateAfterRandomDuration();
    }
}

public class Spectator : MonoBehaviour
{
    public Animator Animator { get; private set; }
    private SpectatorState currentState;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        Animator.CrossFade("Clapping", 0.1f, -1, Random.Range(0f, 1f));
        SetState(new ClappingState(this));
    }

    public void SetState(SpectatorState state)
    {
        currentState = state;
        currentState.Handle();
    }

    public void ChangeStateAfterRandomDuration()
    {
        float randomDuration = Random.Range(8f, 20f);
        Invoke("RandomizeState", randomDuration);
    }

    private void RandomizeState()
    {
        int randomState = Random.Range(0, 3);
        switch (randomState)
        {
            case 0:
                SetState(new ClappingState(this));
                break;
            case 1:
                SetState(new CheeringState(this));
                break;
            case 2:
                SetState(new DissapointedState(this));
                break;
        }
    }

    public void BecomeDisappointed()
    {
        SetState(new DissapointedState(this));
    }
}
