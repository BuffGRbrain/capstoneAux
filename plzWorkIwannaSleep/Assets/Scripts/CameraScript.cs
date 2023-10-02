using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    int currentCamIndex = 0;

    WebCamTexture tex;

    public RawImage display;
    
    public Text startStopText;

    public void SwapCam_Clicked(){
        
        if(WebCamTexture.devices.Length>0){
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;
            //If tex is not null then we have to stop the camera otherwise start the camera
        }

        if (tex!= null){
            StopWebCam();
            StartStopCam_Clicked();
        }
    }

    public void StartStopCam_Clicked(){

        if(tex != null) //if camera is already running
        {
            StopWebCam();
            startStopText.text = "Start Camera";
        }
        else
        { //if camera is not running it will start
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;
            tex.Play();
            startStopText.text = "Stop Camera";
        }

        
    }

    private void StopWebCam()
    {
        display.texture = null;
        tex.Stop();
        tex = null;
    }
}