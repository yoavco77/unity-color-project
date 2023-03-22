using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorHandler : MonoBehaviour
{
    private Color currentColor = Color.white;


    public void setColor(Color color)
    {
        currentColor = color;
    }

    public Color getColor()
    {
        return currentColor;
    }

}
