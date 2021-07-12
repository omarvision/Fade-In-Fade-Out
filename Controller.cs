using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for Image, Text

public class Controller : MonoBehaviour
{
    #region --- helper ---
    private enum Direction
    {
        NotDefined,
        FadeIn,
        FadeOut,
    }
    #endregion

    public Image Panel = null;
    public Image Hulk = null;
    public Text txtOpacity = null;
    public float FadeSpeed = 0.75f;
    private Color PanelColor;
    private Color HulkColor;
    private float mark;
    private Direction dir = Direction.NotDefined;

    private void Start()
    {
        PanelColor = Panel.color;
        HulkColor = Hulk.color;
    }
    private void Update()
    {
        switch (dir)
        {
            case Direction.FadeIn:
                mark += Time.deltaTime * FadeSpeed;
                PanelColor.a = Mathf.Lerp(1.0f, 0.0f, mark);
                Panel.color = PanelColor;
                HulkColor.a = Mathf.Lerp(1.0f, 0.0f, mark);
                Hulk.color = HulkColor;
                txtOpacity.text = PanelColor.a.ToString("0.00");
                break;

            case Direction.FadeOut:
                mark += Time.deltaTime * FadeSpeed;
                PanelColor.a = Mathf.Lerp(0.0f, 1.0f, mark);
                Panel.color = PanelColor;
                HulkColor.a = Mathf.Lerp(0.0f, 1.0f, mark);
                Hulk.color = HulkColor;
                txtOpacity.text = PanelColor.a.ToString("0.00");
                break;
        }
    }
    public void FadeOut()
    {
        mark = 0.0f;
        dir = Direction.FadeIn;
    }
    public void FadeIn()
    {
        mark = 0.0f;
        dir = Direction.FadeOut;
    }
}