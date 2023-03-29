using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TestUI : MonoBehaviour
{
    private Slider likeSlider;
    public TMP_Text likeText;
    private float like;
    void Start()
    {
        like = 0; //这是好感度所需收集的最小值，每个关卡再调整,后面所有的100记得调
        likeSlider = gameObject.GetComponent<Slider>();

    }

    
    void Update()
    {
        //这里我随便做了一个触发测试条件，到时候可以改
        if(Input.GetKeyDown(KeyCode.Space))
        {
            like += 5;
            if(like>= 100)
            {
                like = 100;
            }
            likeSlider.value = like / 100;
            likeText.text = like.ToString() + "/" + "100";
        }
    }
}
