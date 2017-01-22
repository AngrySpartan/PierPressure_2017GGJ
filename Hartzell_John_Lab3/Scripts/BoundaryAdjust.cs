//------------------------------------------------------------------------------------------------
// Author: John Hartzell
// Date: 7/22/16
// Credit: PGF2_Experiment01 https://assethub.fso.fullsail.edu/assethub/PGF2_Comments_d9e9fe80-a238-40e9-9b3e-40646e6765cb.pdf
//
// Purpose: This script is used to adjust the horizontal boundaries when the camera size changes.
//

using UnityEngine;
using System.Collections;



public class BoundaryAdjust : MonoBehaviour {

    [Tooltip("Adjust this so that the boundaries are at the edge of the screen.")]
    [Range(-500,250)]
    [SerializeField]
    private int screenOffset;

    [SerializeField]
    [Tooltip("Is the boundary the left boundary?")]
    public bool leftBoundary = true;

    // place the main camera in this object. It will be needed to calculate where to put the boundaries.
    public Camera mainCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateBoundary();
	
	}

    private void UpdateBoundary()
    {
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(
            gameObject.transform.position);

        // Is the boundary the left, true, or right boundary?
        if (leftBoundary == false)
        {
            // Get the width of the screen and set the x position to the value.
            // This will result in the boundary being sent to the right side of the screen.
            // Adjust the offset so the boundary is at just the edge of the camera.
            screenPosition.x = Screen.width + screenOffset;
            // Set the boundary to that position.
            gameObject.transform.position =
                mainCamera.ScreenToWorldPoint(screenPosition);
        }
        else if (leftBoundary == true) 
        {
            // Set the x position to 0, the farthest left side of the screen.
            // This will result in the boundary being sent to the left side of the screen.
            // Adjust the offset so the boundary is at just the edge of the camera. 
            screenPosition.x = 0 - screenOffset;
            // Set the boundary to that position.
            gameObject.transform.position =
                mainCamera.ScreenToWorldPoint(screenPosition);
        }
    }
}
