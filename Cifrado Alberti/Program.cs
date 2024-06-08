#nullable disable 

// Actividad 2
// Realizar codigo mediante el cifrado de alberti

public class CifradoAlberti
{
    private static Random random = new Random();
    public string DiscoExterno { get; set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // El disco externo fijo contiene las 26 letras del abecedario
    public string DiscoInterno { get; set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // El disco interno movil es quien determinara la encripcion

    public string Encriptar() // El disco interno se randomiza para crear la encripcion
    {
        DiscoInterno = new string(DiscoInterno.OrderBy(c => random.Next()).ToArray());
        return DiscoInterno;
    }

    public string Encripcion(string word)
    {
        char[] encripcion = new char[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            char currentChar = char.ToUpper(word[i]);
            int index = DiscoExterno.IndexOf(currentChar);
            encripcion[i] = (index >= 0) ? DiscoInterno[index] : currentChar;
        }
        return new string(encripcion);
    }
}

public class Program
{
    public static void Main()
    {
        CifradoAlberti cifrado = new CifradoAlberti();
        
        cifrado.Encriptar(); // Se randomiza el disco interno
        
        Console.WriteLine("Ingrese una palabra para encriptar:"); // La palabra es introducida por el usuario
        string input = Console.ReadLine();
        
        string encripcion = cifrado.Encripcion(input); // Se encripta la palabra del usuario 
        
        Console.WriteLine($"Palabra encriptada: {encripcion}");
    }
}