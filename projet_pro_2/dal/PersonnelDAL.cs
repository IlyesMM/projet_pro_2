using System;
using System.Collections.Generic;
using projet_pro_2.Models;
using MySql.Data.MySqlClient;

namespace projet_pro_2.dal
{
    public class PersonnelDAL
    {
        private readonly DatabaseManager databaseManager;

        public PersonnelDAL()
        {
            databaseManager = new DatabaseManager();
        }

        public List<Personnel> GetAllPersonnels()
        {
            var personnels = new List<Personnel>();
            string query = "SELECT * FROM personnel";

            using (var connection = databaseManager.GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    personnels.Add(new Personnel
                    {
                        Id = reader.GetInt32("idpersonnel"),
                        Nom = reader.GetString("nom"),
                        Prenom = reader.GetString("prenom"),
                        Tel = reader.GetString("tel"),
                        Mail = reader.GetString("mail"),
                        Service = reader.GetString("idservice")
                    });
                }
            }

            return personnels;
        }

        public void InsertPersonnel(Personnel personnel)
        {
            string query = "INSERT INTO personnel (nom, prenom, tel, mail, idservice) VALUES (@nom, @prenom, @tel, @mail, @idservice)";

            using (var connection = databaseManager.GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nom", personnel.Nom);
                command.Parameters.AddWithValue("@prenom", personnel.Prenom);
                command.Parameters.AddWithValue("@tel", personnel.Tel);
                command.Parameters.AddWithValue("@mail", personnel.Mail);
                command.Parameters.AddWithValue("@idservice", personnel.Service);
                command.ExecuteNonQuery();
            }
        }

       
    }
}
