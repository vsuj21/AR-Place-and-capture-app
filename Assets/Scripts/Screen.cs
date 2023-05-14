using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script controls the behavior of a screen UI element in the scene
// It requires a CanvasGroup component to be attached to the same GameObject as this script

[RequireComponent(typeof(CanvasGroup))]
public class Screen : MonoBehaviour
{
    CanvasGroup canvasGroup;

    protected virtual void Start()
    {
         canvasGroup = GetComponent<CanvasGroup>();
    }

    protected void Setscreen(bool open)// Show or hide the screen based on a boolean input parameter
    {
        canvasGroup.interactable = open;
        canvasGroup.blocksRaycasts = open;
        canvasGroup.alpha = open ? 1 : 0;  // Set the alpha value to 1 if the screen is open, otherwise 0
    }

}
