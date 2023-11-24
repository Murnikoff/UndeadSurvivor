using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, EaseExp, Level, Kill, Time, Health, EaseHealth };
    public InfoType type;

    Text myText;
    Slider mySlider;

    private void Awake()
    {
        mySlider = GetComponent<Slider>();
        myText = GetComponent<Text>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[GameManager.instance.level];
                mySlider.value = Mathf.Lerp(mySlider.value, curExp / maxExp, 0.005f);
                break;

            case InfoType.EaseExp:
                float curEaseExp = GameManager.instance.exp;
                float maxEaseExp = GameManager.instance.nextExp[GameManager.instance.level];
                mySlider.value = curEaseExp / maxEaseExp;
                break;

            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}", GameManager.instance.level);
                break;

            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManager.instance.kill);
                break;

            case InfoType.Time:
                float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;

            case InfoType.Health:
                float curHealth = GameManager.instance.health;
                float maxHealth = GameManager.instance.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;

            case InfoType.EaseHealth:
                float curEaseHealth = GameManager.instance.health;
                float maxEaseHealth = GameManager.instance.maxHealth;
                mySlider.value = Mathf.Lerp(mySlider.value, curEaseHealth / maxEaseHealth, 0.005f);
                break;

        }
    }

}
