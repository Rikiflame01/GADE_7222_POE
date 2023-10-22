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
        // Crossfade to Clapping animation
        spectator.Animator.CrossFade("Clapping", 0.1f);
        // Transition to another state after a random duration
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
        // Crossfade to Cheering animation
        spectator.Animator.CrossFade("Cheering", 0.1f);
        // Transition to another state after a random duration
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
        // Crossfade to Dissapointed animation
        spectator.Animator.CrossFade("Dissapointed", 0.1f);
        // Transition to another state after a random duration
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
        // Randomize initial animation offset
        Animator.CrossFade("Clapping", 0.1f, -1, Random.Range(0f, 1f));
        // Set initial state
        SetState(new ClappingState(this));
    }

    public void SetState(SpectatorState state)
    {
        currentState = state;
        currentState.Handle();
    }

    public void ChangeStateAfterRandomDuration()
    {
        float randomDuration = Random.Range(8f, 20f); // Adjusted duration for smoother transitions
        Invoke("RandomizeState", randomDuration);
    }

    private void RandomizeState()
    {
        int randomState = Random.Range(0, 3); // Assuming 3 states for simplicity
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
}
