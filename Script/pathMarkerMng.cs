using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathMarkerMng : MonoBehaviour
{
    public static pathMarkerMng pathMng;
    private GameObject path1, path2, path3;
    // Start is called before the first frame update
    void Start()
    {
        if(pathMng && pathMng != this)
            Destroy(pathMng);
        else
            pathMng = this;

        path1 = GameObject.FindGameObjectWithTag("path1");
        path1.SetActive(false);

        path2 = GameObject.FindGameObjectWithTag("path2");
        path1.SetActive(false);

        path3 = GameObject.FindGameObjectWithTag("path3");
        path1.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if(VideoProgressBar.VideoMng.getVideoStatus()){
            path1.SetActive(false);
            path2.SetActive(false);
            path3.SetActive(false);
            return;
        }
    }

    public void showPathMarker(float current){       
        if(current == 20){
            path1.SetActive(true);
        }else if(current == 41){
            path2.SetActive(true);
        }else if(current == 69){
            path3.SetActive(true);
        }
    }
}
