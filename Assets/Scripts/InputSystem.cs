using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
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
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool space = Input.GetKey(KeyCode.Space);

        foreach (var playerInput in SystemAPI.Query<RefRW<InputComponent>>().WithAll<Simulate>())
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
            if (space)
            {
                playerInput.ValueRW.Jump += 1;
            }

        }
    }
}
