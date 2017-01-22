
//------------------------------------------------------------------------------------------------
// Author: John Hartzell
// Date: 7/22/16
// Credit: PGF2_Experiment01 https://assethub.fso.fullsail.edu/assethub/PGF2_Comments_d9e9fe80-a238-40e9-9b3e-40646e6765cb.pdf
// Credit: The camera shake methods I use are inspired by the example given on this site:
// http://newbquest.com/2014/06/the-art-of-screenshake-with-unity-2d-script/
// The code on the site was inspired by a presentation given by one of the developers of nuclear throne.
// The author of the blog post is Matt Mirrorfish. The author credits these posts partially with the creation of 
// the example code they provide: http://answers.unity3d.com/questions/220407/damaging-a-car-depending-on-force-of-impact.html
// http://answers.unity3d.com/questions/46317/screen-shake-effect.html?sort=oldest
//
// Purpose: This script is suppose to wrap the player around to the other side of the screen
// when they exit out a horizontal boundary. This script also produces camera shake when the player touches the 
// horizontal boundaries.
//

using UnityEngine;
using System.Collections;


public class PlayerScreenWrap : MonoBehaviour
{
    // Is this the left boundary?
    [Tooltip("Is this the left boundary?")]
    [SerializeField]
    bool isLeft = false;

    [Tooltip("Adjust the camera shake amount.")]
    [Range(0, 0.1f)]
    [SerializeField]
    float shakeModifier = 0.1f;

    private float tempShakeModifier = 0.0f;

    // Used to determine screen bounds in relation to the player object.
    public Camera cameraObject;

    private Vector3 cameraPosition;

    public void Start()
    {
        tempShakeModifier = shakeModifier;
        cameraPosition = cameraObject.transform.position;
        
    }

    // When the player enters the boundary, which is positioned just off screen.
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            // Transform the 3D world position to a screen pixel location
            Vector3 screenPosition = cameraObject.WorldToScreenPoint(
                other.gameObject.transform.position);

            if (isLeft == true)
            {
                // set to the screen's right side
                screenPosition.x = Screen.width - 15;
                // set the players new position
                other.gameObject.transform.position =
                cameraObject.ScreenToWorldPoint(screenPosition);

            }
            else
            {
                // set to the screen's left side
                screenPosition.x = 0 + 15;
                // set the players new position
                other.gameObject.transform.position =
                cameraObject.ScreenToWorldPoint(screenPosition);

            }
            // invoke the camera to start shaking every .01 seconds.
            // invoke stop camera shake after .3 seconds.
            InvokeRepeating("StartCameraShake", 0.0f, 0.005f);
            Invoke("StopCameraShake", 0.3f);

        }
    }

    // shakes the camera
    void StartCameraShake()
    {
        // randomly choose between 1 (inclusive) and 5 (exclusive). This will determine which
        // direction the camera will shake in.
        int randNum = Random.Range(1,5);

        // if the shake modifier is greater than 0.
        if(shakeModifier > 0)
        {
            // the offset generation formula. 
            shakeModifier = Random.value * shakeModifier * 2 - shakeModifier;

            // set the temporary position to the camera's current position.
            Vector3 tempCameraPosition = cameraObject.transform.position;

            //shake the camera by applying the offset. The number randomly generated above 
            // determines the direction of the shake.
            if (randNum == 1) {
                //shake the camera by applying the offset.
                tempCameraPosition.y += shakeModifier;
                tempCameraPosition.x -= shakeModifier;

                cameraObject.transform.position = tempCameraPosition;
            }
            else if (randNum == 2)
            {
                //shake the camera by applying the offset.
                tempCameraPosition.y -= shakeModifier;
                tempCameraPosition.x += shakeModifier;

                cameraObject.transform.position = tempCameraPosition;
            }
            else if(randNum == 3)
            {
                //shake the camera by applying the offset.
                tempCameraPosition.y -= shakeModifier;
                tempCameraPosition.x -= shakeModifier;

                cameraObject.transform.position = tempCameraPosition;
            }
            else
            {
                //shake the camera by applying the offset.
                tempCameraPosition.y += shakeModifier;
                tempCameraPosition.x += shakeModifier;

                cameraObject.transform.position = tempCameraPosition;
            }
        }
    }

    void StopCameraShake()
    {
        //cancel the camera shake and return the camera to its normal position.
        CancelInvoke("StartCameraShake");
        cameraObject.transform.position = cameraPosition;

        //reset the shake modifier so that the camera will properly shake again.
        shakeModifier = tempShakeModifier;
    }
}
