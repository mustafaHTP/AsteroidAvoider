using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public readonly struct Border
{
    public readonly float Left;
    public readonly float Right;
    public readonly float Top;
    public readonly float Bottom;

    public Border(float left, float right, float top, float bottom)
    {
        Left = left;
        Right = right;
        Top = top;
        Bottom = bottom;
    }
}
