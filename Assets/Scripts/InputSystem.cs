using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

[UpdateInGroup((typeof(GhostInputSystemGroup)))]
public partial struct InputSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<PlayerSpawner>();
        state.RequireForUpdate<InputComponent>();
        state.RequireForUpdate<NetworkId>();
    }

    public void OnUpdate(ref SystemState state)
    {
        bool left = Input.GetKey("left");
        bool right = Input.GetKey("right");
        bool down = Input.GetKey("down");
        bool up = Input.GetKey("up");

        foreach (var playerInput in SystemAPI.Query<RefRW<InputComponent>>().WithAll<GhostOwnerIsLocal>())
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