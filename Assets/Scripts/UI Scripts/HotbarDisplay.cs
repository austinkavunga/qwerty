using UnityEngine;
using UnityEngine.InputSystem;  

public class HotbarDisplay : StaticInventoryDisplay 
{
    private int maxIndexSize = 9;
    private int currentIndex = 0;
    private PlayerControls playerControls;
    public Animator myAnimator;
    public GameObject sword;
    public PlayerSprint playerSprint;
    public Interactor playerInteractor;
    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    protected override void Start()
    {
        base.Start();

        currentIndex = 0;
        maxIndexSize = slots.Length - 1;

        slots[currentIndex].ToggleHighlight();

        sword.SetActive(false);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        playerControls.Enable();

        playerControls.HotbarActions.Hotbar1.performed += Hotbar1;
        playerControls.HotbarActions.Hotbar2.performed += Hotbar2;
        playerControls.HotbarActions.Hotbar3.performed += Hotbar3;
        playerControls.HotbarActions.UseItem.performed += UseItem;

    }

    protected override void OnDisable()
    {
        base.OnDisable();

        playerControls.Disable();
        
        playerControls.HotbarActions.Hotbar1.performed -= Hotbar1;
        playerControls.HotbarActions.Hotbar2.performed -= Hotbar2;
        playerControls.HotbarActions.Hotbar3.performed -= Hotbar3;
        playerControls.HotbarActions.UseItem.performed -= UseItem;
    }

    #region Hotbar Select Methods
    private void Hotbar1(InputAction.CallbackContext obj)
    {
        SetIndex(0);
    }

    private void Hotbar2(InputAction.CallbackContext obj)
    {
        SetIndex(1);
    }

    private void Hotbar3(InputAction.CallbackContext obj)
    {
        SetIndex(2);
    }

    #endregion
    private void Update()
    {
        if (playerControls.HotbarActions.MouseWheel.ReadValue<float>() < 0.1f)
        {
            ChangeIndex(1);
        }
        if (playerControls.HotbarActions.MouseWheel.ReadValue<float>() > -0.1f)
        {
            ChangeIndex(-1);
        }

        if (slots[currentIndex].AssignedInventorySlot.itemID == 2)
        {
            sword.SetActive(true);
        }
        else
        {
            sword.SetActive(false);
        }

    }

    private void UseItem(InputAction.CallbackContext obj)
    {
        if (slots[currentIndex].AssignedInventorySlot.itemID == 2)
        {
            if(playerSprint.EnoughStaminaToAttack() == true)
            {
                myAnimator.SetTrigger("Attack");
                playerSprint.UseSword();
            }
        }
        else if(slots[currentIndex].AssignedInventorySlot.ItemData.DisplayName.Contains("Key"))
        {
            if(playerInteractor.CheckIfKeyIsCorrect(slots[currentIndex].AssignedInventorySlot.ItemData.DisplayName) == true)
            {
                slots[currentIndex].AssignedInventorySlot.ItemData.UseItem();
                slots[currentIndex].AssignedInventorySlot.ClearSlot();
                slots[currentIndex].UpdateUISlot();
            }
        }
        else if (slots[currentIndex].AssignedInventorySlot.ItemData != null && slots[currentIndex].AssignedInventorySlot.StackSize >= 1)
        {
            if (slots[currentIndex].AssignedInventorySlot.StackSize == 1)
            {
                slots[currentIndex].AssignedInventorySlot.ItemData.UseItem();
                slots[currentIndex].AssignedInventorySlot.ClearSlot();
                slots[currentIndex].UpdateUISlot();
            }
            else if (slots[currentIndex].AssignedInventorySlot.StackSize > 1)
            {
                slots[currentIndex].AssignedInventorySlot.ItemData.UseItem();
                slots[currentIndex].AssignedInventorySlot.stackSize -= 1;
                slots[currentIndex].AssignedInventorySlot.UpdateInventorySlot(slots[currentIndex].AssignedInventorySlot.itemData, slots[currentIndex].AssignedInventorySlot.stackSize);
                slots[currentIndex].UpdateUISlot();
            }
        }
    }


    private void ChangeIndex(int direction)
    {
        slots[currentIndex].ToggleHighlight();
        currentIndex += direction;

        if(currentIndex > maxIndexSize)
        {
            currentIndex = 0;
        }
        else if (currentIndex < 0)
        {
            currentIndex = maxIndexSize;
        }

        slots[currentIndex].ToggleHighlight();
    }
    private void SetIndex(int newIndex)
    {
        slots[currentIndex].ToggleHighlight();
        
        if(newIndex < 0)
        {
            currentIndex = 0;
        }
        if(newIndex > maxIndexSize)
        {
            newIndex = maxIndexSize;
        }
        currentIndex = newIndex;
        slots[currentIndex].ToggleHighlight();
    }

}