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
        like = 0; //���Ǻøж������ռ�����Сֵ��ÿ���ؿ��ٵ���,�������е�100�ǵõ�
        likeSlider = gameObject.GetComponent<Slider>();

    }

    
    void Update()
    {
        //�������������һ������������������ʱ����Ը�
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
