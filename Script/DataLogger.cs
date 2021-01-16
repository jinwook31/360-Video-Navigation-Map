using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataLogger : MonoBehaviour{
    public static DataLogger dataLogger;
    private string fullPath;
    public string participantNum;
    private string m_strPath = "C:/Experiment/";
    private string startTime;

    private bool first = false;

    void Start(){
        if(dataLogger && dataLogger != this)
            Destroy(dataLogger);
        else
            dataLogger = this;
    }

    public void WriteData(string strData){
        if(!first){
            first = true;
            Timer.timer.startTimer();
            startTime = Timer.timer.currentTime4Filepath();
        }
        
        FileStream f = new FileStream( m_strPath  + startTime + "_" + participantNum + "_expData.txt", FileMode.Append, FileAccess.Write);
        StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);

        //Debug.Log(Timer.timer.getElapsedTime());
        string currentTime = Timer.timer.getElapsedTime().ToString();

        writer.WriteLine(currentTime+","+strData);
        writer.Close();
    }

    public void Parse(){
        TextAsset data = Resources.Load("Data", typeof(TextAsset)) as TextAsset;
        StringReader sr = new StringReader(data.text);

        // 먼저 한줄을 읽는다. 
        string source = sr.ReadLine();
        string [] values;                // 쉼표로 구분된 데이터들을 저장할 배열 (values[0]이면 첫번째 데이터 )

        while (source != null){
            values = source.Split(',');  // 쉼표로 구분한다. 저장시에 쉼표로 구분하여 저장하였다.
            if( values.Length == 0 ){
                sr.Close();
                return;
            }
           source = sr.ReadLine();    // 한줄 읽는다.
        }
    }
}
