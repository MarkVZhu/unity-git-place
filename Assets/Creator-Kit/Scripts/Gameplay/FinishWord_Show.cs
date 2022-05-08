using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishWord_Show : MonoBehaviour
{
    public float charsPerSecond = 0.2f;//
    private string words;//
    private bool isActive = false;
    private float timer;//
    private Text myText;
    private int currentPos = 0;//
    private float lastTime;   //
    private float curTime;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        isActive = true;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);
        myText = GetComponent<Text>();
        words = myText.text;
        myText.text = "";
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        OnStartWriter();
      
    }

    void OnStartWriter()
    {

        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {
                timer = 0;
                currentPos++;
                myText.text = words.Substring(0, currentPos);
                if (currentPos >= words.Length)
                {
                    OnFinish();
                }
            }
        }

    }

    void OnFinish()
    {
        isActive = false;
        timer = 0;
        currentPos = 0;
        myText.text = words;
    }


}
