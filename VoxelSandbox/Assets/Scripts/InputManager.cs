using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private List<IInputListener> activeListeners;

    public void SetActiveInputs(List<IInputListener> il)
    {
        activeListeners = il;
    }

    void Update()
    {
        foreach (var il in activeListeners)
        {
            il.ProcessInput();
        }
    }
}