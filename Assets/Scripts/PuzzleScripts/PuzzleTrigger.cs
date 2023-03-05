using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : IInteractable
{
    public Puzzle puzzle;

    // TODO: Move this to another class (common w Trigger)
    public TimePeriod requiredPeriod;
    public List<ItemProperties> requiredItems;

    private bool PlayerHasRequiredItems()
    {
        foreach (ItemProperties item in requiredItems)
        {
            if (!InventoryManager.Instance.Items.Contains(item)) return false;
        }

        return true;
    }

    public override void DoInteraction()
    {
        if (puzzle.IsVisible()) {
            StopInteraction();
        } else {
            puzzle.Show();
            PlayerMovement.Instance.SetFrozenStatus(true);
        }
    }

    public override void StopInteraction()
    {
        puzzle.Hide();
        PlayerMovement.Instance.SetFrozenStatus(false);
    }

    protected override bool IsPlayerInteracting()
    {
        return !puzzle.IsSolved() && base.IsPlayerInteracting();
    }

    protected override void OnCollisionStay(Collision collision)
    {
        if (!puzzle.IsSolved()) base.OnCollisionStay(collision);
    }
}