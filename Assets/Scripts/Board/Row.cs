using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Row : MonoBehaviour
{
    public float row;
    public RowIndicator rowIndicator;

    private float[] rowIndicatorPositions = { 24, 12, 0, -12 };

    public delegate void RowSelectedHandler(float row);
    public static event RowSelectedHandler RowSelected;

    private void OnMouseDown()
    {
        RowSelected?.Invoke(row);   
    }

    private void OnMouseEnter()
    {
        rowIndicator.UpdatePosition(rowIndicatorPositions[(int) row]);
    }
}
