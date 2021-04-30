using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{

    private bool mute = false;
    private AudioManager audioManager;
    private AudioSource[] audioSources;
    [SerializeField]
    private Image sound;

    private void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    public void ChangeState()
    {

        audioSources = audioManager.GetComponents<AudioSource>();
        
        if (!mute)
        {
            foreach (AudioSource audio in audioSources)
            {
                audio.mute = false;
            }
            mute = true;
            sound.sprite = Resources.Load<Sprite>("Sound/sound on");
        }
        else
        {
            foreach (AudioSource audio in audioSources)
            {
                audio.mute = true;
            }
            mute = false;
            sound.sprite = Resources.Load<Sprite>("Sound/sound off");
        }
    }
}
