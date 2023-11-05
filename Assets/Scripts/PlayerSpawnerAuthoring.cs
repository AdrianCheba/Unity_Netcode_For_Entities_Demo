using Unity.Entities;
using UnityEngine;

public struct PlayerSpawner : IComponentData
{
    public Entity Player;
}

[DisallowMultipleComponent]
public class PlayerSpawnerAuthoring : MonoBehaviour
{
    public GameObject Player;

    class Baker : Baker<PlayerSpawnerAuthoring>
    {
        [System.Obsolete]
        public override void Bake(PlayerSpawnerAuthoring authoring)
        {
           
            PlayerSpawner component = default;
            component.Player = GetEntity(authoring.Player, TransformUsageFlags.Dynamic);
            AddComponent<PlayerSpawner>(component);
        }
    }
}