using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image_Capture : MonoBehaviour
{
    [SerializeField]
    Show_img showImg;
    bool takepic;
    private int frameCount;  // It uses the frameCount variable to capture an image every 10 frames


    // This method captures an image and shows it on the screen
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //this code can be used to capture image after every 10 frames without using button.
        /*frameCount++;
        if (frameCount >= 10)
        {
            takepic = true;
            frameCount = 0;
        }*/
        frameCount++;
        if (takepic)
        {
            takepic = false;
            var temprendtexture = RenderTexture.GetTemporary(source.width, source.height); // Create a temporary RenderTexture and copy the camera image into it
            Graphics.Blit(source,temprendtexture );

            // Create a Texture2D from the RenderTexture and show it on the screen

            Texture2D tempText = new Texture2D(source.width,source.height, TextureFormat.RGBA32,false);
            Rect rect = new Rect(0,0,source.width,source.height);
            tempText.ReadPixels(rect, 0, 0, false);
            tempText.Apply();
            showImg.openscreen(tempText);

            RenderTexture.ReleaseTemporary(temprendtexture); // Release the temporary RenderTexture

        }
        Graphics.Blit(source, destination);
    }
    public void captureimage() //trigger the image capture after 10 frames
    {
        if (frameCount >= 10)
        {
            takepic = true;
            frameCount = 0;
        }
    }
}
