using EndFieldPS;
using Pastel;
using System;
using System.Diagnostics;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
public static class Logger
{

    public static Dictionary<string, string> ClassColors = new Dictionary<string, string>()
    {
        {"Server","03fcce" },
        {"Dispatch", "0307fc" }
    };
    private static string GetCallingClassName()
    {
        // Ottiene lo stack trace corrente
        StackTrace stackTrace = new StackTrace();

        // Trova il frame chiamante (2 livelli sopra il metodo attuale)
        var frame = stackTrace.GetFrame(2);

        // Ottiene il tipo chiamante
        var method = frame?.GetMethod();
        return method?.DeclaringType?.Name ?? "Server";
    }
    public static void Print(string text)
    {
        string className = GetCallingClassName();
        Logger.Log(text);
        Console.WriteLine($"[{Server.ColoredText(className, "03fcce")}] " + text);
    }
    public static void PrintError(string text)
    {
        string className = GetCallingClassName();
        Logger.Log(text);
        Console.WriteLine($"[{Server.ColoredText(className, "03fcce")}] " + text.Pastel("eb4034"));
    }
    public static string GetColor(string c)
    {
        if (ClassColors.ContainsKey(c)) return ClassColors[c];
        return "03fcce";
    }
    private static StreamWriter logWriter;
    private static bool hideLogs;

    public static void Initialize(bool hideLogs = false)
    {
        Logger.hideLogs = hideLogs;
        logWriter = new StreamWriter("latest.log", false);
    }

    public static void Log(string message)
    {
        if (!hideLogs)
        {
            try
            {
                logWriter.WriteLine($"{DateTime.Now}: {message}");
                logWriter.Flush();
            }
            catch(Exception e)
            {

            }
           
        }
    }

    public static void Close()
    {
        logWriter.Close();
    }
}