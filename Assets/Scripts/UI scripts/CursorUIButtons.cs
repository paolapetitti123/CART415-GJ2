using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUIButtons : MonoBehaviour
{
    public Texture2D cursor_normal;
    public Vector2 normalCursorHotSpot;

    public Texture2D cursor_OnHover;
    public Vector2 onHoverCursorHotSpot;



    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursor_OnHover, onHoverCursorHotSpot, CursorMode.Auto);
    }

    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursor_normal, normalCursorHotSpot, CursorMode.Auto);
    }
}
