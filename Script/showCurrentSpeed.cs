using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showCurrentSpeed : MonoBehaviour{
    public static showCurrentSpeed speedTxtMng;
    private float speed, prevSpeed, alpha;
    private bool changed = false, btnEvent = false;

    private RawImage speedTxtImg;
    public Texture2D[] speedImgs;

    // Start is called before the first frame update
    void Start(){
        if(speedTxtMng && speedTxtMng != this)
            Destroy(speedTxtMng);
        else
            speedTxtMng = this;

        speedTxtImg = GetComponent<RawImage>();
        prevSpeed = 1.0f;

        alpha = 0;
    }

    // Update is called once per frame
    void Update(){
        if(btnEvent){
            changed = true;
            btnEvent = false;

            if(speed == 1.0f)
                speedTxtImg.texture = speedImgs[1];
            else if(speed == 2.0f)
                speedTxtImg.texture = speedImgs[3];
            else if(speed == 1.5f)
                speedTxtImg.texture = speedImgs[2];
            else
                speedTxtImg.texture = speedImgs[0];

            //이부분 수정...아래
            //speedTxtImg.CrossFadeAlpha(255.0f, 0.5f, false);
            alpha = 255;
            speedTxtImg.color = new Color(speedTxtImg.color.r, speedTxtImg.color.g, speedTxtImg.color.b, alpha);
        }

        if(alpha != 0){
            float fadespeed = 10.0f;
            alpha = Mathf.Lerp(alpha, 0, fadespeed * Time.deltaTime);
            speedTxtImg.color = new Color(speedTxtImg.color.r, speedTxtImg.color.g, speedTxtImg.color.b, alpha);
        }


    }

    public void isChanged(float speed){
        btnEvent = true;
        this.speed = speed;
    }
}
