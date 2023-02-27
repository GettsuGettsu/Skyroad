using UnityEngine;
using UnityEngine.UI;

public class TextFadeController : MonoBehaviour
{
    private float alpha = 0f;
    private float colorVal;

    private void Start()
    {
        colorVal = GetComponent<Text>().color.r;
    }

    void Update()
    {
        alpha = ColorHelper.GetColorValue(alpha);
        GetComponent<Text>().color = new Color(colorVal, colorVal, colorVal, Mathf.Sin(alpha));
    }
}
