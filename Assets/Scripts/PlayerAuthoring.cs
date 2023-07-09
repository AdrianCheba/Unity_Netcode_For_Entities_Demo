using Unity.Entities;
using UnityEngine;

public struct Player : IComponentData
{
}

[DisallowMultipleComponent]
public class PlayerAuthoring : MonoBehaviour
{
    class Baker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            Player component = default(Player);
            AddComponent(component);
        }
    }
}