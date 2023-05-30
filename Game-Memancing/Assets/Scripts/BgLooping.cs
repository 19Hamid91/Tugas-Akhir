using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgLooping : MonoBehaviour
{
    public RawImage bgLoop;
    public float _x,_y;

    // Update is called once per frame
    void Update()
    {
        bgLoop.uvRect = new Rect(bgLoop.uvRect.position + new Vector2(_x,_y) * Time.deltaTime, bgLoop.uvRect.size);
    }
}
