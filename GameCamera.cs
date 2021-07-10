using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    private static float border = 0;

    /// <summary>
    /// Ширина экрана
    /// </summary>
    public static float Border
    {
        get
        {
            if (border == 0)
            {
                var cam = Camera.main;
                border = cam.aspect * cam.orthographicSize
                    - 0.5f;
            }
            return border;
        }
        private set { }
    }
}
