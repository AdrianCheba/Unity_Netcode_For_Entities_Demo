using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.AllPredicted)]
public struct InputComponent : IInputComponentData
{
    public int Horizontal;
    public int Vertical;
}
