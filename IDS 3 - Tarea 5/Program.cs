using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost; Database=BDProject; User Id=sa; Password=20186947Ismael";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Conexión exitosa");

            string salir = "N";

            while (salir.ToUpper() == "N")
            {
                // Insertar un asistente
                InsertarAsistente(connection);

                Console.Write("¿Desea salir? (Y/N): ");
                salir = Console.ReadLine().ToUpper();
            }
        }
    }

    static void InsertarAsistente(SqlConnection connection)
    {
        using (SqlCommand insertCommand = new SqlCommand("InsertarAsistenteBaseball", connection))
        {
            insertCommand.CommandType = CommandType.StoredProcedure;

            // Parámetros del asistente
            Console.Write("Tipo de Documento: ");
            string tipoDocumento = Console.ReadLine();
            Console.Write("Documento: ");
            string documento = Console.ReadLine();
            Console.Write("Asiento: ");
            string asiento = Console.ReadLine();
            Console.Write("Equipo Preferido: ");
            string equipoPreferido = Console.ReadLine();
            Console.Write("Sexo: ");
            string sexo = Console.ReadLine();
            Console.Write("Fecha de Nacimiento (YYYY-MM-DD): ");
            DateTime fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Horario (HH:mm:ss): ");
            TimeSpan horario = TimeSpan.Parse(Console.ReadLine());
            DateTime fechaIngreso = DateTime.Now;

            insertCommand.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
            insertCommand.Parameters.AddWithValue("@Documento", documento);
            insertCommand.Parameters.AddWithValue("@Asiento", asiento);
            insertCommand.Parameters.AddWithValue("@EquipoPreferido", equipoPreferido);
            insertCommand.Parameters.AddWithValue("@Sexo", sexo);
            insertCommand.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
            insertCommand.Parameters.AddWithValue("@Horario", horario);
            insertCommand.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);

            insertCommand.ExecuteNonQuery();
            Console.WriteLine("Asistente registrado exitosamente");
        }
    }
}
