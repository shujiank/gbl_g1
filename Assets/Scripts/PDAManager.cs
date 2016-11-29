using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class PDAValuesUI
{
    public Text destination_x;
    public Text destination_y;
    public Text current_x;
    public Text current_y;
    public Text vector_1_x;
    public Text vector_1_y;
    public Text vector_2_x;
    public Text vector_2_y;
    public Text equation_v1;
    public Text equation_v2;
    public Text fuel;
}

public class PDAManager : MonoBehaviour
{
    public PDAValuesUI pda_values_ui;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void updateCurrentPosition(float x, float y)
    {
        pda_values_ui.current_x.text = (Math.Round(x - 0.5f, 2)).ToString();
        pda_values_ui.current_y.text = (Math.Round(y - 0.5f, 2)).ToString();
    }

    public void updateDestination(float x, float y)
    {
        pda_values_ui.destination_x.text = (x).ToString();
        pda_values_ui.destination_y.text = (y).ToString();
    }

    public void updateVector1(float x, float y)
    {
        pda_values_ui.vector_1_x.text = (x).ToString();
        pda_values_ui.vector_1_y.text = (y).ToString();
    }

    public void updateFuel(float f)
    {
        pda_values_ui.fuel.text = (f).ToString() + " %";
    }

    public void updateVector2(float x, float y)
    {
        pda_values_ui.vector_2_x.text = (x).ToString();
        pda_values_ui.vector_2_y.text = (y).ToString();
    }

    public void updateVectorEquation(float x, float y)
    {
        pda_values_ui.equation_v1.text = (x).ToString() + " v1 + " + (y).ToString() + " v2";
    }
}
