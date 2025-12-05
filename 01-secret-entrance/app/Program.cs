using SecretEntrance;

const string rotationsFileName = "rotations.txt";
string rotationsFilePath = Path.Combine(Environment.CurrentDirectory, rotationsFileName);

string rotationsFileContent = File.ReadAllText(rotationsFilePath);

IEnumerable<string> rotations = rotationsFileContent
    .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
    .Select(line => line.Trim());

uint password = SafePasswordDecoder.Decode(Safe.TurnDial(rotations));

Console.WriteLine($"Password: {password}");