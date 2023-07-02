
using Infraestructure.Persistence;
using Microsoft.Identity.Client;
using Domain.Entities;
using Infraestructure.Command;
using Infraestructure.Querys;
using Application.UseCase;
using Application.Interfaces.ICommands;
using Application.Interfaces.IQuerys;
using Infraestructure.Commands;
using Application.Interfaces.Services;
using Application.UseCase.Requests;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using System;
using TP_Parte_1_Corsiglia_Gonzalo;
using Microsoft.IdentityModel.Tokens;

class Program
{
    static async Task Main(string[] args)
    {

        var serviceCollection = new ServiceCollection();

        ProgramServices services = new ProgramServices(serviceCollection);

        services.ConfigureServices();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var context = serviceProvider.GetService<AppDbcontext>();

        Console.WriteLine("Bienvenido al sistema del Restorbar QueRico!");
        Menu Menu = new Menu();

        while (true)
        {
            int opcion = await Menu.MostrarMenu();

            switch (opcion)
            {
                case 1:
                    await VerMenuMercaderias(serviceProvider);
                    Console.WriteLine("Ingrese una tecla, cuando este listo para realizar su pedido...");
                    Console.ReadKey();
                    await RegistrarComanda(serviceProvider);
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 2:
                    await EnlistarComandas(serviceProvider);
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 3:
                    Console.WriteLine("Gracias por utilizar el sistema del RestoBar QueRico!. Hasta luego.");
                    return;

                default:
                    Console.WriteLine("Opción inválida. Ingrese una opción válida.");
                    break;
            }
        }
    }

    private static async Task RegistrarComanda(IServiceProvider serviceProvider)
    {
        var comandaServices = serviceProvider.GetRequiredService<IComandaServices>();
        var mercaderiaServices = serviceProvider.GetRequiredService<IMercaderiaServices>();
        var formaEntregaServices = serviceProvider.GetRequiredService<IFormaEntregaServices>();

        var formaEntregas = await formaEntregaServices.GetAllFormaEntrega();
        PresentarFormaEntregas(formaEntregas);

        var formaEntregaId = LeerFormaEntregaId();

        var pedidos = new List<CreateComandaRequest>();
        Guid idPedido = Guid.NewGuid();


        while (true)
        {
            var mercaderiaId = LeerMercaderiaId();

            var mercaderiaPedida = await mercaderiaServices.GetMercaderiaById(mercaderiaId);

            if (mercaderiaPedida == null)
            {
                Console.WriteLine("Mercadería no encontrada. Ingrese un ID de mercadería válido o escriba 'fin' para terminar la lista de pedidos.");
                continue;
            }


            var pedido = new CreateComandaRequest(formaEntregaId, mercaderiaId);
            pedido.ComandaId = idPedido;
            pedidos.Add(pedido);


            Console.WriteLine($"{mercaderiaPedida.Nombre} agregado al pedido.");

            Console.WriteLine("¿Desea agregar otra mercadería? Escriba 'si' o 'no'");
            var respuesta = Console.ReadLine();
            if (respuesta?.ToLower() != "si")
            {
                break;
            }
            Console.Clear();
            await VerMenuMercaderias((ServiceProvider)serviceProvider);

        }

        if (pedidos.Count == 0)
        {
            Console.WriteLine("No se agregaron mercaderías al pedido.");
            return;
        }

        await comandaServices.CreateComanda(pedidos);

        var formaEntrega = await formaEntregaServices.GetFormaEntregaById(formaEntregaId);
        Console.Out.Flush();
        await PresentarPedidoRealizado(pedidos, formaEntrega, serviceProvider);


    }


    private static void PresentarFormaEntregas(IEnumerable<FormaEntrega> formaEntregas)
    {
        Console.WriteLine("\nFormas de entrega disponibles:");
        foreach (var formaEntrega in formaEntregas)
        {
            Console.WriteLine($"{formaEntrega.FormaEntregaId} - {formaEntrega.Descripcion}");
        }
    }

    private static int LeerFormaEntregaId()
    {
        Console.WriteLine("Seleccione una forma de entrega:");
        int.TryParse(Console.ReadLine(), out var formaEntregaId);
        return formaEntregaId;
    }

    private static int LeerMercaderiaId()
    {
        Console.WriteLine("Ingrese el ID de la mercadería:");
        int.TryParse(Console.ReadLine(), out var mercaderiaId);
        return mercaderiaId;
    }

    private static async Task PresentarPedidoRealizado(List<CreateComandaRequest> mercaderiaPedida, FormaEntrega formaEntrega, IServiceProvider serviceProvider)
    {
        Console.WriteLine("Usted acaba de pedir: ");
        Console.WriteLine("\t{0,-30} {1,-10}", "Plato", "Precio");

        foreach (var comanda in mercaderiaPedida) 
        {
            Mercaderia mercaderia = await serviceProvider.GetService<IMercaderiaServices>().GetMercaderiaById(comanda.MercaderiaId);

            Console.WriteLine("\t{0,-30} {1,-10:C}", mercaderia.Nombre, mercaderia.Precio);
        }
        Console.WriteLine($"\nPedido realizado con éxito. Forma de entrega: {formaEntrega.Descripcion}");
    }



    private static async Task VerMenuMercaderias(IServiceProvider serviceProvider)
    {
        IMercaderiaServices mercaderiaServices = serviceProvider.GetService<IMercaderiaServices>();

        Task<IEnumerable<Mercaderia>> taskmercaderias = mercaderiaServices.GetAllMercaderia();
        IEnumerable<Mercaderia> mercaderias = await taskmercaderias;

        foreach (Mercaderia mercaderia in mercaderias)
        {
            Console.WriteLine($"ID: {mercaderia.MercaderiaId} -- Producto: {mercaderia.Nombre}");
        }

    }


    private static async Task EnlistarComandas(IServiceProvider serviceProvider)
    {
        IComandaServices comandaServices = serviceProvider.GetService<IComandaServices>();
        IFormaEntregaServices formaEntregaServices = serviceProvider.GetService<IFormaEntregaServices>();
        IMercaderiaServices mercaderiaServices = serviceProvider.GetService<IMercaderiaServices>();

        
        Task<IEnumerable<Comanda>> taskcomandas = comandaServices.GetAllComandas();
        IEnumerable<Comanda> comandas = await taskcomandas;


        foreach (Comanda comanda in comandas)
        {
            Console.WriteLine($"Comanda ID: {comanda.ComandaId} -- Fecha: {comanda.Fecha} -- PrecioTotal: {comanda.PrecioTotal}");
            Console.WriteLine("Detalle: ");

            await ImprimirDetallesComanda(comanda, mercaderiaServices);

            FormaEntrega formaEntrega = await formaEntregaServices.GetFormaEntregaById(comanda.FormaEntregaId);

            Console.WriteLine($"\nForma de Entrega: {formaEntrega.Descripcion}");
        }
    }

    private static async Task ImprimirDetallesComanda(Comanda comanda, IMercaderiaServices mercaderiaServices)
    {
        if (comanda.ComandaMercaderia != null)
        {
            foreach (ComandaMercaderia comandaMercaderia in comanda.ComandaMercaderia)
            {
                Mercaderia mercaderia = await mercaderiaServices.GetMercaderiaById(comandaMercaderia.MercaderiaId);

                Console.WriteLine("\t{0,-30} {1,-10:C}", mercaderia.Nombre, mercaderia.Precio);
            }
        }
    }
}

