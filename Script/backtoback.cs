using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class backtoback : MonoBehaviour
{
    public Material skybox1;
    public Material skybox2;
    public Material skybox3;
    public GameObject Video1;
    public GameObject Video2;
    public GameObject Video3;
    public GameObject map;
    public GameObject user;
    public GameObject select;
    public GameObject Camera;

    public float percent;
    public float timer;
    public Vector3 point;
    public Vector3 difference;
    public Vector3 start;




    public List<VideoClip> videoClipList;
    public List<VideoPlayer> videoPlayerList;

    private bool selection_activate = false;
    private int video_id = 0;

    private bool isButtonActive = false;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = skybox1;
        start = user.GetComponent<RectTransform>().localPosition;
        point = new Vector3(-934, 446, 0);
        difference = point - start;

    }

    // Update is called once per frame
    void Update()
    {

        Video1.SetActive(true);
        //select.SetActive(false);
        map.SetActive(true);
        user.SetActive(true);

        
        if (Input.GetKeyDown(KeyCode.K)) Debug.Log(videoPlayerList[0].clip.length);

        //Debug.Log(user.GetComponent<RectTransform>().localPosition);
        //Debug.Log(videoPlayerList[0].time);

        if (timer <= 16f)
        {
            timer += Time.deltaTime;
            

            if(timer > 3f)
            {
                //Debug.Log(percent);
                percent = (timer - 3f) / 13f;
                user.GetComponent<RectTransform>().localPosition = start + difference * percent;
            }
  
            //percent = timer / 16f;
            //user.GetComponent<RectTransform>().localPosition = start + difference * percent;
            
           
        }

        
        //user.GetComponent<RectTransform>().localPosition += new Vector3(0f, 0.1f, 0f);


        if (videoPlayerList[video_id].time >= videoPlayerList[video_id].length -0.5f)
        {
          
            selection_activate = true;
            video_id++;
           // Debug.Log("asdf");
          
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    RenderSettings.skybox = skybox2;
        //}
        
        if (selection_activate) select.SetActive(true);
        else if (!selection_activate) select.SetActive(false);


 

        
    }

    public void testForButton1()
    {

        timer = 0;

        isButtonActive = true;
        selection_activate = false;
        user.GetComponent<Transform>().Rotate(new Vector3(0, 0, 90f));


        Video3.SetActive(true);
        RenderSettings.skybox = skybox3;
        Video3.GetComponent<VideoPlayer>().time += 5.0f;
        Video3.GetComponent<VideoPlayer>().Play();

        start = user.GetComponent<RectTransform>().localPosition;
        point = new Vector3(-1071, 446, 0);
        difference = point - start;


        if (timer <= 14f)
        {
            percent = timer / 14f;
            user.GetComponent<RectTransform>().localPosition = start + difference * percent;
        }

    }


    public void testForButton2()
    {
        selection_activate = false;

        Debug.Log(videoPlayerList[2].length);
        timer = 0;
        user.GetComponent<Transform>().Rotate(new Vector3(0, 0, -90f));
        Video3.GetComponent<VideoPlayer>().time += 5.0f;


        Video2.SetActive(true);
        RenderSettings.skybox = skybox2;
        Video2.GetComponent<VideoPlayer>().Play();



    }

}
