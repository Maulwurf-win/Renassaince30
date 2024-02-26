using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class Spielerbogen : MonoBehaviour
{
    //Textfelder
    public Text levelText, HPText, Gulden, UpgradeText, XPText;

    //Logic
    private int SkinWahl = 0;
    public Image SkinWahlSprite;
    public Image WaffenSprite;
    public RectTransform expBar;

    // Skinwahl
    public void Arrow_to_the_knee(bool Mussolini)
    {
        if (Mussolini)
        {
            SkinWahl++;

            //Wenn man zu lange klickt/Keine weiteren Skins verfügbar sin'
            if (SkinWahl == GameManager.instance.SpielerSprites.Count)
                SkinWahl = 0;

            SkinWechsel();
        }
        else
        {
            SkinWahl--;

            //Wenn man zu lange klickt/Keine weiteren Skins verfügbar sin'
            if (SkinWahl < 0)
                SkinWahl = GameManager.instance.SpielerSprites.Count - 1;

            SkinWechsel();
        }
    }

    private void SkinWechsel()
    {
        SkinWahlSprite.sprite =GameManager.instance.SpielerSprites[SkinWahl];
        GameManager.instance.player.Regierungswechsel(SkinWahl);
    }
    
    //Waffenupgrade
    public void Adrianne_Avenicci()
    {
        if (GameManager.instance.UpgradeVersuch())
            Terms_of_Service_Update();
    }

    //Menüaktualisierung
    public void Terms_of_Service_Update()
    {
        //Waffe
        WaffenSprite.sprite = GameManager.instance.WaffenSprites[GameManager.instance.weapon.Innovation];
        if(GameManager.instance.weapon.Innovation == GameManager.instance.Waffenpreise.Count)
            UpgradeText.text = "MAX";
        else
            UpgradeText.text = GameManager.instance.Waffenpreise[GameManager.instance.weapon.Innovation].ToString();

        //Meta (nicht die Firma)
        HPText.text = GameManager.instance.player.Panzerung.ToString();
        Gulden.text = GameManager.instance.Gulden.ToString();
        levelText.text = GameManager.instance.MomentanesLevel().ToString();

        //XP Barren
        int momentaneslevel = GameManager.instance.MomentanesLevel();
        if(momentaneslevel == GameManager.instance.XPTabelle.Count)
        {
            XPText.text = "Insgesamt " + GameManager.instance.Lebenserfahurng.ToString() + " XP";
            expBar.localScale = Vector3.one;
        }
        else
        {
            int letztesLevelXP = GameManager.instance.XPtoLevel(momentaneslevel - 1);
            int momentanesLevelXP = GameManager.instance.XPtoLevel(momentaneslevel);

            int Differenz = momentanesLevelXP - letztesLevelXP;
            int momentaneXPzuLevel = GameManager.instance.Lebenserfahurng - letztesLevelXP;

            float AbschlussRatio = (float)momentaneXPzuLevel / (float)Differenz;
            expBar.localScale = new Vector3(AbschlussRatio, 1, 1);
            XPText.text = momentaneXPzuLevel.ToString() + "/" + Differenz;
        }
    }
}