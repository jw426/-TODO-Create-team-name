using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField] AudioSource doorOpen;
    [SerializeField] AudioSource doorClose;
    [SerializeField] AudioSource footsteps;
    [SerializeField] AudioSource cashRegister;

    [SerializeField] float timer;
    float time = 0f;

    public void SubmitOrder() 
    {
        cashRegister.Play();
    }

    private void Start()
    {
        Footsteps();
    }


    private void Update()
    {
        Footsteps();
    }


    public void DoorOpen()
    {
        doorOpen.Play();
    }

    public void DoorClose()
    {
        doorClose.Play();
    }

    public void Footsteps()
    {
        footsteps.loop = true;
        if (!doorOpen.isPlaying)
        {
            footsteps.Play();
            while (time < timer)
            {
                time++;
            }

            if (footsteps.isPlaying)
            {
                footsteps.Stop();
            }

            

        }
        
    }

}