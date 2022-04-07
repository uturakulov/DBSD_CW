using DBSD_CW.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DBSD_CW.DAL
{
    public class StaffRepository : IStaffRepository
    {
        private string ConnStr
        {
            get
            {
                return WebConfigurationManager.ConnectionStrings["BrandBurgerConnStr"].ConnectionString;
            }
        }

        public void Delete(int Id)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Staff] WHERE [staff_id] = @staff_id";


                    cmd.Parameters.AddWithValue("@staff_id", Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Staff> Filter(string first_name, string last_name, string email, string branch, string role)
        {
            IList<Staff> staff = new List<Staff>();

            using (var conn = new SqlConnection(ConnStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    string sql = @"SELECT s.[staff_id], s.[first_name], s.[last_name], s.[email], s.[salary], s.[married], s.[birth_date], s.[gender], s.[role],
                                        s.[branch_id]
                                        FROM [dbo].[Staff] s LEFT JOIN Branch b on s.branch_id = b.branch_id";

                    string whereSql = "";

                    if (!string.IsNullOrWhiteSpace(first_name))
                    {
                        whereSql += (whereSql.Length == 0 ? "" : " AND ") + " s.first_name like @first_name + '%' ";
                        cmd.Parameters.AddWithValue("@first_name", first_name);
                    }

                    if (!string.IsNullOrWhiteSpace(last_name))
                    {
                        whereSql += (whereSql.Length == 0 ? "" : " AND ") + " s.last_name like @last_name + '%' ";
                        cmd.Parameters.AddWithValue("@last_name", last_name);
                    }

                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        whereSql += (whereSql.Length == 0 ? "" : " AND ") + " s.email like @email + '%' ";
                        cmd.Parameters.AddWithValue("@email", email);
                    }

                    if (!string.IsNullOrWhiteSpace(role))
                    {
                        whereSql += (whereSql.Length == 0 ? "" : " AND ") + " s.role like @role + '%' ";
                        cmd.Parameters.AddWithValue("@role", role);
                    }

                    if (!string.IsNullOrWhiteSpace(branch))
                    {
                        whereSql += (whereSql.Length == 0 ? "" : " AND ") + " b.branch_id like @branch + '%' ";
                        cmd.Parameters.AddWithValue("@branch", branch);
                    }

                    if (!string.IsNullOrEmpty(whereSql))
                    {
                        whereSql = " WHERE " + whereSql;
                    }

                    cmd.CommandText = sql + whereSql;

                    conn.Open();

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var Staff = new Staff();
                            Staff.StaffId = rdr.GetInt32(rdr.GetOrdinal("staff_id"));
                            Staff.FirstName = rdr.GetString(rdr.GetOrdinal("first_name"));
                            Staff.LastName = rdr.GetString(rdr.GetOrdinal("last_name"));
                            Staff.Email = rdr.GetString(rdr.GetOrdinal("email"));
                            Staff.Salary = rdr.GetDecimal(rdr.GetOrdinal("salary"));
                            Staff.Married = rdr.GetBoolean(rdr.GetOrdinal("married"));
                            Staff.BirthDate = rdr.GetDateTime(rdr.GetOrdinal("birth_date"));
                            Staff.Gender = rdr.GetString(rdr.GetOrdinal("gender"));
                            Staff.Role = rdr.GetString(rdr.GetOrdinal("role"));
                            Staff.BranchId = rdr.GetInt32(rdr.GetOrdinal("branch_id"));

                            staff.Add(Staff);
                        }
                    }
                }
            }
            return staff;
        }

        public IList<Staff> GetAll()
        {
            IList<Staff> staff = new List<Staff>();

            using (var conn = new SqlConnection(ConnStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [staff_id], [first_name], [last_name], [email], [salary], [married], [birth_date], [gender], [role], [branch_id] FROM [dbo].[Staff]";

                    conn.Open();

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var Staff = new Staff();
                            Staff.StaffId = rdr.GetInt32(rdr.GetOrdinal("staff_id"));
                            Staff.FirstName = rdr.GetString(rdr.GetOrdinal("first_name"));
                            Staff.LastName = rdr.GetString(rdr.GetOrdinal("last_name"));
                            Staff.Email = rdr.GetString(rdr.GetOrdinal("email"));
                            Staff.Salary = rdr.GetDecimal(rdr.GetOrdinal("salary"));
                            Staff.Married = rdr.GetBoolean(rdr.GetOrdinal("married"));
                            Staff.BirthDate = rdr.GetDateTime(rdr.GetOrdinal("birth_date"));
                            Staff.Gender = rdr.GetString(rdr.GetOrdinal("gender"));
                            Staff.Role = rdr.GetString(rdr.GetOrdinal("role"));
                            Staff.BranchId = rdr.GetInt32(rdr.GetOrdinal("branch_id"));

                            staff.Add(Staff);
                        }
                    }
                }
            }
            return staff;
        }

        public Staff GetById(int Id)
        {
            Staff staff = null;

            using (var conn = new SqlConnection(ConnStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT 
                                        [staff_id], 
                                        [first_name], 
                                        [last_name], 
                                        [email], 
                                        [salary], 
                                        [married], 
                                        [photo], 
                                        [birth_date], 
                                        [gender], 
                                        [role], 
                                        [branch_id] 
                                        FROM [dbo].[Staff]
                                        WHERE [staff_id] = @staff_id";

                    cmd.Parameters.AddWithValue("@staff_id", Id);

                    conn.Open();

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            staff = new Staff()
                            {
                                StaffId = Id,
                                FirstName = rdr.GetString(rdr.GetOrdinal("first_name")),
                                LastName = rdr.GetString(rdr.GetOrdinal("last_name")),
                                Email = rdr.GetString(rdr.GetOrdinal("email")),
                                Salary = rdr.GetDecimal(rdr.GetOrdinal("salary")),
                                Married = rdr.GetBoolean(rdr.GetOrdinal("married")),
                                Photo = rdr.IsDBNull(rdr.GetOrdinal("photo")) ? null : (byte[])rdr["photo"],
                                BirthDate = rdr.GetDateTime(rdr.GetOrdinal("birth_date")),
                                Gender = rdr.GetString(rdr.GetOrdinal("gender")),
                                Role = rdr.GetString(rdr.GetOrdinal("role")),
                                BranchId = rdr.GetInt32(rdr.GetOrdinal("branch_id")),
                            };
                        }
                    }
                }
            }
            return staff;
        }

        public void Insert(Staff staff)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Staff] (
                                                        [staff_id],
                                                        [first_name],
                                                        [last_name], 
                                                        [email], 
                                                        [salary], 
                                                        [married], 
                                                        [photo], 
                                                        [birth_date], 
                                                        [gender], 
                                                        [role], 
                                                        [branch_id])
                                                  VALUES (
                                                        @staff_id,
                                                        @first_name,
                                                        @last_name, 
                                                        @email, 
                                                        @salary, 
                                                        @married, 
                                                        @photo, 
                                                        @birth_date, 
                                                        @gender, 
                                                        @role, 
                                                        @branch_id
                                                        )";

                    var pFirstName = cmd.CreateParameter();
                    pFirstName.ParameterName = "@first_name";
                    pFirstName.Value = staff.FirstName;
                    pFirstName.Direction = ParameterDirection.Input;
                    pFirstName.DbType = DbType.AnsiString;
                    cmd.Parameters.Add(pFirstName);

                    cmd.Parameters.AddWithValue("@staff_id", staff.StaffId);
                    cmd.Parameters.AddWithValue("@last_name", staff.LastName);
                    cmd.Parameters.AddWithValue("@email", staff.Email);
                    cmd.Parameters.AddWithValue("@salary", staff.Salary);
                    cmd.Parameters.AddWithValue("@married", staff.Married);
                    cmd.Parameters.AddWithValue("@photo", staff.Photo);
                    cmd.Parameters.AddWithValue("@birth_date", staff.BirthDate);
                    cmd.Parameters.AddWithValue("@gender", staff.Gender);
                    cmd.Parameters.AddWithValue("@role", staff.Role);
                    cmd.Parameters.AddWithValue("@branch_id", staff.BranchId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Staff staff)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [dbo].[Staff] 
                                        SET [staff_id] = @staff_id,
                                            [first_name] = @first_name,
                                            [last_name] = @last_name, 
                                            [email]      =  @email,
                                            [salary]     =  @salary, 
                                            [married]    =  @married, 
                                            [birth_date] =  @birth_date,
                                            [gender]     =  @gender, 
                                            [role]       =  @role, 
                                            [branch_id]  =  @branch_id
                                        WHERE [staff_id] = @staff_id";

                    cmd.Parameters.AddWithValue("@staff_id", staff.StaffId);
                    cmd.Parameters.AddWithValue("@first_name", staff.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", staff.LastName);
                    cmd.Parameters.AddWithValue("@email", staff.Email);
                    cmd.Parameters.AddWithValue("@salary", staff.Salary);
                    cmd.Parameters.AddWithValue("@married", staff.Married);
                    cmd.Parameters.AddWithValue("@birth_date", staff.BirthDate);
                    cmd.Parameters.AddWithValue("@gender", staff.Gender);
                    cmd.Parameters.AddWithValue("@role", staff.Role);
                    cmd.Parameters.AddWithValue("@branch_id", staff.BranchId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}