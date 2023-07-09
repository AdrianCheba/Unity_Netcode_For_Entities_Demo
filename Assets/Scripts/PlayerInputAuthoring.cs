using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerInputAuthoring : MonoBehaviour
{
}

public class InputBaker : Baker<PlayerInputAuthoring>
{
   
    public override void Bake(PlayerInputAuthoring authoring)
    {
        AddComponent<InputComponent>();
    }
}