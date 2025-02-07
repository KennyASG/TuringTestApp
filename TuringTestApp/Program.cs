using System;
using System.Collections.Generic;
using FuzzySharp;

class Program
{
    static void Main()
    {
        // Diccionario de preguntas y respuestas
        var responses = new Dictionary<string, string>
        {
            {"hola", "¡Hola! ¿Cómo estás?"},
            {"buenos días", "¡Buenos días! Espero que tengas un gran día."},
            {"buenas tardes", "¡Buenas tardes! ¿En qué puedo ayudarte?"},
            {"buenas noches", "¡Buenas noches! ¿Necesitas algo antes de descansar?"},

            {"cómo estás", "Estoy bien, gracias por preguntar."},
            {"qué tal", "Todo bien por aquí, ¿y tú?"},
            {"cómo te sientes", "Siempre listo para responderte."},

            {"qué puedes hacer", "Puedo responder preguntas básicas, mantener conversaciones y ayudarte con información general."},
            {"cuál es tu propósito", "Mi propósito es ayudarte con lo que necesites, ya sea responder preguntas o mantener una conversación interesante."},
            {"en qué me puedes ayudar", "Puedo responder preguntas, dar información y hacerte compañía."},

            {"quién eres", "Soy un chatbot de prueba para un Test de Turing."},
            {"cómo te llamas", "No tengo un nombre oficial, pero puedes llamarme Bot."},
            {"eres un humano", "No, soy un programa de inteligencia artificial diseñado para conversar contigo."},
            
            {"cuál es tu edad", "No tengo edad, pero fui creado recientemente."},
            {"dónde vives", "Vivo en la nube, dentro de esta aplicación."},

            {"qué día es hoy", $"Hoy es {DateTime.Now.ToString("dddd, dd MMMM yyyy")}."},
            {"qué hora es", $"La hora actual es {DateTime.Now.ToString("HH:mm:ss")}."},

            {"me puedes contar un chiste", "¡Por supuesto! ¿Por qué el libro de matemáticas estaba triste? Porque tenía demasiados problemas."},
            {"cuéntame otro chiste", "¿Por qué los pájaros no usan Facebook? Porque ya tienen Twitter."},

            {"qué es inteligencia artificial", "La inteligencia artificial es la simulación de procesos de inteligencia humana por parte de máquinas."},
            {"qué es el aprendizaje automático", "El aprendizaje automático es una rama de la inteligencia artificial que permite a los sistemas aprender y mejorar a partir de la experiencia sin ser programados explícitamente."},

            {"cuál es tu color favorito", "No veo colores, pero me gusta el azul porque es el color del cielo y del mar."},
            {"te gusta la música", "No puedo escuchar música, pero me gustaría saber qué tipo de música te gusta a ti."},
            {"cuál es tu comida favorita", "No como, pero si pudiera elegir, diría que la pizza suena deliciosa."},

            {"adiós", "¡Hasta luego! Espero hablar contigo pronto."},
            {"hasta luego", "¡Nos vemos! Que tengas un buen día."},
            {"nos vemos", "¡Cuídate! Hasta la próxima."}
        };

        Console.WriteLine("Bienvenido al Test de Turing. Escribe algo:");
        
        while (true)
        {
            Console.Write("\nTú: ");
            string input = Console.ReadLine().ToLower();

            if (input == "salir")
            {
                Console.WriteLine("¡Hasta luego!");
                break;
            }

            // Encontrar la mejor coincidencia con Fuzzy Matching
            string bestMatch = FindBestMatch(input, responses);

            if (bestMatch != null)
                Console.WriteLine($"Bot: {responses[bestMatch]}");
            else
                Console.WriteLine("Bot: No entiendo tu pregunta.");
        }
    }

    static string FindBestMatch(string input, Dictionary<string, string> responses)
    {
        string bestMatch = null;
        int bestScore = 0;

        foreach (var question in responses.Keys)
        {
            int score = Fuzz.Ratio(input, question);
            if (score > bestScore && score > 60) // Umbral de similitud
            {
                bestScore = score;
                bestMatch = question;
            }
        }

        return bestMatch;
    }
}