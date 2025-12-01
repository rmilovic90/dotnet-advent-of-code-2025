namespace SecretEntrance;

internal sealed class Safe
{
    public uint DialPosition { get; private set; } = 50;

    public void TurnDial(IEnumerable<string> rotations)
    {
        string direction = rotations.First()[0..1];
        uint distance = uint.Parse(rotations.First()[1..]);

        if (direction == "L")
            DialPosition -= distance;

        if (direction == "R")
            DialPosition += distance;
    }
}