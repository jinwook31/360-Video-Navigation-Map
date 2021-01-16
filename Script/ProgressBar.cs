using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=J1ng1zA3-Pk
[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour, IPointerDownHandler {
    public float minimum, maximum, current, prevFillAmount = 0;
    public Image mask;

    private GameObject prgVideo, User;
    private RectTransform userRect;
    private Image videoProgress;    //Video progress

    private Image progress;
    private bool rootEnd = false;

    void Start(){
        prgVideo = GameObject.FindGameObjectWithTag("videoProgress");
        videoProgress = prgVideo.GetComponent<Image>();

        current = 0;
        progress = GetComponent<Image>();

        User = GameObject.FindGameObjectWithTag("Player");
        userRect = User.GetComponent<RectTransform>();
    }

    void Update(){
        current = (int)(videoProgress.fillAmount * 100);
        GetCurrentFill();
        isChanging();

        isCrossroads();
    }

    private void TrySkip(PointerEventData eventData){
        Vector2 localPoint;
        float pct = 0;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(progress.rectTransform, eventData.position, null, out localPoint)){
            pct = Mathf.InverseLerp(progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax, localPoint.x);
            float barProg = ((maximum-minimum) * pct) + minimum;
            prgVideo.GetComponent<VideoProgressBar>().SkipToPercent(barProg / 100);
        }

        DataLogger.dataLogger.WriteData("MapLog," + VideoProgressBar.VideoMng.getCurrentPct());
    }

    //비율에 맞게 Fill 조정
    void GetCurrentFill(){
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;
    }

    private void isCrossroads(){
        if((current == 20 || current == 41 || current == 69 || current == 26 || current == 48 || current == 77 || current == 100) && !rootEnd){
            VideoProgressBar.VideoMng.pauseVideo();
            UIMng.uiMng.lookFront(false);
            pathMarkerMng.pathMng.showPathMarker(current);
            rootEnd = true;
            return;
        }

        if(rootEnd && VideoProgressBar.VideoMng.getVideoStatus() && (current != 20 && current != 41 && current != 69 )){
            rootEnd = false;
        }
    }

    private void isChanging(){
        if(prevFillAmount != mask.fillAmount && current >= minimum && current <= maximum){
            RectTransform bar = GetComponent<RectTransform>();

            float centerX = bar.anchoredPosition.x, centerY = bar.anchoredPosition.y;
            float barRot = bar.eulerAngles.z;

            if(barRot == 0)
                UIMng.uiMng.setUserUILocation(new Vector3(Mathf.Lerp(centerX - (bar.rect.width/2), centerX + (bar.rect.width/2), mask.fillAmount), centerY, 0));
            else if(barRot == 180)
                UIMng.uiMng.setUserUILocation(new Vector3(Mathf.Lerp(centerX - (bar.rect.width/2), centerX + (bar.rect.width/2), 1 - mask.fillAmount), centerY, 0));
            else if(barRot == 90)
                UIMng.uiMng.setUserUILocation(new Vector3(centerX, Mathf.Lerp(centerY - (bar.rect.width/2), centerY + (bar.rect.width/2), mask.fillAmount), 0));
            else
                UIMng.uiMng.setUserUILocation(new Vector3(centerX, Mathf.Lerp(centerY - (bar.rect.width/2), centerY + (bar.rect.width/2), 1 - mask.fillAmount), 0));

            VideoProgressBar.VideoMng.setCurrentFront((int)(bar.eulerAngles.z - 90));
        }

        if(prevFillAmount != mask.fillAmount && prevFillAmount == 0)
            UIMng.uiMng.turnCorner();
        
        prevFillAmount = mask.fillAmount;
    }

    public void OnPointerDown(PointerEventData eventData){
        TrySkip(eventData);
        isChanging();

        UIMng.uiMng.lookFront(true);

        if(rootEnd){
            VideoProgressBar.VideoMng.playVideo();
        }
    }
}
