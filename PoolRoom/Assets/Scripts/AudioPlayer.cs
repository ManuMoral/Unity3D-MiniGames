using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioPlayer : MonoBehaviour
{
    public bool playing = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ToggleMusic()
    {
        //if (playing == false)
        //if (playing != true)
        if (!playing)
        {
            // Acceder a la cámara
            GameObject camera = GameObject.Find("Main Camera");
            camera.GetComponent<AudioSource>().Play();

            // Cambiar el texto del botón
            TMP_Text myText = GameObject.Find("Canvas/Button/Text").GetComponent<TMP_Text>();
            myText.text = "Stop Music";

            // Cambiar el estilo de fuente
            //myText.fontStyle = ... ;

            playing = true;
        }
        else
        {
            GameObject camera = GameObject.Find("Main Camera");
            camera.GetComponent<AudioSource>().Stop();

            TMP_Text myText = GameObject.Find("Canvas/Button/Text").GetComponent<TMP_Text>();
            myText.text = "Play Music";

            playing = false;
        }
    }
}
