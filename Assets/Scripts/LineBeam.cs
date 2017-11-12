using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBeam : MonoBehaviour {

    [SerializeField] float maxLength = 100f;
    [SerializeField] bool requireRaycastHit = false;
    private LineRenderer lineRenderer;
    private float closestPoint;

	// Use this for initialization
	void Start () {
	    lineRenderer = GetComponent<LineRenderer>();
	    if (!lineRenderer)
	    {
	        Debug.LogWarning("The 'LineBeam' script on " + gameObject.name + " requires a line renderer! Deactivating.");
            this.enabled = false;
	    }
	    lineRenderer.positionCount = 2;
	    lineRenderer.useWorldSpace = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if (!lineRenderer) Start();
	    if (requireRaycastHit) lineRenderer.enabled = Physics.Raycast(transform.position, transform.forward, maxLength);
	    if (!lineRenderer.enabled) return;
	    //lineRenderer.SetPosition(0, transform.position);
	    closestPoint = maxLength;
	    foreach (var hit in Physics.RaycastAll(transform.position, transform.forward, maxLength))
	    {
	        if ((hit.point - transform.position).sqrMagnitude < closestPoint * closestPoint)
	            closestPoint = (hit.point - transform.position).magnitude;
	    }
	    lineRenderer.SetPosition(1, Vector3.forward * closestPoint);
    }
}
