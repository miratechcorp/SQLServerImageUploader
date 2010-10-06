using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Gnu.Getopt;

namespace SQLServerImageUploader
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            int c;
            LongOpt[] longopts = new LongOpt[4];
            string param0placeholder = "@Name";
            string param1placeholder = "@BinArray";
            string dsn = System.Environment.GetEnvironmentVariable("DSN");
            string sql = System.Environment.GetEnvironmentVariable("SQL");
            string file = null;
            string name = null;
            byte[] fileArray;

            longopts[0] = new LongOpt("help", Argument.No, null, '?');
            longopts[1] = new LongOpt("dsn", Argument.Required, null, 'd');
            longopts[1] = new LongOpt("sql", Argument.Required, null, 's');
            longopts[2] = new LongOpt("file", Argument.Required, null, 'f');
            longopts[3] = new LongOpt("name", Argument.Required, null, 'n');

            Getopt g = new Getopt(System.AppDomain.CurrentDomain.FriendlyName, args, "?d:s:f:n:", longopts);

            while ((c = g.getopt()) != -1) {
                switch (c) {
                    case '?':
                        Help();
                        return;
                    case 'd':
                        dsn = g.Optarg;
                        break;
                    case 's':
                        sql = g.Optarg;
                        break;
                    case 'f':
                        file = g.Optarg;
                        break;
                    case 'n':
                        name = g.Optarg;
                        break;
                }
            }

            if ((dsn == null) || (sql == null) || (file == null)) {
                Help();
                return;
            }
            if (name == null) {
                name = Path.GetFileNameWithoutExtension(file);
            }

            try {
                fileArray = GetFileArray(file);
            } catch {
                Help();
                return;
            }

            sql = String.Format(sql, param0placeholder, param1placeholder);

            try {
                Save(dsn, sql, fileArray, name, param0placeholder, param1placeholder);
            } catch {
                Help();
                Debug(dsn, sql, file, fileArray);
            }
        }

        static void Help()
        {
            Console.WriteLine("Usage: " + System.AppDomain.CurrentDomain.FriendlyName + " [-?|--help] [-dDSN|--dsn=DSN] [-sSQL|--sql=SQL] {-fFile|--file=File} [-nName|--nameName]");
            Console.WriteLine("       -?, --help : Display this usage message");
            Console.WriteLine("       -d, --dsn  : Set the database connection string");
            Console.WriteLine("       -s, --sql  : Set the sql to use");
            Console.WriteLine("       -f, --file : Set the file to upload");
            Console.WriteLine("       -n, --name : Set the name to use");
            Console.WriteLine("       DSN        : The database connection string (try http://www.connectionstrings.com)");
            Console.WriteLine("       SQL        : The sql statement should include 2 placeholders ({0} and {1})");
            Console.WriteLine("         {0}      : Where to insert the name");
            Console.WriteLine("         {1}      : Where to insert the binary data");
            Console.WriteLine("       File       : Relative or absolute path to the file to be included");
            Console.WriteLine("       Name       : The name to use (the filename will be used if not supplied)");
            Console.WriteLine();
            Console.WriteLine("The DSN and SQL value can be set as environment variables to upload several files to the same location");
            Console.WriteLine();
        }

        static void Debug(string dsn, string sql, string bin, byte[] binArray)
        {
            Console.WriteLine("Debug: ");
            Console.WriteLine("       DSN : " + dsn);
            Console.WriteLine("       SQL : " + sql);
            Console.WriteLine("       BIN : " + bin + " (" + binArray.LongLength.ToString() + " bytes)");
            Console.WriteLine();
        }

        static byte[] GetFileArray(string file)
        {
            byte[] fileArray = null;

            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(file).Length;
            fileArray = br.ReadBytes((int)numBytes);

            return fileArray;
        }

        static int Save(string dsn, string sql, byte[] fileArray, string name, string param0placeholder, string param1placeholder)
        {
            SqlConnection connection = new SqlConnection(dsn);
            SqlCommand command = new SqlCommand(sql, connection);

            SqlParameter param0 = new SqlParameter(param0placeholder, SqlDbType.VarChar);
            param0.Value = name;
            command.Parameters.Add(param0);

            SqlParameter param1 = new SqlParameter(param1placeholder, SqlDbType.Image);
            param1.Value = fileArray;
            command.Parameters.Add(param1);

            connection.Open();
            int numRowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return numRowsAffected;
        }
    }
}
