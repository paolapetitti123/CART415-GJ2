using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Texture2D DefaultCursorTexture;
    public Texture2D HoverCursorTexture;


    public CursorMode cursorModeVar = CursorMode.Auto;
    public Vector2 hotSpotMouse = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(DefaultCursorTexture, hotSpotMouse, cursorModeVar);
    }

    public void OnMouseOver()
    {
        Cursor.SetCursor(HoverCursorTexture, hotSpotMouse, cursorModeVar);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(DefaultCursorTexture, hotSpotMouse, cursorModeVar);
    }
}
