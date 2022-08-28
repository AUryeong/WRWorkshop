using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable CS0659 // 형식은 Object.Equals(object o)를 재정의하지만 Object.GetHashCode()를 재정의하지 않습니다.
public enum DressType
{
    None,
    ALine,
    Mermaid,
    Empire,
    Bell
}
public enum DressColor
{
    None,
    Red,
    Green,
    Blue
}
public class Dress
{
    public DressType type = DressType.None;
    public DressColor color = DressColor.None;
    public bool hasRuby;
    public bool hasRose;
    public bool hasMopi;

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null) return false;

        Dress dressObj = obj as Dress;
        if (dressObj == null) return false;

        return dressObj.type == type &&
            dressObj.color == color &&
            dressObj.hasRuby == hasRuby &&
            dressObj.hasRose == hasRose &&
            dressObj.hasMopi == hasMopi;
    }

}
public class DressManager : Singleton<DressManager>
{
    public Dress myDress = new Dress();
    public Dress guestDress;

    public Image completeDress;
    public Image completeDressRuby;
    public Image completeDressRose;
    public Image completeDressMopi;

    Color dressColorRed = new Color(1, 0.5f, 0.5f);
    Color dressColorGreen = new Color(0.5f, 1, 0.5f);
    Color dressColorBlue = new Color(0.5f, 0.5f, 1);
    public override void OnReset()
    {
        myDress = new Dress();
        Dress dress = new Dress()
        {
            color = DressColor.Blue,
            type = DressType.Mermaid
        };
        Dress dress2 = new Dress()
        {
            color = DressColor.Blue,
            type = DressType.Mermaid
        };
        Debug.Log(dress.Equals(dress2));
    }

    public void ChangeDressType(int dressType)
    {

        DressType dressTypeEnum = (DressType)dressType;
        if (myDress.type == dressTypeEnum)
        {
            myDress.type = DressType.None;

            completeDress.gameObject.SetActive(false);
        }
        else
        {
            myDress.type = dressTypeEnum;

            completeDress.sprite = ResourcesManager.Instance.GetDressTypeSprite(dressTypeEnum);
            completeDress.SetNativeSize();
            completeDress.gameObject.SetActive(true);
        }
    }
    public void ChangeDressColor(int dressColor)
    {
        DressColor dressColorEnum = (DressColor)dressColor;
        if (myDress.color == dressColorEnum)
        {
            myDress.color = DressColor.None;
            completeDress.color = Color.white;
        }
        else
        {
            myDress.color = dressColorEnum;
            switch (myDress.color)
            {
                case DressColor.Red:
                    completeDress.color = dressColorRed;
                    break;
                case DressColor.Green:
                    completeDress.color = dressColorGreen;
                    break;
                case DressColor.Blue:
                    completeDress.color = dressColorBlue;
                    break;
            }
        }
    }

    public void ChangeDressRuby()
    {
        completeDressRuby.gameObject.SetActive(!myDress.hasRuby);
        myDress.hasRuby = !myDress.hasRuby;
    }

    public void ChangeDressRose()
    {
        completeDressRose.gameObject.SetActive(!myDress.hasRose);
        myDress.hasRose = !myDress.hasRose;
    }
    public void ChangeDressMopi()
    {
        completeDressMopi.gameObject.SetActive(!myDress.hasMopi);
        myDress.hasMopi = !myDress.hasMopi;
    }
}
