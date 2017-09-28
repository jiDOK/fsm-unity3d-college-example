using System;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{

    public event Action SpacePressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SpacePressed != null)
            {
                SpacePressed();
            }
        }
    }

}
