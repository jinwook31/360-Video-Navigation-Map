using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class move : MonoBehaviour{
    public Material skybox1;
    public GameObject Video1;

    public GameObject map, user, view1, view2;

    void Start(){
        
        RenderSettings.skybox = skybox1;
        //start = user.GetComponent<RectTransform>().localPosition;
        //point = new Vector3(474, -311, 0);
        //difference = point - start;
    }

    // Update is called once per frame
    void Update(){
        /**
        //route2 start
        if(Video1.GetComponent<VideoPlayer>().isPaused){
            Video1.SetActive(false);
            Video2.SetActive(true);
            RenderSettings.skybox = skybox2;
            timer = 0;
            start = user.GetComponent<RectTransform>().localPosition;
        }
        **/
    }
}