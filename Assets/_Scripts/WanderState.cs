using UnityEngine;

public class WanderState : State
{

    Vector3 nextDestination;
    float wanderTime = 5f;
    float timer;

    public WanderState(Character character) : base(character)
    {
    }

    public override void OnStateEnter()
    {
        character.input.SpacePressed += GoHome;
        nextDestination = GetRandomDestination();
        timer = 0f;
        character.GetComponent<Renderer>().material.color = Color.green;
    }

    public override void OnStateExit()
    {
        character.input.SpacePressed -= GoHome;
    }

    private Vector3 GetRandomDestination()
    {
        return new Vector3(
            UnityEngine.Random.Range(-40, 40),
            0f,
            UnityEngine.Random.Range(-40, 40)
            );
    }

    public override void Tick()
    {
        if (ReachedDestination())
        {
            nextDestination = GetRandomDestination();
        }

        character.characterMovement.MoveToward(nextDestination);

        timer += Time.deltaTime;
        if (timer >= wanderTime)
        {
            character.SetState(new ReturnHomeState(character));
        }
    }

    void GoHome()
    {
        character.SetState(new ReturnHomeState(character));
    }

    private bool ReachedDestination()
    {
        return Vector3.Distance(character.transform.position, nextDestination) < 0.5f;
    }

}
