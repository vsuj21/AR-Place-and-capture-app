using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_img : Screen

{
    [SerializeField]
    RawImage mediaImage;


    // Call the base Start method and hide the screen when the script starts
    protected override void Start()
    {
        base.Start();
        closescreen();
    }


    // Show the screen and set the texture of the RawImage to the provided texture
    public void openscreen(Texture imageText)
    {
        mediaImage.texture = imageText;
        Setscreen(true);
    }
    public void closescreen() // Hide the screen
    {
        Setscreen(false);
    }
}
