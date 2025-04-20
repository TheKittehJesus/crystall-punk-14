using Robust.Shared.Audio;

namespace Content.Shared._CP14.MeleeWeapon.Components;

/// <summary>
/// An attack on this entity will knock the weapon out of the attacker's hands
/// </summary>
[RegisterComponent]
public sealed partial class CP14MeleeParryComponent : Component
{
    [DataField]
    public float ParryPower = 3f;

    [DataField]
    public SoundSpecifier ParrySound = new SoundCollectionSpecifier("CP14Parry", AudioParams.Default.WithVariation(0.05f));
}
