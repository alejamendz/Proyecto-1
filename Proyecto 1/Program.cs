// See https://aka.ms/new-console-template for more information
Console.WriteLine("Simulador de decisiones para plataforma de streaming");

int publicados = 0;
int rechazados = 0;
int revision = 0;
int altoImpacto = 0;
int impactoMedio = 0;
int bajoImpacto = 0;

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
    opcion =int.Parse(Console.ReadLine());





} while (opcion != 5);