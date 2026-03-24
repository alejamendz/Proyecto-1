// See https://aka.ms/new-console-template for more information

int publicados = 0;
int rechazados = 0;
int revision = 0;
int altoImpacto = 0;
int impactoMedio = 0;
int bajoImpacto = 0;
int totalEvaluados = 0;

int opcion = 0;
do
{
    Console.WriteLine("Menú principal");
    Console.WriteLine("1. Evaluar nuevo contenido");
    Console.WriteLine("2. Mostrar reglas del sistema");
    Console.WriteLine("3. Mostrar estadísticas de la sesión");
    Console.WriteLine("4. Reiniciar estadísticas");
    Console.WriteLine("5. Salir");

    Console.WriteLine("Seleccione una opcion del menú");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            evaluarContenido();
            break;

        case 2:
            mostrarReglas();
            break;

        case 3:
            mostrarEstadisticas();
            break;

        case 4:
            reiniciarEstadisticas();
            break;
    }
} while (opcion != 5);
Console.WriteLine("Saliendo del programa...");


void evaluarContenido()
{
    int tipo;
    int duracion;
    int clasificaicon;
    int hora = 0;
    int produccion;

    int valido = 1;

    Console.WriteLine("Tipo de contenido");
    Console.WriteLine("1. Pelicula");
    Console.WriteLine("2. Serie");
    Console.WriteLine("3. Documental");
    Console.WriteLine("4. Evento en vivo");

    tipo = int.Parse(Console.ReadLine());

    Console.WriteLine("Duracion en minutos: ");
    duracion = int.Parse(Console.ReadLine());

    Console.WriteLine("Clasificacion: ");
    Console.WriteLine("1. Todo público");
    Console.WriteLine("2. +13");
    Console.WriteLine("3. +18");
    clasificaicon = int.Parse(Console.ReadLine());

    Console.WriteLine("Hora programada (0-23): ");
    hora = int.Parse(Console.ReadLine());

    Console.WriteLine("Nivel de producción:");
    Console.WriteLine("1. Bajo");
    Console.WriteLine("2. Medio");
    Console.WriteLine("3. Alto");
    produccion = int.Parse(Console.ReadLine());

    
    totalEvaluados++;

    if (tipo == 1)
    {
        if (duracion < 60 || duracion > 180)
        {
            valido = 0;
        }
    }
    else if (tipo == 2)
    {
        if (duracion < 20 || duracion > 90)
        {
            valido = 0;
        }
    }
    else if (tipo == 3)
    {
        if (duracion < 30 || duracion > 120)
        {
            valido = 0;
        }
    }
    else if (tipo == 4)
    {
        if (duracion < 30 || duracion > 240)
        {
            valido = 0;
        }
    }

    if (clasificaicon == 2)
    {
        if (hora < 6 || hora > 22) 
        {
            valido = 0;
        }
    }

    if (clasificaicon == 3)
    {
        if (!(hora >= 22 || hora <= 5))
        {
            valido = 0;
        }
    }

    if (produccion == 1)
    {
        if (clasificaicon == 3)
        {
            valido = 0;
        }
    }

    if (valido == 0)
    {
        Console.WriteLine("Decision final: Rechazar");
        
        rechazados++;
        return;
    }

    string impacto = CalcularImpacto(duracion, hora, produccion);
    if (impacto == "Alto")
    {
        Console.WriteLine("Decision final: Enviar a revision");
        revision++;
    }
    else
    {
        Console.WriteLine("Decision final: Publicar");
        publicados++;
    }
    Console.WriteLine("Impacto: " + impacto);
}

string CalcularImpacto(int duracion, int hora, int produccion)
{
    if (produccion == 3 || duracion > 120 || (hora >= 20 && hora <= 23))
    {
        altoImpacto++;
        return "Alto";
    }
    else if (produccion == 2 || (duracion >= 60 && duracion <= 120))
    {
        impactoMedio++;
        return "Medio";
    }
    else
    {
        bajoImpacto++;
        return "Bajo";
    }
}

void mostrarReglas()
{
    Console.WriteLine("REGLAS DE CLASIFICACION Y HORARIO");
    Console.WriteLine("Todo público: cualquier hora");
    Console.WriteLine("+13: entre 6 y 22");
    Console.WriteLine("+18: entre 22 y 5");

    Console.WriteLine();

    Console.WriteLine("REGLAS DE DURACION POR TIPO");
    Console.WriteLine("Película: 60 - 180 minutos");
    Console.WriteLine("Serie: 20 - 90 minutos");
    Console.WriteLine("Documental: 30 - 120 minutos");
    Console.WriteLine("Evento en vivo: 30 - 240 minutos");

    Console.WriteLine();
}

void mostrarEstadisticas()
{
    Console.WriteLine("ESTADISTICAS");

    Console.WriteLine($"Total evaluados: {totalEvaluados}");
    Console.WriteLine($"Publicados: {publicados}");
    Console.WriteLine($"Rechazados: {rechazados}");
    Console.WriteLine($"En revisión: {revision}");

   
    string principal = "Bajo";
    int mayor = bajoImpacto;

    if (impactoMedio > mayor)
    {
        mayor = impactoMedio;
        principal = "Medio";
    }

    if (altoImpacto > mayor)
    {
        principal = "Alto";
    }

    Console.WriteLine($"Impacto principal: {principal}");

    double porcentaje = 0;
    if (totalEvaluados > 0)
    {
        porcentaje = (publicados * 100.0) / totalEvaluados;
    }

    Console.WriteLine($"Porcentaje de aprobacion: {porcentaje}%");

    for (int a = 0; a < 3; a++)
    {
        Console.WriteLine(".");
    }
    Console.WriteLine();
}

void reiniciarEstadisticas()
{
    totalEvaluados = 0;
    publicados = 0;
    rechazados = 0;
    revision = 0;
    altoImpacto = 0;
    impactoMedio = 0;
    bajoImpacto = 0;

    Console.WriteLine("Estadísticas reiniciadas");
}