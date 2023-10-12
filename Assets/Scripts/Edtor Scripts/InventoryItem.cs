using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Create Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int itemQuantity;
    public bool isStackable;
    // Agrega aqu� cualquier otra propiedad que necesites para tu objeto de inventario.
}
