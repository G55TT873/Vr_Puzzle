using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]
public class XRSocketTagInteractor : XRSocketInteractor
{
    [Tooltip("Only objects with this tag can be snapped into this socket.")]
    public string targetTag;

    [Tooltip("Sound to play when an object is successfully snapped in.")]
    public AudioClip placementSound;

    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) &&
               interactable.transform.CompareTag(targetTag);
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) &&
               interactable.transform.CompareTag(targetTag);
    }

    // ⚠️ Access modifier changed to 'protected'
    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        base.OnSelectEntered(interactable);

        // Play the placement sound
        if (placementSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(placementSound);
        }
    }
}
