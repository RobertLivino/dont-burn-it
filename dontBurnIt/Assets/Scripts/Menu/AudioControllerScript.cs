using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerScript : MonoBehaviour
{
    public AudioSource audiosourceMusicaFundo;
    public AudioSource audioSourceFX;
    public AudioClip[] musicasDeFundo;
    // Start is called before the first frame update
    void Start()
    {
        //int IndexDaMusicaDeFundo = Random.Range(0, musicasDeFundo.Length);
        //AudioClip musicaDeFundoDessaFase = musicasDeFundo[IndexDaMusicaDeFundo];
        AudioClip musicaDeFundoDessaFase = musicasDeFundo[0];
        audiosourceMusicaFundo.clip = musicaDeFundoDessaFase;
        audiosourceMusicaFundo.loop = true;
        audiosourceMusicaFundo.Play();
    }

    public void ToqueSFX(AudioClip clip)
    {

    }

    // Update is called once per frame
    void Update()
    { 
        //audioSourceSFX.PlayOneShot(clip);
        //audioSourceSFX.clip = musicaDeFundoDessaFase;  
        //audioSourceSFX.Play();
    }
}
