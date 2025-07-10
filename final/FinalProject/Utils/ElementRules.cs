public static class ElementRules
{
    // Returns true if elementA beats elementB
    public static bool Beats(ElementType elementA, ElementType elementB)
    {
        // Example rules: Fire beats Snow, Snow beats Water, Water beats Fire
        if (elementA == ElementType.Fire && elementB == ElementType.Snow)
            return true;
        if (elementA == ElementType.Snow && elementB == ElementType.Water)
            return true;
        if (elementA == ElementType.Water && elementB == ElementType.Fire)
            return true;
        return false;
    }
}