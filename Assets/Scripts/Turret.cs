using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [SerializeField] Transform yawSegment;
    [SerializeField] Transform pitchSegment;
	[SerializeField] Transform emitter;
    [SerializeField] float yawSpeed = 30f;
    [SerializeField] float pitchSpeed = 30f;
    [SerializeField] float yawLimit = 90f;
    [SerializeField] float pitchLimit = 90f;
    [SerializeField] float range = 200f;
    public Vector3 target;
    public GameObject[] objects;
    public GameObject[] targets;
    private Quaternion yawSegmentStartRotation;
    private Quaternion pitchSegmentStartRotation;

	// Use this for initialization
	void Start () {
	    yawSegmentStartRotation = yawSegment.localRotation;
	    pitchSegmentStartRotation = pitchSegment.localRotation;

	    objects = GameObject.FindGameObjectsWithTag("Target");
    }
	
	// Update is called once per frame
	void Update () {
		//Check that Target is within Radius of Turret
	    if (CheckRange())
		{
	        float angle;
	        Vector3 targetRelative;
	        Quaternion targetRotation;

	        /*if (pitchSegment && pitchLimit != 0f)
	        {
				//Translate pitch position from world to local co-ords
	            targetRelative = pitchSegment.InverseTransformPoint(target);
				//Find angle between Target and current pitch
	            angle = -Mathf.Atan2(targetRelative.y, targetRelative.z) * Mathf.Rad2Deg;
				//Compensate for angles higher than 180 and -180
	            if (angle >= 180f) angle = 180f - angle; 
				if (angle <= -180f) angle = -180f + angle;
				//Find new rotation
	            targetRotation = pitchSegment.rotation * Quaternion.Euler(Mathf.Clamp(angle, -pitchSpeed * Time.deltaTime, pitchSpeed * Time.deltaTime), 0f, 0f);
				//Apply rotation over time
	            if (pitchLimit < 360f && pitchLimit > 0f) pitchSegment.rotation = Quaternion.RotateTowards(pitchSegment.parent.rotation * pitchSegmentStartRotation, targetRotation, pitchLimit);
				//or set rotation
	            else pitchSegment.rotation = targetRotation;
	        }*/
			if (yawSegment && yawLimit != 0f)
			{
				//Translate yaw position from world to local co-ords
				targetRelative = yawSegment.InverseTransformPoint(target);
				//Find Angle between Target and current yaw
				angle = Mathf.Atan2(targetRelative.x, targetRelative.z) * Mathf.Rad2Deg;
				//If we're past 180 degrees between us and the target...
				if (angle >= 180f) angle = 180f - angle; //Compensate for the angle
				//If we're less than -180 degrees...
				if (angle <= -180f) angle = -180f + angle; //Compensate for the angle
				//Find rotation to where we're pointing...
				targetRotation = yawSegment.rotation * Quaternion.Euler(0f, Mathf.Clamp(angle, -yawSpeed * Time.deltaTime, yawSpeed * Time.deltaTime), 0f);
				//Rotate over time if within 360 and 0 degrees
				if (yawLimit < 360f && yawLimit > 0f) yawSegment.rotation = Quaternion.RotateTowards(yawSegment.parent.rotation * yawSegmentStartRotation, targetRotation, yawLimit);
				//Or just set new rotation
				else yawSegment.rotation = targetRotation;
			}
	        Debug.DrawLine(pitchSegment.position, target, Color.red);
	        Debug.DrawRay(pitchSegment.position, pitchSegment.forward * (target - pitchSegment.position).magnitude, Color.green);
			RaycastHit hit;
			if (Physics.Raycast(emitter.position, emitter.forward, out hit, range))
			{
				GameObject h = hit.collider.gameObject;
				if (h.tag == "Player"  || h.tag == "Clone") {
					Debug.Log ("OW! " + h.name);
					h.SetActive (false);
				}
			}
        }
    }

    private bool CheckRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, LayerMask.GetMask("Target"));
        if (hitColliders.Length == 0)
        {
            return false;
        }
        Array.Sort(hitColliders, CompareColliderPriority);
        target = hitColliders[0].GetComponent<TurretTarget>().getPosition().position;
        return true;
    }

    public void Target(Vector3 target)
    {
        this.target = target;
    }

    private int CompareColliderPriority(Collider x, Collider y)
    {
        if (x == null)
        {
            if (y == null)
            {
                // If x is null and y is null, they're
                // equal. 
                return 0;
            }
            else
            {
                // If x is null and y is not null, y
                // is greater. 
                return -1;
            }
        }
        else
        {
            // If x is not null...
            //
            if (y == null)
                // ...and y is null, x is greater.
            {
                return 1;
            }
            else
            {
                // ...and y is not null, compare the 
                // lengths of the two strings.
                //
                int retval = x.GetComponent<TurretTarget>().getPriority().CompareTo(y.GetComponent<TurretTarget>().getPriority());

                if (retval != 0)
                {
                    // If the strings are not of equal length,
                    // the longer string is greater.
                    //
                    return retval;
                }
                else
                {
                    // If the strings are of equal length,
                    // sort them with range from target.
					Vector3 xPos = x.ClosestPointOnBounds(pitchSegment.position);
					Vector3 yPos = y.ClosestPointOnBounds(pitchSegment.position);
					retval = Vector3.Distance(xPos, pitchSegment.position).CompareTo(Vector3.Distance(yPos, pitchSegment.position));
                    return retval;
                }
            }
        }
    }
}
