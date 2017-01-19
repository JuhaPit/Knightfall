using UnityEngine;
using System.Collections;

public class FloatingTextController : MonoBehaviour {

    private static FloatingText popupText;
    private static GameObject canvas;

    public static void Initialize() {

        canvas = GameObject.Find("Canvas");
        if (!popupText)
        {
            popupText = Resources.Load<FloatingText>("UI/PopupTextParent");
        }
    }

    public static void CreateFloatingText(string text, Transform location) {

        FloatingText instance = Instantiate(popupText);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-.5f, .5f), location.position.y + Random.Range(-.5f, .5f)));
        instance.transform.SetParent(canvas.transform);
        instance.transform.position = screenPosition;
        instance.SetText(text);

    }
}
