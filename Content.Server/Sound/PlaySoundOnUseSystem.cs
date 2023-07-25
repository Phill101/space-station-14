using Content.Server.Cooldown;
using Content.Shared.Cooldown;
using Content.Shared.Interaction.Events;
using Robust.Shared.Timing;

namespace Content.Server.Sound;

public class PlaySoundOnUseSystem : EntitySystem
{

    [Dependency] private readonly IGameTiming _gameTiming = default!;
    [Dependency] private readonly SharedAudioSystem _audio = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<PlaySoundOnUseComponent, UseInHandEvent>(OnUseInHand);
    }

    private void OnUseInHand(EntityUid uid, PlaySoundOnUseComponent component, UseInHandEvent args)
    {
        var curTime = _gameTiming.CurTime;
        if (TryComp<ItemCooldownComponent>(uid, out var cooldown) && curTime < cooldown.CooldownEnd)
        {
            return;
        }

        _audio.PlayPvs(component.Sound, uid);

        RaiseLocalEvent(
            uid,
            new RefreshItemCooldownEvent(curTime, curTime + TimeSpan.FromSeconds(3))
        );
    }
}
