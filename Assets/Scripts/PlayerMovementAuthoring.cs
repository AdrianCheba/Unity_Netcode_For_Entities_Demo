using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct PlayerMovement : IInputComponentData
{
    public int Horizontal;
    public int Vertical;
}

[DisallowMultipleComponent]
public class PlayerMovementAuthoring : MonoBehaviour
{
    class Baking : Baker<PlayerMovementAuthoring>
    {
        public override void Bake(PlayerMovementAuthoring authoring)
        {
            AddComponent<PlayerMovement>();
        }
    }
}

[UpdateInGroup(typeof(GhostInputSystemGroup))]
public partial struct SamplePlayerMovement : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        bool left = Input.GetKey("left");
        bool right = Input.GetKey("right");
        bool down = Input.GetKey("down");
        bool up = Input.GetKey("up");

        foreach (var playerInput in SystemAPI.Query<RefRW<PlayerMovement>>().WithAll<GhostOwnerIsLocal>())
        {
            playerInput.ValueRW = default;
            if (left)
                playerInput.ValueRW.Horizontal -= 1;
            if (right)
                playerInput.ValueRW.Horizontal += 1;
            if (down)
                playerInput.ValueRW.Vertical -= 1;
            if (up)
                playerInput.ValueRW.Vertical += 1;
        }
    }
}