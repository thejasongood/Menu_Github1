using System;

namespace Inventario.Alternativo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Program.cs — Laboratorio 03: validación del producto y menú inicial
            // Las instrucciones se ejecutan de arriba hacia abajo.

            int codigoProducto1 = 0;
            string productoNombre1 = "";
            decimal productoPrecio1 = 0;
            int stockProducto1 = 0;

            int codigoProducto2 = 0;
            string productoNombre2 = "";
            decimal productoPrecio2 = 0;
            int stockProducto2 = 0;

            int productosRegistrados = 0;
            string opcionMenu;

            do
            {
                Console.WriteLine();
                Console.WriteLine("=== MENÚ INVENTARIO ===");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Listar productos");
                Console.WriteLine("3. Salir");
                Console.Write("Elige una opción: ");
                opcionMenu = Console.ReadLine();

                switch (opcionMenu)
                {
                    case "1":

                        if (productosRegistrados >= 2)
                        {
                            Console.WriteLine("Ya se han registrado 2 productos.");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("=== Registro de producto ===");

                            // Paso 1 — Capturar y validar los datos con TryParse
                            Console.Write("Código del producto: ");
                            bool codigoValido = int.TryParse(
                                Console.ReadLine(),
                                out int codigoTemporal);

                            if (!codigoValido)
                            {
                                Console.WriteLine("Error: el código debe ser un número entero.");
                                return;
                            }

                            Console.Write("Nombre del producto: ");
                            string nombreTemporal = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(nombreTemporal))
                            {
                                Console.WriteLine("Error: el nombre del producto no puede estar vacío.");
                                return;
                            }

                            Console.Write("Precio unitario (Q): ");
                            bool precioValido = decimal.TryParse(
                                Console.ReadLine(),
                                out decimal precioTemporal);

                            if (!precioValido || precioTemporal <= 0)
                            {
                                Console.WriteLine("Error: el precio debe ser un número mayor que cero.");
                                return;
                            }

                            Console.Write("Cantidad en existencia: ");
                            bool cantidadValida = int.TryParse(
                                Console.ReadLine(),
                                out int cantidadTemporal);

                            if (!cantidadValida || cantidadTemporal < 0)
                            {
                                Console.WriteLine("Error: la cantidad debe ser un entero no negativo.");
                                return;
                            }

                            Console.WriteLine("Producto válido. ¡Datos aceptados!");

                            if (productosRegistrados == 0)
                            {
                                codigoProducto1 = codigoTemporal;
                                productoNombre1 = nombreTemporal;
                                productoPrecio1 = precioTemporal;
                                stockProducto1 = cantidadTemporal;
                            }
                            else
                            {
                                codigoProducto2 = codigoTemporal;
                                productoNombre2 = nombreTemporal;
                                productoPrecio2 = precioTemporal;
                                stockProducto2 = cantidadTemporal;
                            }

                            productosRegistrados++;

                            Console.WriteLine(
                                "→ Producto agregado. Total: " +
                                productosRegistrados);
                        }

                        break;

                    case "2":

                        Console.WriteLine();
                        Console.WriteLine("Lista de productos:");
                        Console.WriteLine();

                        if (productosRegistrados >= 1)
                        {
                            // Paso 2 — Clasificar el stock con if / else if / else
                            string estadoProducto1;

                            if (stockProducto1 == 0)
                                estadoProducto1 = "AGOTADO";
                            else if (stockProducto1 < 10)
                                estadoProducto1 = "STOCK BAJO";
                            else
                                estadoProducto1 = "DISPONIBLE";

                            Console.WriteLine("Producto 1");
                            Console.WriteLine("Nombre : " + productoNombre1);
                            Console.WriteLine("Código : " + codigoProducto1);
                            Console.WriteLine("Precio : Q " + productoPrecio1);
                            Console.WriteLine("Stock  : " + estadoProducto1);
                            Console.WriteLine();
                        }

                        if (productosRegistrados == 2)
                        {
                            string estadoProducto2;

                            if (stockProducto2 == 0)
                                estadoProducto2 = "AGOTADO";
                            else if (stockProducto2 < 10)
                                estadoProducto2 = "STOCK BAJO";
                            else
                                estadoProducto2 = "DISPONIBLE";

                            Console.WriteLine("Producto 2");
                            Console.WriteLine("Nombre : " + productoNombre2);
                            Console.WriteLine("Código : " + codigoProducto2);
                            Console.WriteLine("Precio : Q " + productoPrecio2);
                            Console.WriteLine("Stock  : " + estadoProducto2);
                            Console.WriteLine();
                        }

                        Console.WriteLine(
                            "Total de productos registrados: " +
                            productosRegistrados);

                        break;

                    case "3":

                        Console.WriteLine("Saliendo...");
                        Console.WriteLine();

                        // Paso 4 — Probar errores: ejecuta de nuevo con precio "abc",
                        // precio 0 o cantidad negativa y confirma que el programa NO se cae.

                        if (productosRegistrados >= 1)
                        {
                            Console.WriteLine(
                                "Proyección de stock a 5 días del Producto 1:");

                            for (int dia = 1; dia <= 5; dia++)
                            {
                                int stockFuturo1 =
                                    stockProducto1 + (dia * 3);

                                int faltanteStock1 =
                                    50 - stockFuturo1;

                                Console.WriteLine(
                                    "Día " + dia +
                                    ": stock proyectado = " +
                                    stockFuturo1 +
                                    " (faltante: " +
                                    faltanteStock1 + ")");
                            }
                        }

                        if (productosRegistrados == 2)
                        {
                            Console.WriteLine();

                            Console.WriteLine(
                                "Proyección de stock a 5 días del Producto 2:");

                            for (int dia = 1; dia <= 5; dia++)
                            {
                                int stockFuturo2 =
                                    stockProducto2 + (dia * 3);

                                int faltanteStock2 =
                                    50 - stockFuturo2;

                                Console.WriteLine(
                                    "Día " + dia +
                                    ": stock proyectado = " +
                                    stockFuturo2 +
                                    " (faltante: " +
                                    faltanteStock2 + ")");
                            }
                        }

                        break;

                    default:

                        Console.WriteLine("Opción no válida.");

                        break;
                }

            } while (opcionMenu != "3");
        }
    }
}