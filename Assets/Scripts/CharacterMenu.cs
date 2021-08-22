using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // Text fields
    public Text levelText, hitpointText, pesosText, upgradeCostText, xpText;

    // Logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    // Character Seletion
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;

            // If we went too far away
            if (currentCharacterSelection == GameManger.instance.playerSprites.Count)
                currentCharacterSelection = 0;

            OnSelectionChanged();
        }
        else
        {
            currentCharacterSelection--;

            // If we went too far away
            if (currentCharacterSelection < 0)
                currentCharacterSelection = GameManger.instance.playerSprites.Count - 1;

            OnSelectionChanged();
        }
    }
    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManger.instance.playerSprites[currentCharacterSelection];
        GameManger.instance.player.SwapSprite(currentCharacterSelection);
    }

    // Weapon Upgrade
    public void OnUpgradeClick()
    {
        if (GameManger.instance.TryUpgradeWeapon())
            UpdateMenu();
    }

    // Update the character Information
    public void UpdateMenu()
    {
        // Weapon
        weaponSprite.sprite = GameManger.instance.weaponSprites[GameManger.instance.weapon.weaponLevel];
        if(GameManger.instance.weapon.weaponLevel == GameManger.instance.weaponPrices.Count)
            upgradeCostText.text = "MAX";
        else
            upgradeCostText.text = GameManger.instance.weaponPrices[GameManger.instance.weapon.weaponLevel].ToString();

        // Meta
        levelText.text = GameManger.instance.GetCurrentLevel().ToString();
        hitpointText.text = GameManger.instance.player.hitpoint.ToString();
        pesosText.text = GameManger.instance.pesos.ToString();

        // xp Bar
        int currLevel = GameManger.instance.GetCurrentLevel();
        if (currLevel == GameManger.instance.xpTable.Count)
        {
            xpText.text = GameManger.instance.experience.ToString() + " total experience points"; // Display total xp
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLevelXp = GameManger.instance.GetXpToLevel(currLevel - 1);
            int currLevelXp = GameManger.instance.GetXpToLevel(currLevel);

            int diff = currLevelXp - prevLevelXp;
            int currXpIntoLevel = GameManger.instance.experience - prevLevelXp;

            float completionRatio = (float)currXpIntoLevel / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currXpIntoLevel.ToString() + " / " + diff;
        }
    }
}
