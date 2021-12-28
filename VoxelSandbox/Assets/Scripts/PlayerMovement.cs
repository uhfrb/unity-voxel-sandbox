using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IInputListener
{
    private float targetSpeedX, targetSpeedY, targetSpeedZ = 0.0f;
    private float currentSpeedX, currentSpeedY, currentSpeedZ = 0.0f;
    private float initialSpeedX, initialSpeedY, initialSpeedZ = 0.0f;

    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float glideTime;

    private float currentGlideX, currentGlideY, currentGlideZ = 0.0f;

    public void ProcessInput()
    {
        // Forward-backward motion
        if (Input.GetKeyDown("w"))
        {
            targetSpeedZ += 1.0f;
            currentGlideZ = 0.0f;
            initialSpeedZ = currentSpeedZ;
        }
        else if (Input.GetKeyUp("w"))
        {
            targetSpeedZ -= 1.0f;
            currentGlideZ = 0.0f;
            initialSpeedZ = currentSpeedZ;
        }

        if (Input.GetKeyDown("s"))
        {
            targetSpeedZ += -1.0f;
            currentGlideZ = 0.0f;
            initialSpeedZ = currentSpeedZ;
        }
        else if (Input.GetKeyUp("s"))
        {
            targetSpeedZ -= -1.0f;
            currentGlideZ = 0.0f;
            initialSpeedZ = currentSpeedZ;
        }

        // Left-right motion
        if (Input.GetKeyDown("a"))
        {
            targetSpeedX += -1.0f;
            currentGlideX = 0.0f;
            initialSpeedX = currentSpeedX;
        }
        else if (Input.GetKeyUp("a"))
        {
            targetSpeedX -= -1.0f;
            currentGlideX = 0.0f;
            initialSpeedX = currentSpeedX;
        }

        if (Input.GetKeyDown("d"))
        {
            targetSpeedX += 1.0f;
            currentGlideX = 0.0f;
            initialSpeedX = currentSpeedX;
        }
        else if (Input.GetKeyUp("d"))
        {
            targetSpeedX -= 1.0f;
            currentGlideX = 0.0f;
            initialSpeedX = currentSpeedX;
        }

        // Up-down motion
        if (Input.GetKeyDown(KeyCode.Space))
        {
            targetSpeedY += 1.0f;
            currentGlideY = 0.0f;
            initialSpeedY = currentSpeedY;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            targetSpeedY -= 1.0f;
            currentGlideY = 0.0f;
            initialSpeedY = currentSpeedY;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            targetSpeedY += -1.0f;
            currentGlideY = 0.0f;
            initialSpeedY = currentSpeedY;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            targetSpeedY -= -1.0f;
            currentGlideY = 0.0f;
            initialSpeedY = currentSpeedY;
        }
    }

    void Update()
    {
        currentGlideX = Mathf.Min(currentGlideX + Time.deltaTime, glideTime);
        currentGlideY = Mathf.Min(currentGlideY + Time.deltaTime, glideTime);
        currentGlideZ = Mathf.Min(currentGlideZ + Time.deltaTime, glideTime);

        currentSpeedX = Mathf.Lerp(initialSpeedX, targetSpeedX, currentGlideX / glideTime);
        currentSpeedY = Mathf.Lerp(initialSpeedY, targetSpeedY, currentGlideY / glideTime);
        currentSpeedZ = Mathf.Lerp(initialSpeedZ, targetSpeedZ, currentGlideZ / glideTime);
        Vector3 compoundMotion = maxSpeed * new Vector3(currentSpeedX, currentSpeedY, currentSpeedZ);
        print("speed (i,c,t) (forward axis): " + new Vector3(initialSpeedZ, currentSpeedZ, targetSpeedZ));
        print("motion: " + compoundMotion);
        transform.Translate(compoundMotion * Time.deltaTime);
    }
}
