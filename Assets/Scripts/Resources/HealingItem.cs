using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealingItem
{
    public string name;
    public int price;
    public abstract void Use();
}

public class ExtraLife : HealingItem
{
    public ExtraLife(){
        name = "Extra Life";
        price = 15;
    }

    public override void Use()
    {
        Debug.Log("Compraste y usaste un Extra Life");
    }
}

public class Band_aid : HealingItem
{
    public Band_aid(){
        name = "Band-aid";
        price = 5;
    }

    public override void Use()
    {
        Debug.Log("Compraste y usaste un Band-aid");
    }
}

public class FirstAidKit : HealingItem
{
    public FirstAidKit(){
        name = "First Aid Kit";
        price = 10;
    }

    public override void Use()
    {
        Debug.Log("Compraste y usaste un First Aid Kit");
    }
}