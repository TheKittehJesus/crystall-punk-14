using Content.Shared._CP14.MagicSpellStorage;
using Content.Shared.FixedPoint;
using Content.Shared.Whitelist;

namespace Content.Shared._CP14.MagicSpell.Components;

/// <summary>
/// This spell can only be used if the caster is holding a suitable object in hands
/// </summary>
[RegisterComponent, Access(typeof(CP14SharedMagicSystem), typeof(CP14SpellStorageSystem))]
public sealed partial class CP14MagicEffectHeldedItemBasedComponent : Component
{
    [DataField(required: true)]
    public EntityWhitelist Whitelist = new();
}
