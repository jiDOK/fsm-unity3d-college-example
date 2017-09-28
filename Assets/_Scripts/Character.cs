using UnityEngine;

public class Character : MonoBehaviour
{

    public CharacterInput input;

    [SerializeField]
    CharacterMovement _characterMovement;
    State currentState;
    Vector3 _home;

    public CharacterMovement characterMovement
    {
        get { return _characterMovement; }
    }

    public Vector3 home
    {
        get { return _home; }
    }



    void Awake()
    {
        _home = transform.position;
        _characterMovement = GetComponent<CharacterMovement>();
    }

    private void Start()
    {
        SetState(new ReturnHomeState(this));
    }

    private void Update()
    {
        currentState.Tick();
    }

    public void SetState(State state)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;

        if (currentState != null)
            currentState.OnStateEnter();
    }

}
