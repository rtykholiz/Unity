using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TextControll : MonoBehaviour
{

    public TextMeshProUGUI txtMessage;
    public TextMeshProUGUI txtLerp;
    private List<string> textList = new List<string>();

    public float showmesstimer;
    void Start()
    {
        //головний текст €кий буде виводитись на екран
        txtMessage.text = "start text here";

        //ƒобавл€Їм текст в загальний список
        textList.Add("Hello 1");
        textList.Add("Hello 2");
        textList.Add("Hello 3");
        textList.Add("Hello 4");

        StartCoroutine(Textcoroutine());
    }

   
    IEnumerator Textcoroutine()
    {
        float a = 0.0f;
        float b = 1.8f;

        while (b > a)
        {
            a += Time.deltaTime;
            txtLerp.color = Color.Lerp(txtLerp.color, new Color(txtMessage.color.r, txtLerp.color.g, txtLerp.color.b, 0), b * Time.deltaTime);
            yield return null;
        }
       
        txtMessage.text = "start text here";

        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < textList.Count; i++)
        {
            txtMessage.text = textList[i];
            yield return new WaitForSeconds(showmesstimer);
        }
        txtMessage.text = "finish text here";
    }

}
