using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour
{
    private Transform container;

    private Transform upgrade_template;

    private Transform speed_upg_template;
    private Transform cap_upg_template;
    private Transform coin_upg_template;

    private void Awake()
    {
        container = transform.Find("container");

        upgrade_template = container.Find("upgrade_template");
        upgrade_template.gameObject.SetActive(false);

        speed_upg_template = container.Find("speed_upg_template");
        speed_upg_template.gameObject.SetActive(false);

        cap_upg_template = container.Find("cap_upg_template");
        cap_upg_template.gameObject.SetActive(false);

        coin_upg_template = container.Find("coin_upg_template");
        coin_upg_template.gameObject.SetActive(false);
    }

    private void Start()
    {
        //CreateUpgradeButton(Upgrades.GetSprite(Upgrades.ItemType.Speed_Upg), Upgrades.GetCost(Upgrades.ItemType.Speed_Upg), 0);
        //CreateUpgradeButton(Upgrades.GetSprite(Upgrades.ItemType.Capacity_Upg), Upgrades.GetCost(Upgrades.ItemType.Capacity_Upg), 1);
        //CreateUpgradeButton(Upgrades.GetSprite(Upgrades.ItemType.Coin_Upg), Upgrades.GetCost(Upgrades.ItemType.Coin_Upg), 2);

        CreateSpeedUpgradeButton(Upgrades.GetSprite(Upgrades.ItemType.Speed_Upg), Upgrades.GetCost(Upgrades.ItemType.Speed_Upg), 0);
        CreateCapUpgradeButton(Upgrades.GetSprite(Upgrades.ItemType.Capacity_Upg), Upgrades.GetCost(Upgrades.ItemType.Capacity_Upg), 1);
        CreateCoinUpgradeButton(Upgrades.GetSprite(Upgrades.ItemType.Coin_Upg), Upgrades.GetCost(Upgrades.ItemType.Coin_Upg), 2);
    }

    private void CreateUpgradeButton(Sprite upg_sprite, int item_cost, int pos_index)
    {
        Transform upgradeTransform = Instantiate(upgrade_template, container);
        RectTransform upgradeRectTransform = upgradeTransform.GetComponent<RectTransform>();
        upgradeRectTransform.anchoredPosition = new Vector2(upgradeRectTransform.anchoredPosition.x - 250, upgradeRectTransform.anchoredPosition.y);

        upgradeTransform.gameObject.SetActive(true);

        float upgradeLength = 350;
        upgradeRectTransform.anchoredPosition = new Vector2(upgradeLength * pos_index, 0);

        upgradeTransform.Find("upgr_button").GetChild(0).GetComponent<TextMeshProUGUI>().SetText(item_cost.ToString());

        upgradeTransform.Find("upgr_button").GetComponent<Image>().sprite = upg_sprite;
    }

    #region Create Upgrade Button Functions
    public void CreateCapUpgradeButton(Sprite item_sprite, int itemCost, int POS_index)
    {
        Transform shopItemTransform = Instantiate(cap_upg_template, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        shopItemRectTransform.anchoredPosition = new Vector2(shopItemRectTransform.anchoredPosition.x - 250, shopItemRectTransform.anchoredPosition.y);

        shopItemTransform.gameObject.SetActive(true);

        float shopItemLength = 350;
        shopItemRectTransform.anchoredPosition = new Vector2(shopItemLength * POS_index, 0);

        shopItemTransform.Find("upgr_button").GetChild(0).GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("upgr_button").GetComponent<Image>().sprite = item_sprite;
    }

    public void CreateSpeedUpgradeButton(Sprite item_sprite, int itemCost, int POS_index)
    {
        Transform shopItemTransform = Instantiate(speed_upg_template, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        shopItemRectTransform.anchoredPosition = new Vector2(shopItemRectTransform.anchoredPosition.x - 250, shopItemRectTransform.anchoredPosition.y);

        shopItemTransform.gameObject.SetActive(true);

        float shopItemLength = 350f;
        shopItemRectTransform.anchoredPosition = new Vector2(shopItemLength * POS_index, 0);

        shopItemTransform.Find("upgr_button").GetChild(0).GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("upgr_button").GetComponent<Image>().sprite = item_sprite;
    }

    public void CreateCoinUpgradeButton(Sprite item_sprite, int itemCost, int POS_index)
    {
        Transform shopItemTransform = Instantiate(coin_upg_template, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        shopItemRectTransform.anchoredPosition = new Vector2(shopItemRectTransform.anchoredPosition.x - 250, shopItemRectTransform.anchoredPosition.y);

        shopItemTransform.gameObject.SetActive(true);

        float shopItemLength = 350f;
        shopItemRectTransform.anchoredPosition = new Vector2(shopItemLength * POS_index, 0);

        shopItemTransform.Find("upgr_button").GetChild(0).GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("upgr_button").GetComponent<Image>().sprite = item_sprite;
    }
    #endregion


}
