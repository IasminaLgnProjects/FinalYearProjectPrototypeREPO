using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlurFade : MonoBehaviour
{
    Image img;
    float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //img.color = new Color(img.color.r, img.color.b, img.color.g, img.color.a - speed * Time.deltaTime);
    }
}
