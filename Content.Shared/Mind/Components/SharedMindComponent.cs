namespace Content.Shared.Mind.Components;

public abstract class SharedMindComponent : Component
{
    /// <summary>
    /// A set of words that catch mind-owner's attention
    /// </summary>
    [ViewVariables] public string[] Codewords = default!;
}
