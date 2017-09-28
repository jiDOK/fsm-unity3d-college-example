using UnityEngine;

public class ReturnHomeState : State
{

    private Vector3 destination;

    public ReturnHomeState(Character character) : base(character)
    {
    }

    public override void Tick()
    {
        character.characterMovement.MoveToward(destination);

        if (ReachedHome())
        {
            character.SetState(new WanderState(character));
        }
    }

    public override void OnStateEnter()
    {
        destination = character.home;
        character.GetComponent<Renderer>().material.color = Color.blue;
    }

    public override void OnStateExit()
    {
        Debug.Log("Exited ReturnHomeState");
    }

    private bool ReachedHome()
    {
        return Vector3.Distance(character.transform.position, destination) < 0.1f;
    }

}
