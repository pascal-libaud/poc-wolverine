using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wolverine;

namespace ConsoleApp14;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        //1.Messagerie asynchrone:
        //    •	Permet l'envoi et la réception de messages (commandes, événements) entre différents composants ou services.
        //    •	Supporte les files d'attente en mémoire, RabbitMQ, Azure Service Bus, Kafka, etc.
        //2.Médiateur intégré:
        //    •	Implémente le pattern Mediator pour gérer les commandes et les requêtes de manière centralisée.
        //    •	Simplifie la gestion des dépendances entre les composants.
        //3.Gestion des workflows :
        //    •	Permet de définir des workflows complexes basés sur des messages.
        //    •	Gère les étapes de traitement de manière asynchrone et résiliente.
        //4.Transactions distribuées:
        //    •	Supporte les transactions distribuées pour garantir la cohérence des données dans des systèmes distribués.
        //5.Résilience et fiabilité :
        //    •	Intègre des mécanismes de reprise automatique, de gestion des erreurs et de retries pour les messages échoués.
        //    •	Permet de configurer des politiques de gestion des erreurs.
        //6.Support des messages persistants:
        //    •	Permet de persister les messages pour garantir leur livraison même en cas de panne.
        //7.Intégration avec.NET :
        //    •	Exploite les fonctionnalités modernes de.NET, comme les async / await, les records, et les minimal APIs.
        //    •	Compatible avec les dernières versions de .NET.
        //8.Configuration fluide:
        //    •	Fournit une API fluide et intuitive pour configurer les bus de messages, les handlers, et les workflows.
        //9.Support des événements :
        //    •	Permet de publier et de souscrire à des événements pour implémenter des architectures orientées événements(Event - Driven Architecture).
        //10.Performances élevées:
        //    •	Optimisée pour des performances élevées, avec une faible latence et une gestion efficace des ressources.
        //11.Extensibilité :
        //    •	Facilement extensible pour répondre à des besoins spécifiques grâce à des hooks et des middlewares personnalisés.
        //12.Support des tests :
        //    •	Fournit des outils pour tester les workflows et les handlers de messages de manière isolée.

        var host = Host.CreateDefaultBuilder(args).UseWolverine().Build();

        await host.StartAsync();

        var bus = host.Services.GetRequiredService<IMessageBus>();

        await bus.SendAsync(new MyMessage { Content = "Bonjour, Wolverine !" });

        await host.StopAsync();
    }
}

public class MyMessage
{
    public string Content { get; set; }
}

public class MyMessageHandler
{
    public void Handle(MyMessage message)
    {
        Console.WriteLine($"Received message: {message.Content}");
    }
}