using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChange;

    public void UseItem()
    {

        if (statToChange == StatToChange.Health)
        {
            Debug.Log($"Using {itemName} to change health by {amountToChange}.");
            // Implement hedalth change logic here
        }
        else if (statToChange == StatToChange.Damage)
        {
            Debug.Log($"Using {itemName} to change damage by {amountToChange}.");
            // Implement damage change logic here
        }
        else if (statToChange == StatToChange.Stamina)
        {
            Debug.Log($"Using {itemName} to change stamina by {amountToChange}.");
            // Implement stamina change logic here
        }
    }


    public enum StatToChange
    {
        None,
        Health,
        Damage,
        Stamina
    }
}
