using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
    private bool isWritingResources = false;
    private Dictionary<string, Sprite> dressTypeSprites = new Dictionary<string, Sprite>();
    public override void OnReset()
    {
        if (!isWritingResources)
            ReadResource();
    }

    public void ReadResource()
    {
        foreach (var dress in Resources.LoadAll<Sprite>("DressType"))
            dressTypeSprites.Add(dress.name, dress);

        isWritingResources = true;
    }


    public Sprite GetDressTypeSprite(DressType dressType)
    {
        string spriteName = dressType.ToString();
        if (!dressTypeSprites.ContainsKey(spriteName))
        {
            Debug.LogAssertion("Sprite not found : " + spriteName);
            return null;
        }
        return dressTypeSprites[spriteName];
    }
}
