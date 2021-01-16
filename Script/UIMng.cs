using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMng : MonoBehaviour{
    public static UIMng uiMng;

    private GameObject cam, User;
    private RectTransform userRect;
    private float prevUserIconZ;

    private bool firstClick = true, islookFront = false;
    private Quaternion initCamRot = Quaternion.Euler(0,0,0);

    // Start is called before the first frame update
    void Start(){
        if(uiMng && uiMng != this)
            Destroy(uiMng);
        else
            uiMng = this;

        cam = GameObject.FindGameObjectWithTag("camera");

        User = GameObject.FindGameObjectWithTag("Player");
        userRect = User.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update(){
        turnUserIcon();

        if(islookFront && cam.transform.rotation != initCamRot){
            cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, initCamRot, Time.deltaTime * 30f);
        }else if(cam.transform.rotation == initCamRot){
            islookFront = false;
        }
    }

    public void setUserUILocation(Vector3 Coordinate){
        userRect.anchoredPosition = Coordinate;
    }

    public void lookFront(bool isSkip){
        if(!isSkip){
            islookFront = true;
        }else{
            cam.transform.rotation = Quaternion.Euler(0,0,0);
        }

        User.transform.rotation = Quaternion.Euler(0, 0, VideoProgressBar.VideoMng.getCurrentFront());
    }

    public void turnCorner(){
        float currentCamY = cam.transform.rotation.eulerAngles.y;
        User.transform.rotation = Quaternion.Euler(0, 0, VideoProgressBar.VideoMng.getCurrentFront()-currentCamY);
    }

    //Change User UI Rotation
    private void turnUserIcon(){
        if(Input.GetMouseButton(0)){
            if(firstClick){
                firstClick = false;
                prevUserIconZ = User.transform.rotation.eulerAngles.z;
            }
            float currentCamY = cam.transform.rotation.eulerAngles.y;
            User.transform.rotation = Quaternion.Euler(0, 0, VideoProgressBar.VideoMng.getCurrentFront()-currentCamY);
            return;

        }else{
            firstClick = true;
            float currentCamY = cam.transform.rotation.eulerAngles.y;
        }
    }
}
