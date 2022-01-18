using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public GameObject tube01,box01,sphere01;
    public PlayableDirector playableDirector;
     
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPlay()
    {
        playableDirector.Play();
        box01.SetActive(true);
        sphere01.SetActive(true);
    }
    public void onPause()
    {
        playableDirector.Pause();
        var tubeMaterial=  tube01.GetComponent<Renderer>();
        tubeMaterial.material.SetColor("_Color", Color.black);
        box01.SetActive(false);
        sphere01.SetActive(false);
    }
}
