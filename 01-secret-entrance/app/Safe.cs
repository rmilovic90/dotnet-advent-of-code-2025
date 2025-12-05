namespace SecretEntrance;

internal static class Safe
{
    public static IReadOnlyList<uint> TurnDial(IEnumerable<string> rotations)
    {
        List<uint> positions = [50u];

        foreach (var rotation in rotations) positions.Add(TurnDial(positions.Last(), rotation));

        return positions;
    }

    private static uint TurnDial(uint currentPosition, string rotation)
    {
        uint nextPosition = currentPosition;

        string direction = rotation[0..1];
        uint distance = uint.Parse(rotation[1..]);

        if (direction == "L")
        {
            if (currentPosition < distance)
                nextPosition = 100 + currentPosition - distance;
            else
                nextPosition -= distance;
        }

        if (direction == "R")
        {
            if (currentPosition + distance >= 100)
                nextPosition = currentPosition + distance - 100;
            else
                nextPosition += distance;
        }

        return nextPosition;
    }
}