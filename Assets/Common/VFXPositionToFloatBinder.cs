using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

[AddComponentMenu("VFX/Property Binders/Position To Float Binder")]
[VFXBinder("Utility/Position To Float")]
public sealed class VFXPositionToFloatBinder : VFXBinderBase
{
    public string Property
      { get => (string)_property;
        set => _property = value; }

    [VFXPropertyBinding("System.Single"), SerializeField]
    ExposedProperty _property = "FloatParameter";

    public Transform Target = null;

    public override bool IsValid(VisualEffect component)
      => Target != null && component.HasFloat(_property);

    public override void UpdateBinding(VisualEffect component)
      => component.SetFloat(_property, Target.localPosition.x);

    public override string ToString()
      => $"Position To Float : '{_property}' -> " +
         (Target != null ? Target.name : "(null)");
}
