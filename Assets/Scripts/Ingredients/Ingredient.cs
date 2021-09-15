using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string type;
    public Color color;

    void Awake()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", color);
    }



    public Ingredient(string type, Color color)
    {
        this.type = type;
        this.color = color;
    }

    private bool Equals(Ingredient other)
    {
        return base.Equals(other) && type == other.type && color.Equals(other.color);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Ingredient)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = base.GetHashCode();
            hashCode = (hashCode * 397) ^ (type != null ? type.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ color.GetHashCode();
            return hashCode;
        }
    }

    private sealed class TypeColorEqualityComparer : IEqualityComparer<Ingredient>
    {
        public bool Equals(Ingredient x, Ingredient y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.type == y.type && x.color.Equals(y.color);
        }

        public int GetHashCode(Ingredient obj)
        {
            unchecked
            {
                return ((obj.type != null ? obj.type.GetHashCode() : 0) * 397) ^ obj.color.GetHashCode();
            }
        }
    }

    public static IEqualityComparer<Ingredient> TypeColorComparer { get; } = new TypeColorEqualityComparer();
}
