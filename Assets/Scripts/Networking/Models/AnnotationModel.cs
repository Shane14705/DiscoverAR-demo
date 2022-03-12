using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;


/*
 * Model responsible for storing everything required to synchronize an annotation over the network.
 */

[RealtimeModel]
public partial class AnnotationModel
{
    [RealtimeProperty(1, true, true)]
    private Vector3 _annotationLocation;

    [RealtimeProperty(2, true, true)]
    private string _annotationText;

}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class AnnotationModel : RealtimeModel {
    public UnityEngine.Vector3 annotationLocation {
        get {
            return _annotationLocationProperty.value;
        }
        set {
            if (_annotationLocationProperty.value == value) return;
            _annotationLocationProperty.value = value;
            InvalidateReliableLength();
            FireAnnotationLocationDidChange(value);
        }
    }
    
    public string annotationText {
        get {
            return _annotationTextProperty.value;
        }
        set {
            if (_annotationTextProperty.value == value) return;
            _annotationTextProperty.value = value;
            InvalidateReliableLength();
            FireAnnotationTextDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(AnnotationModel model, T value);
    public event PropertyChangedHandler<UnityEngine.Vector3> annotationLocationDidChange;
    public event PropertyChangedHandler<string> annotationTextDidChange;
    
    public enum PropertyID : uint {
        AnnotationLocation = 1,
        AnnotationText = 2,
    }
    
    #region Properties
    
    private ReliableProperty<UnityEngine.Vector3> _annotationLocationProperty;
    
    private ReliableProperty<string> _annotationTextProperty;
    
    #endregion
    
    public AnnotationModel() : base(null) {
        _annotationLocationProperty = new ReliableProperty<UnityEngine.Vector3>(1, _annotationLocation);
        _annotationTextProperty = new ReliableProperty<string>(2, _annotationText);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _annotationLocationProperty.UnsubscribeCallback();
        _annotationTextProperty.UnsubscribeCallback();
    }
    
    private void FireAnnotationLocationDidChange(UnityEngine.Vector3 value) {
        try {
            annotationLocationDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireAnnotationTextDidChange(string value) {
        try {
            annotationTextDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _annotationLocationProperty.WriteLength(context);
        length += _annotationTextProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _annotationLocationProperty.Write(stream, context);
        writes |= _annotationTextProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.AnnotationLocation: {
                    changed = _annotationLocationProperty.Read(stream, context);
                    if (changed) FireAnnotationLocationDidChange(annotationLocation);
                    break;
                }
                case (uint) PropertyID.AnnotationText: {
                    changed = _annotationTextProperty.Read(stream, context);
                    if (changed) FireAnnotationTextDidChange(annotationText);
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
            anyPropertiesChanged |= changed;
        }
        if (anyPropertiesChanged) {
            UpdateBackingFields();
        }
    }
    
    private void UpdateBackingFields() {
        _annotationLocation = annotationLocation;
        _annotationText = annotationText;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */