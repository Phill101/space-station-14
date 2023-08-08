using Robust.Shared.GameStates;

namespace Content.Shared.Mind.Components;

[NetworkedComponent]
[AutoGenerateComponentState]
public abstract partial class SharedMindContainerComponent : Component
{
    [ViewVariables, AutoNetworkedField]
    public EntityUid? MindUid = default!;
}
