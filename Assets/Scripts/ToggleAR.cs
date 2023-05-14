using UnityEngine;
using UnityEngine.XR.ARFoundation;


// This script toggles the visualization of AR planes and point clouds
// It requires the ARPlaneManager and ARPointCloudManager components to be set in the inspector
public class ToggleAR : MonoBehaviour
{

    public ARPlaneManager planeManager;
    public ARPointCloudManager pointCloudManager;



    public void OnValueChanged(bool isOn)// Called when the toggle is switched on or off
    {
        VisualizePlanes(isOn);
        VisualizePoints(isOn);
    }

    void VisualizePlanes(bool active) // Helper method to toggle the visibility of AR planes
    {
        planeManager.enabled = active;
        foreach (ARPlane plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(active);
        }
    }

    void VisualizePoints(bool active) // Helper method to toggle the visibility of AR point clouds
    {
        pointCloudManager.enabled = active;
        foreach (ARPointCloud pointCLoud in pointCloudManager.trackables)
        {
            pointCLoud.gameObject.SetActive(active);
        }
    }
}