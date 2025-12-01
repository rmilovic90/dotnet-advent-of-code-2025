namespace SecretEntrance;

internal sealed class Safe
{
    public uint DialPosition { get; private set; } = 50;

    public void TurnDial(IEnumerable<string> rotations)
    {
        foreach (var rotation in rotations) TurnDial(rotation);
    }

    public void TurnDial(string rotation)
    {
        string direction = rotation[0..1];
        uint distance = uint.Parse(rotation[1..]);

        if (direction == "L")
        {
            if (DialPosition < distance)
                DialPosition = 100 + DialPosition - distance;
            else
                DialPosition -= distance;
        }

        if (direction == "R")
        {
            if (DialPosition + distance >= 100)
                DialPosition = DialPosition + distance - 100;
            else
                DialPosition += distance;
        }
    }
}