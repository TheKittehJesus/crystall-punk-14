using Content.Shared._CP14.MeleeWeapon.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Popups;
using Content.Shared.Throwing;
using Content.Shared.Weapons.Melee.Events;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Random;

namespace Content.Shared._CP14.MeleeWeapon.EntitySystems;

public sealed class CP14MeleeParrySystem : EntitySystem
{
    [Dependency] private readonly IRobustRandom _random = default!;
    [Dependency] private readonly ThrowingSystem _throwing = default!;
    [Dependency] private readonly SharedHandsSystem _hands = default!;
    [Dependency] private readonly SharedPopupSystem _popup = default!;
    [Dependency] private readonly SharedAudioSystem _audio = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<CP14MeleeParryComponent, AttackedEvent>(OnAttacked);
    }

    private void OnAttacked(Entity<CP14MeleeParryComponent> ent, ref AttackedEvent args)
    {
        _hands.TryDrop(args.User, args.Used);
        _throwing.TryThrow(args.Used, _random.NextAngle().ToWorldVec(), ent.Comp.ParryPower, args.User);
        _popup.PopupPredicted( Loc.GetString("cp14-successful-parry"), args.User, args.User);
        _audio.PlayPvs(ent.Comp.ParrySound, args.Used);
    }
}
