using Godot;
using System;

public partial class WeaponPickup : Area2D
{
    [Export] public PackedScene weaponScene; // L'arme à ramasser

    // Signal quand un joueur entre dans la zone de ramassage
    private void _on_Area2D_body_entered(Node body)
    {
        // Vérifie si l'objet qui entre est un joueur
        if (body is Player player)
        {
            // Lorsque le joueur entre, il ramasse l'arme
            EquipWeapon(player);
        }
    }

    private void EquipWeapon(Player player)
    {
        // Instancier l'arme et l'équiper
        Weapon weapon = weaponScene.Instantiate<Weapon>();
        player.EquipWeapon(weapon);  // Equip l'arme au joueur

        // Supprimer l'arme au sol
        QueueFree();  // Supprime l'arme du jeu
    }
}
