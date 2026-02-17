using System.Linq;
using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public Transform InteractionPoint;
    public LayerMask InteractionLayer;
    public float InteractionPointRadius = 1f;
    public bool isInteracting { get; private set; }

    private void Update()
    {
        var colliders = Physics.OverlapSphere(InteractionPoint.position, InteractionPointRadius, InteractionLayer); // this line of code checks for colliders within a certain radius of the interaction point, and only considers those that are on the specified interaction layer.

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                var interactable = colliders[i].GetComponent<IInteractable>();

                if (interactable != null)
                {
                    StartInteraction(interactable);
                }
            }
        }
    }
    void StartInteraction(IInteractable interactable)
    {
        interactable.Interact(this, out bool interactSuccessful);
        isInteracting = true;
    }

    void EndInteraction()
    {
        isInteracting = false;
    }
}
