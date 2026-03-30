using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip energyDrinkClip;
    public AudioClip healingClip;
    public AudioClip swordClip;
    public AudioClip doorClip;
    public AudioClip takeDamageClip;

    public void EnergyDrinkSound()
    {
        audioSource.PlayOneShot(energyDrinkClip);
    }

    public void HealingSound()
    {
        audioSource.PlayOneShot(healingClip);
    }

    public void SwordSound()
    {
        audioSource.PlayOneShot(swordClip);
    }

    public void DoorSound()
    {
        audioSource.PlayOneShot(doorClip);
    }

    public void TakeDamageSound()
    {
        audioSource.PlayOneShot(takeDamageClip);
    }
}
    


    
        
    


