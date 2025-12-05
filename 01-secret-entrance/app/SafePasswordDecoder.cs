namespace SecretEntrance;

internal static class SafePasswordDecoder
{
    public static uint Decode(IEnumerable<uint> dialPositions) =>
        (uint) dialPositions.Count(position => position == 0u);
}