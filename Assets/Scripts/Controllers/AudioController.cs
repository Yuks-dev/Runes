using UnityEngine;

public class AudioController : Element
{
    public AudioSource mainMusic;

    public AudioClip openRune;
    public AudioClip tapChest;
    public AudioClip[] tapRune;
    public AudioClip transition;
    public AudioClip rotate;
    public AudioClip portal;
    public AudioClip done;
    public AudioClip count;

    private AudioSource aud;

    private void Awake() => aud = GetComponent<AudioSource>();

    public void OpenSound() => aud.PlayOneShot(openRune);
    public void ChestSound() => aud.PlayOneShot(tapChest);
    public void TransitionSound() => aud.PlayOneShot(transition);
    public void RotateSound() => aud.PlayOneShot(rotate);
    public void PortalSound() => aud.PlayOneShot(portal);
    public void DoneSound() => aud.PlayOneShot(done);
    public void CountSound() => aud.PlayOneShot(count);

    public void Mute(bool value) => mainMusic.mute = value;

    public void RuneSound()
    {
        int rnd = Random.Range(0, 5);
        aud.PlayOneShot(tapRune[rnd]);
    }
}
