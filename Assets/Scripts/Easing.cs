using UnityEngine;

//Source : https://easings.net/

public enum EEasing
{
    EASE_IN_SINE,
    EASE_OUT_SINE,
    EASE_IN_OUT_SINE,
    EASE_IN_CUBIC,
    EASE_OUT_CUBIC,
    EASE_IN_OUT_CUBIC,
    EASE_IN_QUINT,
    EASE_OUT_QUINT,
    EASE_IN_OUT_QUINT,
    EASE_IN_CIRC,
    EASE_OUT_CIRC,
    EASE_IN_OUT_CIRC,
    EASE_IN_ELASTIC,
    EASE_OUT_ELASTIC,
    EASE_IN_OUT_ELASTIC,
    EASE_IN_QUAD,
    EASE_OUT_QUAD,
    EASE_IN_OUT_QUAD,
    EASE_IN_QUART,
    EASE_OUT_QUART,
    EASE_IN_OUT_QUART,
    EASE_IN_EXPO,
    EASE_OUT_EXPO,
    EASE_IN_OUT_EXPO,
    EASE_IN_BACK,
    EASE_OUT_BACK,
    EASE_IN_OUT_BACK,
    EASE_IN_BOUNCE,
    EASE_OUT_BOUNCE,
    EASE_IN_OUT_BOUNCE
}

