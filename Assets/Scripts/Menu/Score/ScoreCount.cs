using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;

public class ScoreCount : MonoBehaviour
{

    [SerializeField] internal TextMeshProUGUI ScoreText;

    public float time;

    void Update()
    {
        time -= Time.deltaTime;
        if(time <=0)
        {
            ScoreManager.instance.score += 1;
            //time = timeStart;
        }
    }
}
