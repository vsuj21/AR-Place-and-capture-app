using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CubePlacement : MonoBehaviour
{
    public GameObject cubePrefab;
    private ARRaycastManager arRaycastManager;
    private Vector2 touchposition;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject instantiatedCube;

    // The cube is instantiated from a prefab and placed at the position of the detected plane
    // If the user touches the screen again, the cube's position is updated to the new detected plane's position

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>(); // Get the ARRaycastManager component
    }

    // to detect touch and get touch position
    bool gettouchposition(out Vector2 touchposition)
    {
        if (Input.touchCount > 0)
        {
            touchposition = Input.GetTouch(0).position;
            return true;
        }
        touchposition = default;
        return false;
    }


    void Update()
    {
        // Check if the user is touching the screen
        if (!gettouchposition(out touchposition))
        {
            return;
        }

        // Check if the user's touch hits a detected AR plane
        if (arRaycastManager.Raycast(touchposition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose; // Get the pose (position and rotation) of the detected hit

            if (instantiatedCube == null)// If there's no instantiated cube
            {
                instantiatedCube = Instantiate(cubePrefab, pose.position, pose.rotation);// initiate cube and place it the hit position
            }
            else
            {
                Vector3 newPosition = pose.position;
                newPosition.y = pose.position.y + instantiatedCube.transform.localScale.y / 2; // Offset the cube's position by half of its height
                instantiatedCube.transform.position = newPosition; // Otherwise, update the position of the cube to the hit position
            }
        }
    }
}
