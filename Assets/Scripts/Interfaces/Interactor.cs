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
        // Use 2D physics overlap since your colliders are 2D BoxCollider2D
        Collider2D[] colliders = Physics2D.OverlapCircleAll(InteractionPoint.position,InteractionPointRadius, InteractionLayer.value);

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (colliders.Length == 0) 
            {
                return;
            }
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
