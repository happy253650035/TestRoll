using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoll : MonoBehaviour
{
	public float rotateSpeed = 15;
	private float accRotate = -.05f;
	private float angleSpeed = 0;
	private Vector2 hitPoint2d;
	private Vector3 hitPoint3d;
	private Vector3 axis;
	// Use this for initialization
	void Start ()
	{
		angleSpeed = rotateSpeed;
		hitPoint2d = new Vector2(.5f, .5f);
		float length2 = hitPoint2d.sqrMagnitude;
		float z = -Mathf.Sqrt(1 - length2);
		hitPoint3d = new Vector3(hitPoint2d.x, hitPoint2d.y, z);
		axis = Vector3.Cross(new Vector3(hitPoint2d.x, hitPoint2d.y, 0), hitPoint3d).normalized;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (angleSpeed <= 0)
		{
			angleSpeed = 0;
		}
		else
		{
			angleSpeed += accRotate;
			accRotate -= .002f;
		}
		Debug.LogError("angleSpeed : " + angleSpeed);
		transform.localRotation = Quaternion.AngleAxis(-angleSpeed, axis) * transform.localRotation;
	}
}