public static class Easing
{
    public static float Ease(float _value, EEasing _function)
    {
        _value = Mathf.Max(0, Mathf.Min(_value, 1));
        const float _c1 = 1.70158f;
        const float _c2 = _c1 * 1.525f;
        const float _c3 = _c1 + 1.0f;
        const float _c4 = (2.0f * Mathf.PI) / 3.0f;
        const float _c5 = (2.0f * Mathf.PI) / 4.5f;
        const float _d1 = 2.75f;
        const float _n1 = 7.5625f;
        
        switch (_function)
        {
            case EEasing.EASE_IN_SINE: 
                return 1.0f - Mathf.Cos((_value * Mathf.PI) / 2.0f);
            case EEasing.EASE_OUT_SINE: 
                return Mathf.Sin((_value * Mathf.PI) / 2.0f);
            case EEasing.EASE_IN_OUT_SINE: 
                return -(Mathf.Cos(Mathf.PI * _value) - 1.0f) / 2.0f;
            case EEasing.EASE_IN_CUBIC: 
                return Mathf.Pow(_value, 3.0f);
            case EEasing.EASE_OUT_CUBIC: 
                return 1.0f - Mathf.Pow(1.0f - _value, 3.0f);
            case EEasing.EASE_IN_OUT_CUBIC: 
                return _value < 0.5f ? 4.0f * Mathf.Pow(_value, 3.0f)
                                    : 1.0f - Mathf.Pow(-2.0f * _value + 2.0f, 3.0f) / 2.0f;
            case EEasing.EASE_IN_QUINT: 
                return Mathf.Pow(_value, 5.0f);
            case EEasing.EASE_OUT_QUINT: 
                return 1.0f - Mathf.Pow(1.0f - _value, 5.0f);
            case EEasing.EASE_IN_OUT_QUINT: 
                return _value < 0.5f ? 16.0f * Mathf.Pow(_value, 5.0f)
                                    : 1.0f - Mathf.Pow(-2.0f * _value + 2.0f, 5.0f) / 2.0f;
            case EEasing.EASE_IN_CIRC: 
                return 1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(_value, 2.0f));
            case EEasing.EASE_OUT_CIRC: 
                return Mathf.Sqrt(1.0f - Mathf.Pow(_value - 1.0f, 2.0f));
            case EEasing.EASE_IN_OUT_CIRC: 
                return _value < 0.5f ? (1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(2.0f * _value, 2.0f))) / 2.0f
                                    : (Mathf.Sqrt(1.0f - Mathf.Pow(-2.0f * _value + 2.0f, 2.0f))) / 2.0f;
            case EEasing.EASE_IN_ELASTIC: 
                return _value == 0 ? 0
                                    : _value == 1 ? 1
                                                : -Mathf.Pow(2.0f, 10.0f * _value - 10.0f) * Mathf.Sin((_value * 10.0f - 10.75f) * _c4);
            case EEasing.EASE_OUT_ELASTIC: 
                return _value == 0 ? 0
                                    : _value == 1 ? 1
                                                : Mathf.Pow(2.0f, -10.0f * _value) * Mathf.Sin((_value * 10.0f - 0.75f) * _c4) + 1.0f;
            case EEasing.EASE_IN_OUT_ELASTIC: 
                return _value == 0 ? 0
                                    : _value == 1 ? 1
                                                : _value < 0.5 ? -(Mathf.Pow(2.0f, 20.0f * _value - 10.0f) * Mathf.Sin((20.0f * _value - 11.125f) * _c5)) / 2.0f
                                                                : (Mathf.Pow(2.0f, -20.0f * _value + 10.0f) * Mathf.Sin((20.0f * _value - 11.125f) * _c5)) / 2.0f + 1.0f;
            case EEasing.EASE_IN_QUAD: 
                return Mathf.Pow(_value, 2.0f);
            case EEasing.EASE_OUT_QUAD:
                return 1.0f - Mathf.Pow(1.0f - _value, 2.0f);
            case EEasing.EASE_IN_OUT_QUAD: 
                return _value < 0.5f ? 2.0f * Mathf.Pow(_value, 2.0f)
                                    : 1.0f - Mathf.Pow(-2.0f * _value + 2.0f, 2.0f) / 2.0f;
            case EEasing.EASE_IN_QUART:
                return Mathf.Pow(_value, 4.0f);
            case EEasing.EASE_OUT_QUART: 
                return 1.0f - Mathf.Pow(1.0f - _value, 4.0f);
            case EEasing.EASE_IN_OUT_QUART: 
                return _value < 0.5f ? 8.0f * Mathf.Pow(_value, 4.0f)
                                    : 1.0f - Mathf.Pow(-2.0f * _value + 2.0f, 4.0f) / 2.0f;
            case EEasing.EASE_IN_EXPO: 
                return _value == 0 ? 0
                                    : Mathf.Pow(2.0f, 10.0f * _value - 10.0f);
            case EEasing.EASE_OUT_EXPO: 
                return _value == 1 ? 1
                                    : 1.0f - Mathf.Pow(2.0f, -10.0f * _value);
            case EEasing.EASE_IN_OUT_EXPO: 
                return _value == 0 ? 0
                                    : _value == 1 ? 1
                                                    : _value < 0.5 ? Mathf.Pow(2.0f, 20.0f * _value - 10.0f) / 2.0f
                                                                    : (2.0f - Mathf.Pow(2.0f, -20.0f * _value + 10.0f)) / 2.0f;
            case EEasing.EASE_IN_BACK: 
                return _c3 * Mathf.Pow(_value, 3.0f) - _c1 * Mathf.Pow(_value, 2.0f);
            case EEasing.EASE_OUT_BACK: 
                return 1.0f +  _c3 * Mathf.Pow(_value - 1.0f, 3.0f) + _c1 * Mathf.Pow(_value - 1.0f, 2.0f);
            case EEasing.EASE_IN_OUT_BACK: 
                return _value < 0.5 ? (Mathf.Pow(2.0f * _value, 2.0f) * ((_c2 + 1.0f) * 2.0f * _value - _c2)) / 2.0f
                                    : (Mathf.Pow(2.0f * _value - 2.0f, 2.0f) * ((_c2 + 1.0f) * (_value * 2.0f - 2.0f) + _c2) + 2.0f) / 2.0f;
            case EEasing.EASE_IN_BOUNCE:
                return 1.0f - Ease(1.0f - _value, EEasing.EASE_OUT_BOUNCE);
            case EEasing.EASE_OUT_BOUNCE:
                if (_value < 1.0f / _d1)
                    return _n1 * Mathf.Pow(_value, 2.0f);
                if (_value < 2.0f / _d1)
                    return _n1 * (_value -= 1.5f / _d1) * _value + 0.75f;
                if (_value < 2.5f / _d1)
                    return _n1 * (_value -= 2.25f / _d1) * _value + 0.9375f;
                return _n1 * (_value -= 2.625f / _d1) * _value + 0.984375f;
            case EEasing.EASE_IN_OUT_BOUNCE:
                return _value < 0.5f ? (1.0f - Ease(1.0f - 2.0f * _value, EEasing.EASE_OUT_BOUNCE)) / 2
                                    : (1.0f + Ease(2.0f * _value - 1.0f, EEasing.EASE_OUT_BOUNCE)) / 2;
            default: return _value;
        }
    }
}