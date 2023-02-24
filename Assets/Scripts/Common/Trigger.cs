using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : IDialogue
{
    public bool IsOneTimeTrigger = true, IsInteracted = false;
    public bool ShouldPlayerFreeze = true;
    public TimePeriod RequiredPeriod;
    public List<ItemProperties> RequiredItems;

    private bool IsInRightPeriod() {
        return TimeTravelController.Instance.GetCurrentPeriod() == RequiredPeriod;
    }

    private bool IsPlayerAdvancingDialog() {
        return (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E));
    }
    
    private bool PlayerHasRequiredItems() {
        foreach (ItemProperties itemProp in RequiredItems) {
            if (!InventoryManager.Instance.Items.Contains(itemProp)) return false;
        }
        return true;
    }

    protected override bool IsPlayerInteracting()
    {
        return isPlayerInContact && IsInRightPeriod() && PlayerHasRequiredItems();
    }

    public override void DoInteraction()
    {
        if (!IsOneTimeTrigger || (IsOneTimeTrigger && !IsInteracted)){
            if (DialogBox.Instance.IsVisible()) {
                if (IsPlayerAdvancingDialog()) base.DoInteraction();
            } else {
                base.DoInteraction();
            }
            PlayerMovement.Instance.SetFrozenStatus(ShouldPlayerFreeze);
        } else {
            PlayerMovement.Instance.SetFrozenStatus(false);
        }
    }

    public override void StopInteraction()
    {
        base.StopInteraction();
        IsInteracted = true;
    }
}
