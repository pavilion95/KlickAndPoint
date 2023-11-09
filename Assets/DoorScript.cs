using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
	public Animator doorAnimator; // Assign this in the inspector
	private bool isDoorOpen = false; // Track whether the door is open or not

	void Start()
	{
		if (doorAnimator == null)
		{
			doorAnimator = GetComponent<Animator>();
		}
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform == transform)
				{
					// Toggle the door state
					isDoorOpen = !isDoorOpen;

					// Trigger the appropriate animation based on the door state
					doorAnimator.SetBool("IsOpen", isDoorOpen);
				}
			}
		}
	}
}
