using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsersRepository : IUsers //MasterRepository, IUsers
    {
        /// <summary>
        /// Cadena de conexion.
        /// </summary>
        private readonly string connection;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor.
        /// </summary>
        public UsersRepository(IConfiguration config)
        {
            _configuration = config;
            connection = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            List<Users> lstUsers = new();
            using (SqlConnection conn = new(connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "GetAllUsers",
                        CommandTimeout = 10
                    };
                    await conn.OpenAsync();

                    cmd.ExecuteScalar();
                    SqlDataReader dt = cmd.ExecuteReader();

                    while (dt.Read())
                    {
                        Users datUsers = new()
                        {                            
                            IDIdentifier = Convert.ToInt64(dt["IDIdentifier"].ToString()),
                            Name = dt["Name"].ToString(),
                            LastName = dt["LastName"].ToString(),
                            Email = dt["Email"].ToString(),
                            PhoneNumber = Convert.ToInt64(dt["PhoneNumber"]),
                            DateOfBirthday = Convert.ToDateTime(dt["DateOfBirthday"].ToString())
                        };
                        lstUsers.Add(datUsers);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
            return lstUsers;
        }

        public async Task<Users> GetByID(int id)
        {
            Users producto = null;
            using (SqlConnection conn = new(connection))
            {
                try
                {
                    SqlCommand cmd = new()
                    {
                        Connection = conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "SPConsultarProductosPorId",
                        CommandTimeout = 10
                    };
                    cmd.Parameters.Add("@CodigoProducto", System.Data.SqlDbType.BigInt).Value = id;
                    await conn.OpenAsync();
                    cmd.ExecuteScalar();
                    SqlDataReader dt = cmd.ExecuteReader();

                    while (dt.Read())
                    {
                        producto = new Users()
                        {
                            //CodigoProducto = Convert.ToInt32(dt["CodigoProducto"].ToString()),
                            //NombreProducto = dt["NombreProducto"].ToString(),
                            //ValorUnitario = Convert.ToDecimal(dt["ValorUnitario"].ToString()),
                            //FechaCreacion = Convert.ToDateTime(dt["FechaCreacion"].ToString())
                        };
                    }

                    if (!dt.HasRows)
                    {
                        producto = new Users();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar", ex);
                }
                finally
                {
                    await conn.CloseAsync();
                }
            }
            return producto;
        }

        public async Task<int> Add(Users entity)
        {
            using SqlConnection conn = new(connection);
            
            SqlCommand cmd = new()
            {
                Connection = conn,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "InsertUsers",
                CommandTimeout = 10
            };
            cmd.Parameters.AddWithValue("@IDIdentifier", entity.IDIdentifier);
            cmd.Parameters["@IDIdentifier"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters["@Name"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@LastName", entity.LastName);
            cmd.Parameters["@LastName"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters["@Email"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
            cmd.Parameters["@PhoneNumber"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@DateOfBirthday", entity.DateOfBirthday);
            cmd.Parameters["@DateOfBirthday"].Direction = ParameterDirection.Input;
            await conn.OpenAsync();
            return cmd.ExecuteNonQuery();
        }

        public async Task<int> Update(Users entity)
        {
            //string mensaje = string.Empty;
            using (SqlConnection conn = new(connection))
            {

                SqlCommand cmd = new()
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "UpdateUsers",
                    CommandTimeout = 10
                };
                cmd.Parameters.AddWithValue("@IDIdentifier", entity.IDIdentifier);
                cmd.Parameters["@IDIdentifier"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters["@Name"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                cmd.Parameters["@LastName"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters["@Email"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
                cmd.Parameters["@PhoneNumber"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@DateOfBirthday", entity.DateOfBirthday);
                cmd.Parameters["@DateOfBirthday"].Direction = ParameterDirection.Input;
                await conn.OpenAsync();
                return cmd.ExecuteNonQuery();
                //int value = cmd.ExecuteNonQuery();                
            }
            //return mensaje;
        }

        public async Task<int> Delete(long id)
        {
            using (SqlConnection conn = new(connection))
            {
                SqlCommand cmd = new()
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "DeleteUsers",
                    CommandTimeout = 10
                };
                cmd.Parameters.AddWithValue("@IDIdentifier", id);
                cmd.Parameters["@IDIdentifier"].Direction = ParameterDirection.Input;
                await conn.OpenAsync();
                return cmd.ExecuteNonQuery();
            }
        }
        

        //private string selectAll;
        //private string insert;
        //private string update;
        //private string delete;

        //public UsersRepository()
        //{
        //    selectAll = "GetAllUsers";
        //    insert = "InsertUsers";
        //    update = "UpdateUsers";
        //    delete = "DeleteUsers";
        //}

        //public int Add(Users entity)
        //{
        //    sqlParameters = new List<SqlParameter>();
        //    sqlParameters.Add(new SqlParameter("@IDIdentifier", entity.IDIdentifier));
        //    sqlParameters.Add(new SqlParameter("@Name", entity.Name));
        //    sqlParameters.Add(new SqlParameter("@LastName", entity.LastName));
        //    sqlParameters.Add(new SqlParameter("@Email", entity.Email));
        //    sqlParameters.Add(new SqlParameter("@PhoneNumber", entity.PhoneNumber));
        //    sqlParameters.Add(new SqlParameter("@DateOfBirthday", entity.DateOfBirthday));

        //    return ExecuteNonQuery(insert);
        //}

        //public int Delete(int id)
        //{
        //    sqlParameters = new List<SqlParameter>();
        //    sqlParameters.Add(new SqlParameter("@IDIdentifier", id));            

        //    return ExecuteNonQuery(delete);
        //}

        //public IEnumerable<Users> GetAllUsers()
        //{
        //    var tableResult = ExecuteReader(selectAll);
        //    var listUser = new List<Users>();
        //    foreach (DataRow item in tableResult.Rows)
        //    {
        //        listUser.Add(new Users
        //        {
        //            IDIdentifier = Convert.ToInt32(item[0]),
        //            Name = item[1].ToString(),
        //            LastName = item[2].ToString(),
        //            Email = item[3].ToString(),
        //            PhoneNumber = Convert.ToInt32(item[4].ToString()),
        //            DateOfBirthday = Convert.ToDateTime(item[5].ToString()),
        //        });
        //    }
        //    return listUser;
        //}

        //public int Update(Users entity)
        //{
        //    sqlParameters = new List<SqlParameter>();
        //    sqlParameters.Add(new SqlParameter("@IDIdentifier", entity.IDIdentifier));
        //    sqlParameters.Add(new SqlParameter("@Name", entity.Name));
        //    sqlParameters.Add(new SqlParameter("@LastName", entity.LastName));
        //    sqlParameters.Add(new SqlParameter("@Email", entity.Email));
        //    sqlParameters.Add(new SqlParameter("@PhoneNumber", entity.PhoneNumber));
        //    sqlParameters.Add(new SqlParameter("@DateOfBirthday", entity.DateOfBirthday));

        //    return ExecuteNonQuery(update);
        //}
    }
}
