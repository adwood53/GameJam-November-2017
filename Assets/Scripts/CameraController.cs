using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float targetDistance = 0.5F;
    public float smoothTime = 10;
    public Transform target;

    private float distance = 1F;

    Transform temptarget = null;

    void LateUpdate()
    {

        //transform.LookAt(target);

        distance = transform.position.z - target.position.z;


        /*// reset if its too far away
        if (distance > targetDistance)
        {
            transform.position = target.position - transform.forward;
        }
        else
        {*/

        float newZ = 0;

        if (distance > targetDistance)
        {
            newZ = transform.position.z - (transform.forward.z + targetDistance);
        }
        else
        {
            // if distance isnt big enough to move the target we still need to adjust the y height every frame
            newZ = transform.position.z;
        }

        transform.position = new Vector3(
            target.position.x - transform.forward.x,
            target.position.y,
            newZ
        );
        //}

    }
}
