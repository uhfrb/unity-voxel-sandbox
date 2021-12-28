using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement movementControl;

    [SerializeField]
    private InputManager inputManager;
    void Awake()
    {
        List<IInputListener> activeListeners = new List<IInputListener>();
        activeListeners.Add(movementControl);
        inputManager.SetActiveInputs(activeListeners);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
