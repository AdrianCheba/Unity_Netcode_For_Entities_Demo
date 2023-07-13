using Unity.Entities;
using Unity.Physics.Systems;


[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation)]
[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
public partial class ClientOnlyPhysicsSystemGroup : CustomPhysicsSystemGroup
{
    public ClientOnlyPhysicsSystemGroup() : base(1, true) { }
}