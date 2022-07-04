using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float x = 0;
    float y = 0;
    public Vector2 Movement(float pom)
    {

        if (pom >= 0 && pom < 90)
        {
            x = xMovement(pom);
            y = yMovement(pom);
        }

        if (pom >= 90 && pom < 180)
        {
            x = -yMovement(pom);
            y = xMovement(pom);
        }

        if (pom >= 180 && pom < 270)
        {
            x = -xMovement(pom);
            y = -yMovement(pom);
        }

        if (pom >= 270 && pom < 360)
        {
            x = yMovement(pom);
            y = -xMovement(pom);
        }


        return new Vector2(x,y);
    }

    private float xMovement(float pom)
    {
        return (90 - (pom % 90)) * 0.011f;
    }

    private float yMovement(float pom)
    {
        return (pom % 90) * 0.011f;
    }
}
