using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using Unity.Burst;

[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
[BurstCompile]
public partial struct PlayerMovementSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var speed = SystemAPI.Time.DeltaTime * 4;
        foreach (var (input, trans) in SystemAPI.Query<RefRO<PlayerMovement>, RefRW<LocalTransform>>().WithAll<Simulate>())
        {
            var moveInput = new float2(input.ValueRO.Horizontal, input.ValueRO.Vertical);
            moveInput = math.normalizesafe(moveInput) * speed;
            trans.ValueRW.Position += new float3(moveInput.x, 0, moveInput.y);
        }
    }
}
