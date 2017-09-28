using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 1f;

    public void MoveToward(Vector3 destination)
    {
        var direction = GetDirection(destination);
        transform.Translate(direction * Time.deltaTime * moveSpeed);
    }

    private Vector3 GetDirection(Vector3 destination)
    {
        return (destination - transform.position).normalized;
    }

}
